using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NotesData;
/// <summary>
/// デバッグ用に動作させるためのスクリプト。NotesDataの読み込み発火が主。
/// 機能集として使用。
/// </summary>
public class Debug_EnemySpawner : MonoBehaviour
{
    NoteDataUnpacker noteDataUnpacker;
    public TextAsset text;
    private (BaseData, NotesList) notesData;
    // Start is called before the first frame update
    void Start()
    {
        noteDataUnpacker = this.GetComponent<NoteDataUnpacker>();
        Set();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Set()
    {
        //通常、読み込むためにtextAssetのJsonファイルを引数に関数を呼び出す
        notesData = noteDataUnpacker.NoteDataUnpack(text);
        //数値の獲得例
        //BPM（BaseDataの使用）
        // Debug.Log(notesData.Item1.BPM);
        //num(NotesDataの使用)
        // Debug.Log(notesData.Item2.notes[0].num);

        //配列型のリストへコンバート。for文を使用するため、処理のネックに注意
        noteDataUnpacker.Convert_NoteListToList(notesData.Item2);
    }
}
