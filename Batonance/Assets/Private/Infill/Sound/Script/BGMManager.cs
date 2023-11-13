using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.Events;
///<summary>
///BGMセット、再生、変更、通知の機能。
///メインループは記述しない
///</summary>
//外部から変更、通知リスト追加、通知リスト削除のアクセス。
public class BGMManager : MonoBehaviour
{
    private bool set = false;//外部によって呼び出されたことがあるかの検知
    //BPMのサウンド再生、通知用変数
    #region BGM
    private int bpm;    //BPM速度
    public int BPM { get { return bpm; } set { value = bpm; } }
    private float offset; //曲再生するまでの時間(s)
    private float beat; //BPMから計算した１拍あたりの間隔秒数
    private int measure; //小節数
    private int nowMeasureCount = 2;//小節数カウント.++が先に入るため１～小節数の範囲内でカウントする。
    private float bpmTimer; //一小節の時間カウントタイマー
    private AudioSource bgmAudioSource;    //再生するオブジェクト。Find指定希望。Awake処理参照
    private AudioClip bgmAudioClip;    //再生するBGM
    private bool firstPlay = true;    //offsetをセットするためのbool
    private SoundDataAsset soundDataAsset;

    public int currentMeasureCount = 2;//小節数カウント.nowと違い全体的な位置を示すために使用する
    public SoundDataAsset debugFirstSoundDataAsset;//スタート時のサウンドアセット設定がめんどくさい

    //通知用
    public UnityEvent subject = new UnityEvent();

    [Header("BGM")] private GameObject playerSoundObject;//AudioSourceのついているPlayerObject
    [Header("Debug"), SerializeField] private bool debugMetronome = false;
    [SerializeField]private AudioSource metronomeSE;//メトロノームチェック用オブジェクト。未設定でも動作する。

    // 富田が追加
    public static BGMManager instance;
    #endregion

    #region Main
    private void Awake() {
        if (!instance) instance = this;
        else Destroy(this);
    }
    // Start is called before the first frame update
    void Start()
    {
        //Debugのデータセット
        // DebugDataSet();
    }
    public void InitializeLoad()
    {
        //シングルプレイ確定であれば、GameObject.Findで検索。
        if (false) return;//全シーンのAudioSourceオブジェクト名が不明のため
        
        //↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓上がtrueなら通らない↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
        playerSoundObject = GameObject.Find("BGMAudioSource");
        bgmAudioSource = playerSoundObject.GetComponent<AudioSource>();

        DebugDataSet();
        set = true;
        Debug.Log("Finished SoundSet");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if(set)Metronome();
    }
    #endregion
    #region 状態検知する関数
    //BGMズレを修正するための実験的関数
    //アプリケーションが読み込まれていない時、BGMを停止させる
    //いらん
    private void OnApplicationPause(bool pauseStatus) {
        if(pauseStatus)
        {
            Debug.Log("アプリ停止を検知");
        }
        else
        {
            Debug.Log("アプリ再開を検知");
        }
    }

    #endregion
    
    #region BGM
    ///<summary>
    ///外部からBGMを変更する場合に使用する。（恐らくSoundManagerに検索機能を付けてそこからアクセスだろうけど。）
    ///なお外部からセットする場合これ以外のアクセスは不要
    ///</summary>
    public void SetBGM(SoundDataAsset _useSoundDataAsset)
    {
        soundDataAsset = _useSoundDataAsset;
        SetData();
        bgmAudioSource.Play();
    }
    public (int,int) GetMeasure()
    {
        return (nowMeasureCount, currentMeasureCount);
    }
    ///<summary>
    ///セットされたScriptableObjectから各種データをセットする。要素数が増えた場合項目を増やすこと。
    ///</summary>
    private void SetData()
    {
        bpm = soundDataAsset.bpm;
        offset = soundDataAsset.offset;
        measure = soundDataAsset.measure;
        beat = 60f / bpm;
        bgmAudioClip = soundDataAsset.soundFile;
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
        if (bpmTimer >= _beatTime)
        {
            //offset対応
            firstPlay = false;

            //bpm通知対応
            bpmTimer -= _beatTime;
            Debug.Log("NowMeasure:" + nowMeasureCount + ",currentMeasure:" + currentMeasureCount);
            BPMNotifier();
            //floatの歪みを矯正
            if (nowMeasureCount  == measure)
            {
                BGMLoop();
            }
            AddMeasure();
            // Debug.Log(bpmTimer);


            //Debug用、通知タイミングにサウンドが鳴る。
            if (metronomeSE != null && debugMetronome)
            {
                metronomeSE.PlayOneShot(metronomeSE.clip);
            }

            Debug.Log($"beat: {beat}");

            // TODO: 将来的には「UnityEvent<T0>」でイベントに追加したい
            EnemyManager.instance.PrepareGeneration(currentMeasureCount);
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
        // TODO: SectionCountで現在のセクション数を加算する。
        // Section.instance.
    }
    #endregion

    #region 通知
    ///<summary>
    ///UnityEventの通知処理
    ///</summary>
    private void BPMNotifier()
    {
        Debug.Log("BPM通知");
        subject.Invoke();
    }

    #endregion
    #region Debug


    ///<summary>
    ///通知システムの確認
    ///</summary>
    [ContextMenu("Method")]
    public void TestCallEvent()
    {
        Debug.Log("Test:BPM通知");
        BPMNotifier();
    }

    public void ResetMeasure()
    {
        currentMeasureCount = 2;
        nowMeasureCount = 2;
    }
    
    private void DebugDataSet()
    {
        SetBGM(debugFirstSoundDataAsset);
        // bpm = 185;
        // offset = 100;
        // measure = 16;
        // beat = 60f / bpm;
        // firstPlay = true;
    }
    #endregion
}