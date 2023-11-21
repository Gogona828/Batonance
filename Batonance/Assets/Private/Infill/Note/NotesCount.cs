using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesCount : MonoBehaviour
{
    private int maxNotesCount, nowNotesCount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CompareNotesCount()
    {
        NotesManager notesManager = this.gameObject.GetComponent<NotesManager>();
        nowNotesCount++;
        if(nowNotesCount == notesManager.NotesListCount())
        {
            Debug.Log("Clear");
        }
    }
}
