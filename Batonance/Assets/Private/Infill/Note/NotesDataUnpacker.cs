using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using NotesData;

public class NotesDataUnpacker :MonoBehaviour
{
    public (BaseData,NotesList) NotesDataUnpack(TextAsset textAsset)
    {
        Debug.Log("UnpackData_Start");
        string inputString = textAsset.ToString();
        BaseData baseData = JsonUtility.FromJson<BaseData>(inputString);
        NotesList noteList = JsonUtility.FromJson<NotesList>(inputString);
        return (baseData,noteList);
    }
    public List<Notes> Convert_NotesListToList(NotesList notesList)
    {
        List<Notes> notes = new List<Notes>();
        for(int i = 0; i < notesList.notes.Length; i++)
        {
            notes.Add(notesList.notes[i]);
        }
        return notes;
    }
    public List<(int,float)> Convert_MeasureToTime((BaseData,NotesList) notesData)
    {
        List<(int, float)> returnData = new List<(int, float)>();
        int _BPM = notesData.Item1.BPM;
        int _LPB = notesData.Item2.notes[0].LPB;
        Debug.Log("LPB:" + _LPB);
        for(int i = 0; i < notesData.Item2.notes.Length; i++)
        {
            int _num = notesData.Item2.notes[i].num;
            //(ノーツ番号,ノーツ到達秒数)のint,float
            returnData.Add((_num,(_BPM / 60f) * _num / _LPB));
        }
        return returnData;
    }
    public List<(int,float)> NotesDataUnpackToTime(TextAsset textAsset)
    {
        return Convert_MeasureToTime(NotesDataUnpack(textAsset));
    }
}
