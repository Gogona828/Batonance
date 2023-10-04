using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NotesData
{
    [Serializable]
    public class BaseData
    {
        public string name;
        public int maxBlock;
        public int BPM;
        public int offset;
    }
    [Serializable]
    public class Notes
    {
        public int LBP;
        public int num;
        public int block;
        public int type;
    }
    [Serializable]
    public class NotesList
    {
        public Notes[] notes;
    }
}