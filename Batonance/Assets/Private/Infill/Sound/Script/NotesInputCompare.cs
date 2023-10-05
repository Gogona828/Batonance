using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NotesData;
using UnityEngine.PlayerLoop;
/// <summary>
/// 入力と譜面を比較して、差異を計算する
/// </summary>
public class NotesInputCompare : MonoBehaviour
{
    //Inputの獲得

    //NotesMap
    NoteDataUnpacker noteDataUnpacker;
    public TextAsset notesData;
    private List<(int,float)> notesTimeList = new List<(int,float)>();
    float inputTime;

    // Start is called before the first frame update
    private void Awake() {

    }
    void Start()
    {
        Initialization(notesData);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Initialization(TextAsset text)
    {
        //AwakeとStartのどちらが良いか悩み中。
        //Startなら開始タイミングのズレが、Awakeだと順序が不安。
        //セクションが変わるときにtext替えて呼び出し直す？かも
        noteDataUnpacker = this.GetComponent<NoteDataUnpacker>();
        SetNoteData(text);
        CompareTiming(inputTime);
    }
    void SetNoteData(TextAsset text)
    {
        //譜面データの読み込み
        (BaseData, NotesList) _notesData;//デシリアライズデータの受け取り
        _notesData = noteDataUnpacker.NoteDataUnpack(text);
        int _BPM = _notesData.Item1.BPM;
        Debug.Log((_BPM / 60f));
        for(int i = 0; i < _notesData.Item2.notes.Length; i++)
        {
            int _num = _notesData.Item2.notes[i].num;
            //(ノーツ番号,ノーツ到達秒数)のint,float
            notesTimeList.Add((_num,(_BPM / 60f) * _num));
        }
    }
    int CompareTiming(float inputTime)
    {
        //0 = 良？とかでリスト化かenum化
        int result = 0;
        //どうしよっか（Listを小節数だけ生成してしまった方が、findをする必要はない
        //が、Listが冗長になる。逆に必要分だけにするなら、現在小節から最寄りのList位置を保存、計算する処理を毎発火ごとに行う必要がある？
        //結論：後回し。
        return result;
    }
}
