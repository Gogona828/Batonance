using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NoteData
{
    public class BaseData
    {
        public string name;
        public int maxBlock;
        public int bpm;
        public int offset;
    }
    public class Note
    {
        public int lbp;
        public int num;
        public int block;
        public int type;
    }

    public class NoteList : MonoBehaviour
    {
        public Note[] notes;
    }
}