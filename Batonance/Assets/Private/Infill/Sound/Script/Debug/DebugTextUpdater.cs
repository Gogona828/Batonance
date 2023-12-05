using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DebugTextUpdater : MonoBehaviour
{
    private Text text;
    private NotesManager notesManager;
    // Start is called before the first frame update
    void Start()
    {
        text = this.GetComponent<Text>();
        notesManager = GameObject.Find("NotesManager").GetComponent<NotesManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        text.text = $"NowMeasure:{SectionCount.instance.CurrentSection}\n";
    }
}
