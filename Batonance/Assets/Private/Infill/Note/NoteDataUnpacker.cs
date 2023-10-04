using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using NoteData;

public class NoteUnpacker :MonoBehaviour
{
    public (BaseData,NoteList) NoteDataUnpack(TextAsset textAsset)
    {
        string inputData = textAsset.ToString();
        BaseData baseData = JsonUtility.FromJson<BaseData>(inputData);
        NoteList noteList = JsonUtility.FromJson<NoteList>(inputData);
        return (baseData,noteList);
    }
}
