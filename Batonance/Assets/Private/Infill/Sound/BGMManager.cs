using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.Events;
///<summary>
///BGMセット、再生、変更、通知の役割
///</summary>
//外部から変更、通知リスト追加、通知リスト削除のアクセス。
public class BGMManager : MonoBehaviour
{
    //BPMのサウンド再生、通知用変数
    #region BGM
    private int bpm;    //BPM速度
    private int offset; //曲再生するまでの時間(s)
    private float beat; //BPMから計算した１拍あたりの間隔秒数
    private int measure; //小節数
    private int nowMeasureCount = 0;//小節数カウント.++が先に入るため１～１６の範囲内でカウントする。
    private float bpmTimer; //一小節の時間カウントタイマー
    private AudioSource bgmAudioSource;    //再生するオブジェクト。Find指定希望。Awake処理参照
    private AudioClip bgmAudioClip;    //再生するBGM
    private bool firstPlay = true;    //offsetをセットするためのbool
    private SoundDataAsset soundDataAsset;

    //通知用
    public UnityEvent subject = new UnityEvent();
    public delegate void HogeDelegate(string a);
    HogeDelegate h;

    [Header("BGM"),SerializeField] private GameObject playerSoundObject;//AudioSourceのついているPlayerObject
    [Header("Debug"), SerializeField] private bool debugMetronome = false;
    [SerializeField]private AudioSource metronomeSE;//メトロノームチェック用オブジェクト。未設定でも動作する。
    #endregion

    #region Main
    private void Awake() {
        //シングルプレイ確定であれば、GameObject.Findで検索。
        if (true) return;//全シーンのAudioSourceオブジェクト名が不明のため
        
        //↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓上がtrueなら通らない↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
        playerSoundObject = GameObject.Find("BGMAudioSource");
        bgmAudioSource = playerSoundObject.GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void Start()
    {
        //Debugのデータセット
        DebugDataSet();
        h = (a) => { TestCallEvent(); };
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        Metronome();
    }
    #endregion
    #region 状態検知する関数
    //BGMズレを修正するための実験的関数
    //アプリケーションが読み込まれていない時、BGMを停止させる
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
    }
    ///<summary>
    ///セットされたScriptableObjectから各種データをセットする。要素数が増えた場合項目を増やすこと。
    ///</summary>
    private void SetData()
    {
        bpm = soundDataAsset.bpm;
        offset = soundDataAsset.offset;
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
            nowMeasureCount++;
            BPMNotifier();
            //floatの歪みを矯正
            Debug.Log(nowMeasureCount);
            if (nowMeasureCount  == measure)
            {
                ResetBGM();
            }
            // Debug.Log(bpmTimer);


            //Debug用、通知タイミングにサウンドが鳴る。
            if (metronomeSE != null && debugMetronome)
            {
                metronomeSE.PlayOneShot(metronomeSE.clip);
            }
        }
    }
    ///<summary>
    ///BGMのループ時、もしくは曲変更時に呼び出し。タイマーリセット。
    ///</summary>
    private void ResetBGM()
    {
        bpmTimer = 0f;
        nowMeasureCount = 0;
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
    
    private void DebugDataSet()
    {
        bpm = 185;
        offset = 100;
        measure = 16;
        beat = 60f / bpm;
        firstPlay = true;
    }
    #endregion
}