using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NotesData;
/// <summary>
/// デバッグ用に動作させるためのスクリプト。NotesDataの読み込み発火が主。
/// 機能集の備忘録として使用。
/// NoteDataUnpackerを同じオブジェクトにAddComponentすること。
/// </summary>
public class Debug_EnemySpawner : MonoBehaviour
{
    NotesDataUnpacker noteDataUnpacker;
    public TextAsset text;//読み込むJsonFile
    private (BaseData, NotesList) notesData;//デシリアライズデータの受け取り
    private List<Notes> spawnEnemyData = new List<Notes>();

    BGMManager bgmManager;
    // Start is called before the first frame update
    void Start()
    {
        bgmManager = GameObject.Find("BGMManager").GetComponent<BGMManager>();
        noteDataUnpacker = this.GetComponent<NotesDataUnpacker>();
        Set();
        AddSubjectListener();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Set()
    {
        //通常、読み込むためにtextAssetのJsonファイルを引数に関数を呼び出す
        notesData = noteDataUnpacker.NotesDataUnpack(text);
        //数値の獲得例
        //BPM（BaseDataの使用）
        // Debug.Log(notesData.Item1.BPM);
        //num(NotesDataの使用)
        // Debug.Log(notesData.Item2.notes[0].num);

        //配列型のリストへコンバート。for文を使用するため、処理のネックに注意
        spawnEnemyData = noteDataUnpacker.Convert_NotesListToList(notesData.Item2);
        //データの取り方（SpawnEnemeyData　配列２のノーツ、numを獲得する）
        // Debug.Log(spawnEnemyData[2].num);
    }
    public void SpawnCheck()
    {
        Debug.Log("通知");
        (int, int) measure = bgmManager.GetMeasure();
        //Listの先頭要素の小節数を引っこ抜いて照合、合ってたら生成を行う
        //初期ロードで生成し切るなら書き直し
        if(spawnEnemyData[0].num == measure.Item2)
        {
            //生成処理。
            Debug.Log("Debug:生成処理");
            spawnEnemyData.RemoveAt(0);
            SpawnCheck();
        
        }
    }
    //拍を通知するUnityEventへの登録
    public void AddSubjectListener()
    {
        bgmManager.subject.AddListener(SpawnCheck);
    }
}
