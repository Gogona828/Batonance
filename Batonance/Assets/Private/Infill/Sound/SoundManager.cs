using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    #region データリスト
    public List<SoundDataAsset> BGMList = new List<SoundDataAsset>();
    public List<SoundDataAsset> SEList = new List<SoundDataAsset>();

    #endregion
    #region BGM管理
    public GameObject playerAudio;
    private AudioSource playerAudioSource;

    #endregion
    
    private void Awake() {
        Initialization();
    }
    // Start is called before the first frame update
    void Start(){
        // Initialization();
    }

    // Update is called once per frame
    void Update(){
        
    }
    //オブジェクトがStaticのためStart呼び出されなかったら怖いなーのための隔離
    void Initialization(){
        playerAudioSource = playerAudio.GetComponent<AudioSource>();
        Debug.Log("PlayerAudioSource = " + playerAudioSource);
    }

    #region BGM関数
    //サウンド検索、keyで検索、ヒットした場合そのAudioClip部分を返す。
    //ヒットしなかった場合Null
    public AudioClip GetBGM(string key){
        return Search(BGMList,key);
    }
    //BGM再生
    public void SetBGM(AudioClip clip){
        playerAudioSource.clip = clip;
        playerAudioSource.Play();
        Debug.Log("ChangeBGM");
    }
    
    #endregion
    #region SE関数
    public AudioClip GetSE(string key){
        return Search(SEList,key);
    }
    #endregion
    
    //BGMズレを修正するための実験的関数
    //アプリケーションが読み込まれていない時、BGMを停止させる

    private void OnApplicationPause(bool pauseStatus) {
        if(pauseStatus)
        {
            playerAudioSource.Pause();
            Debug.Log("アプリ終了を検知");
        }
        else
        {
            Debug.Log("アプリ再開を検知");
            playerAudioSource.Play();
        }

    }
    //BGMとSEの検索用関数
    private AudioClip Search(List<SoundDataAsset> list,string key){
        AudioClip _clip = null;
        //List検索
        for(int i = 0; i < list.Count; i++)
        {
            if(list[i].soundKey == key)
            {
                _clip = list[i].SoundFile;
            }
        }
        //出力
        Debug.Log(_clip);
        return _clip;
    }

}
