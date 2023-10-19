using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NotesData;
using JetBrains.Annotations;

public class NotesManager : MonoBehaviour
{
    NotesDataUnpacker notesDataUnpacker;
    public TextAsset notesData;
    private List<(int,float)> notesTimeList = new List<(int,float)>();
    private Queue<(int, float)> notesTimeQueue = new Queue<(int, float)>();
    // Start is called before the first frame update
    void Start()
    {
        Initialization(notesData);
        LoadQueue();
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

    public (int,float) GetNotesTime()
    {
        return notesTimeQueue.Dequeue();
    }
    //再ロードの際読み込みし直し必要
    public void LoadQueue()
    {
        foreach((int,float)item in notesTimeList)
        {
            notesTimeQueue.Enqueue(item);
        }
    }
    public int NotesListCount()
    {
        return notesTimeList.Count;
    }
}
