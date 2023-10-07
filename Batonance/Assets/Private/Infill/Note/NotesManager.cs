using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NotesData;

public class NotesManager : MonoBehaviour
{
    NotesDataUnpacker notesDataUnpacker;
    public TextAsset notesData;
    private List<(int,float)> notesTimeList = new List<(int,float)>();
    // Start is called before the first frame update
    void Start()
    {
        Initialization(notesData);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //AwakeとStartのどちらが良いか悩み中。
    //Startなら開始タイミングのズレが、Awakeだと順序が不安。
    //セクションが変わるときにtext替えて呼び出し直す？かも
    public void Initialization(TextAsset text)
    {
        notesDataUnpacker = this.GetComponent<NotesDataUnpacker>();
        notesTimeList = notesDataUnpacker.NotesDataUnpackToTime(text);
    }
}
