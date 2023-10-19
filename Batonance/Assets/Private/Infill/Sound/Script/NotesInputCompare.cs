using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NotesData;
/// <summary>
/// 入力と譜面を比較して、差異を計算する
/// </summary>
public class NotesInputCompare : MonoBehaviour
{
    private float timer = 0;
    private NotesManager notesManager;
    // Start is called before the first frame update
    private void Awake() {

    }
    void Start()
    {
        notesManager = GameObject.Find("NotesManager").GetComponent<NotesManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        timer += Time.deltaTime;
    }

    public void InputAttack()
    {
        int result = CompareTiming(timer);
        Debug.Log(timer);
    }
    public int CompareTiming(float inputTime)
    {
        //0 = 良？とかでリスト化かenum化
        int result = 0;

        (int,float) _data = notesManager.GetNotesTime();
        
        return result;
    }
}
