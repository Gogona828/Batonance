using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using NotesData;

public class NoteDataUnpacker :MonoBehaviour
{
    public (BaseData,NotesList) NoteDataUnpack(TextAsset textAsset)
    {
        Debug.Log("UnpackData_Start");
        string inputString = textAsset.ToString();
        BaseData baseData = JsonUtility.FromJson<BaseData>(inputString);
        NotesList noteList = JsonUtility.FromJson<NotesList>(inputString);
        return (baseData,noteList);
    }
    public List<Notes> Convert_NoteListToList(NotesList notesList)
    {
        List<Notes> notes = new List<Notes>();
        for(int i = 0; i < notesList.notes.Length; i++)
        {
            notes.Add(notesList.notes[i]);
        }
        return notes;
    }
}
