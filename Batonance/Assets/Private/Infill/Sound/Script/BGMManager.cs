using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.Events;
using NotesData;
///<summary>
///BGMセット、再生、変更、通知の機能。
///</summary>
//外部から変更、通知リスト追加、通知リスト削除のアクセス。
public class BGMManager : MonoBehaviour
{
    private bool set = false;   //外部によって呼び出されたことがあるかの検知
    //BPMのサウンド再生、通知用変数
    #region BGM
    private int bpm;    //BPM速度
    public int BPM { get { return bpm; } set { value = bpm; } }
    private float offset;                   //曲再生するまでの時間(s)
    private float beat;                     //BPMから計算した１拍あたりの間隔秒数
    private int measure;                    //小節数
    private int nowMeasureCount;        //小節数カウント.++が先に入るため１～小節数の範囲内でカウントする。
    public float bpmTimer { get; private set; }                 //一小節の時間カウントタイマー
    private AudioSource bgmAudioSource;     //再生するオブジェクト。Find指定希望。Awake処理参照
    private AudioClip bgmAudioClip;         //再生するBGM
    private bool firstPlay = true;          //offsetをセットするためのbool
    public List<SoundDataAsset> soundDataAsset = new List<SoundDataAsset>();
    [System.NonSerialized]public int currentMeasureCount;     //小節数カウント.nowと違い全体的な位置を示すために使用する

    //通知用
    public UnityEvent subject = new UnityEvent();
    public UnityEvent subjectForHalf = new UnityEvent();
    private bool callHalf = true;

    [Header("BGM")] private GameObject playerSoundObject;//AudioSourceのついているPlayerObject
    [Header("Debug"), SerializeField] private bool debugMetronome = false;
    [SerializeField]private AudioSource metronomeSE;//メトロノームチェック用オブジェクト。未設定でも動作する。

    SectionEventManager sectionEventManager;

    private bool is_FirstPlay = true;       //セクション１が最初か、全てクリアした後なのか判断
    public bool isMissed = true;        //True=ミスしてない,シーンリロード時の小節カウント調整
    public bool Is_FirstPlay { get { return is_FirstPlay; } private set{value = is_FirstPlay; } }
    // 富田が追加
    public static BGMManager instance;
    #endregion

    #region Main
    private void Awake() {
        if (!instance) instance = this;
        else Destroy(this);

        sectionEventManager = GameObject.Find("SectionEventManager").GetComponent<SectionEventManager>();
        sectionEventManager.subject.AddListener(SetBGM);
    }
    
    // Start is called before the first frame update
    void Start()
    {

    }
    public void InitializeLoad()
    {
        set = true;
        playerSoundObject = GameObject.Find("BGMAudioSource");
        bgmAudioSource = playerSoundObject.GetComponent<AudioSource>();
        SetBGM();

        Debug.Log("Finished SoundSet");
    }

    void FixedUpdate()
    {
        if(set)Metronome();
        //無理やり時間を止める
        if (!is_FirstPlay && SectionCount.instance.CurrentSection == 1 && Time.timeScale == 1)
        {
            AdministerGameState.instance.GameClear();
            bgmAudioSource.Stop();
        }
    }
    #endregion
    
    #region BGM
    ///<summary>
    ///データのセットをしてAudioSourceの再生をする。
    ///引数は無しorSoundDataAsset。引数なしの場合はセットされているものを再生。引数ありの場合はそれをセットして再生
    ///</summary>
    public void SetBGM()
    {
        ResetMeasure();
        SetData();
        bgmAudioSource.Play();

        AdministerGameState.instance.GameStart();
    }
    public void StopBGM()
    {
        bgmAudioSource.Stop();
    }
    /// <summary>
    /// 現在の小節数（楽曲のなかの何小節目か,全体から見て何小節目か)をreturnする
    /// </summary>
    /// <returns></returns>
    public (int,int) GetMeasure()
    {
        return (nowMeasureCount, currentMeasureCount);
    }
    public void ResetMeasure()
    {
        nowMeasureCount = 1;
        currentMeasureCount = 1;
        Debug.Log($"nowmeasure{nowMeasureCount},currentmeasure{currentMeasureCount}");
        //二度目のセクション１がロードされるため、時間停止で処理
        if(!is_FirstPlay && SectionCount.instance.CurrentSection == 1)
        {
            Time.timeScale = 0;
        }
    }
    ///<summary>
    ///セットされたScriptableObjectから各種データをセットする。
    ///</summary>
    private void SetData()
    {
        //セクション数の獲得
        int _currentSection = SectionCount.instance.CurrentSection - 1;
        //各種データのセット
        BaseData baseData = JsonUtility.FromJson<BaseData>(soundDataAsset[_currentSection].notesData.ToString());
        bpm = baseData.BPM;                                     //BPM
        offset = baseData.offset;                               //Offset
        measure = soundDataAsset[_currentSection].measure;      //measure
        beat = 60f / bpm;                                       //bpmを秒に変換
        bgmAudioClip = soundDataAsset[_currentSection].soundFile;//音源獲得
        bgmAudioSource.clip = bgmAudioClip;                     //音源のセット
        firstPlay = true;
    }
    ///<summary>
    ///通知の間隔をカウントする
    ///</summary>
    private void Metronome()
    {
        float _beatTime = beat;
        //offset
        if(firstPlay)
        {
            _beatTime = beat + offset * 0.01f;
        }
        //タイマー
        bpmTimer += Time.deltaTime;
        if (bpmTimer >= _beatTime / 2 && callHalf) 
        {
            //八分音符が連呼されないようにbool管理
            callHalf = false;
            BPMNotifierForHalf();

            //Debug用、通知タイミングにサウンドが鳴る。
            if (metronomeSE != null && debugMetronome)
            {
                metronomeSE.PlayOneShot(metronomeSE.clip);
            }
        }
        if (bpmTimer >= _beatTime)
        {
            //offset対応
            firstPlay = false;
            //八分音符用のリセット
            callHalf = true;
            //秒数の減算。０にすると多分ズレが生じる
            bpmTimer -= _beatTime;
            //通知
            BPMNotifier();
            // Debug.Log($"nowMeasure:{nowMeasureCount},currentMeasure{currentMeasureCount}");
            //floatの歪みを矯正
            if (SectionCount.instance.CurrentSection == 1 && nowMeasureCount  == measure && isMissed)
            {
                Debug.Log("CheckPoint");
                BGMLoop();
            }
            if (SectionCount.instance.CurrentSection != 1 && nowMeasureCount  == measure + 1 && isMissed)
            {
                Debug.Log("CheckPoint");
                BGMLoop();
            }
            if (SectionCount.instance.CurrentSection == 1 && nowMeasureCount  == measure + 1 && !isMissed)
            {
                Debug.Log("CheckPoint");
                BGMLoop();
            }
            if (SectionCount.instance.CurrentSection != 1 && nowMeasureCount  == measure + 1 && !isMissed)
            {
                Debug.Log("CheckPoint");
                BGMLoop();
            }
            AddMeasure();

            //Debug用、通知タイミングにサウンドが鳴る。
            if (metronomeSE != null && debugMetronome)
            {
                metronomeSE.PlayOneShot(metronomeSE.clip);
            }

            // TODO: 将来的には「UnityEvent<T0>」でイベントに追加したい
            EnemyManager.instance.PrepareGeneration(nowMeasureCount);
        }
    }
    private void AddMeasure()
    {
        nowMeasureCount++;
        currentMeasureCount++;
    }
    ///<summary>
    ///BGMのループ時、もしくは曲変更時に呼び出し。タイマーリセット。
    ///</summary>
    private void BGMLoop()
    {
        bpmTimer = 0f;
        nowMeasureCount = 0;
        // 競合解決
        SectionCount.instance.HalfwayPoint();
        sectionEventManager.Initialize(SectionCount.instance.CurrentSection);
        //セクションが切り替わったらセクション１は終了。クリアした後のセクション１と区別するboolを変更する
        if(SectionCount.instance.CurrentSection != 1)
        {
            is_FirstPlay = false;
        }
    }

    public void ResetBGM()
    {
        bpmTimer = 0f;
        nowMeasureCount = 1;
    }
    #endregion

    #region 通知
    ///<summary>
    ///UnityEventの通知処理
    ///</summary>
    private void BPMNotifier()
    {
        subject.Invoke();
        subjectForHalf.Invoke();
    }
    private void BPMNotifierForHalf()
    {
        subjectForHalf.Invoke();
    }

    #endregion
}