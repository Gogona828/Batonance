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
    public List<(int,float,int)> Convert_MeasureToTime((BaseData,NotesList) notesData)
    {
        List<(int, float, int)> returnData = new List<(int, float, int)>();
        int _BPM = notesData.Item1.BPM;
        int _LPB = notesData.Item2.notes[0].LPB;
        for(int i = 0; i < notesData.Item2.notes.Length; i++)
        {
            int _num = notesData.Item2.notes[i].num;
            int type = notesData.Item2.notes[i].type;
            int block = notesData.Item2.notes[i].block;
            //(レーン,ノーツ到達秒数、種類)のint,float,int
            returnData.Add((block, 60f / _BPM / _LPB * _num, type));
        }
        return returnData;
    }
    public List<(int,float, int)> NotesDataUnpackToTime(TextAsset textAsset)
    {
        return Convert_MeasureToTime(NotesDataUnpack(textAsset));
    }
}
