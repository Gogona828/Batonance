using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NotesData;
using JetBrains.Annotations;

public class NotesManager : MonoBehaviour
{
    NotesDataUnpacker notesDataUnpacker;
    //public TextAsset notesData;
    private List<(int,float,int)> notesTimeList = new List<(int,float,int)>();
    private Queue<(int, float, int)> notesTimeQueue = new Queue<(int, float, int)>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //AwakeとStartのどちらが良いか悩み中。
    //Startなら開始タイミングのズレが、Awakeだと順序が不安。
    //セクションが変わるときにtext替えて呼び出し直す？かも
    public void ReloadSection()
    {
        Initialization(BGMManager.instance.soundDataAsset[SectionCount.instance.CurrentSection - 1].notesData);
    }
    public void Initialization(TextAsset text)
    {
        Debug.Log($"reload");
        notesDataUnpacker = this.GetComponent<NotesDataUnpacker>();
        notesTimeList = notesDataUnpacker.NotesDataUnpackToTime(text);
        EnemyManager.instance.GetNotesList(notesTimeList);
        notesTimeQueue.Clear();
    }

    public (int,float,int) GetNotesTime()
    {
        if (notesTimeQueue.Count == 0)
        {
            SectionCount.instance.HalfwayPoint();
            return (0, 0f, 0);
        } 
        var notes = notesTimeQueue.Dequeue();
        return notes;
    }

    public void ResetNotes()
    {
        if (SectionCount.instance.CurrentSection == 2 || SectionCount.instance.CurrentSection == 3) notesTimeQueue.Dequeue();
    }

    public void AdjustNotes()
    {
        notesTimeQueue.Dequeue();
    }
    
    //再ロードの際読み込みし直し必要
    public void LoadQueue()
    {
        foreach((int,float,int)item in notesTimeList)
        {
            notesTimeQueue.Enqueue(item);
        }
    }
    public int NotesListCount()
    {
        return notesTimeList.Count;
    }
}
