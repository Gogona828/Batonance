using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DebugTextUpdater : MonoBehaviour
{
    private Text text;
    private NotesManager notesManager;
    NotesInputCompare notesInputCompare;
    public int lastResult;
    public static DebugTextUpdater instance;
    public bool hitCheck;
    public float distance;
    // Start is called before the first frame update
    void Awake()
    {
        if (!instance) instance = this;
        else Destroy(this);
    }
    void Start()
    {
        text = this.GetComponent<Text>();
        notesManager = GameObject.Find("NotesManager").GetComponent<NotesManager>();
        notesInputCompare = GameObject.Find("NotesManager").GetComponent<NotesInputCompare>();
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        (int, int) measureData = BGMManager.instance.GetMeasure();
        var data = 
        text.text = $"NowSection:{SectionCount.instance.CurrentSection}\nNowMeasure:{measureData.Item1}\nCurrentMeasure:{measureData.Item2}\nNowTimeScane:{Time.timeScale}\nis_FirstPlay:{BGMManager.instance.Is_FirstPlay}\nNowQueueData:{notesInputCompare.data}\nLastResult:{lastResult}\nHitCheck:{hitCheck}\nDistance:{distance}";
    }
}
