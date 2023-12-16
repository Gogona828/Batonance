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
    private bool hitCheck;
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
        
        text.text = $"NowTime:{BGMManager.instance.bpmTimer}\nNowMeasure:{BGMManager.instance.currentMeasureCount}\n,InputTimer:{notesInputCompare.debugInputTimer}";
    }
}
