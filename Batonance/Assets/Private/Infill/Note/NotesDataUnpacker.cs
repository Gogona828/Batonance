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
        Debug.Log("Data:NotesCount:" + notesData.Item2.notes.Length);
        Debug.Log("LPB:" + _LPB);
        for(int i = 0; i < notesData.Item2.notes.Length; i++)
        {
            int _num = notesData.Item2.notes[i].num;
            int type = notesData.Item2.notes[i].type;
            //(ノーツ番号,ノーツ到達秒数)のint,float
            returnData.Add((type, 60f / _BPM / _LPB * _num));
        }
        return returnData;
    }
    public List<(int,float)> NotesDataUnpackToTime(TextAsset textAsset)
    {
        return Convert_MeasureToTime(NotesDataUnpack(textAsset));
    }
}
