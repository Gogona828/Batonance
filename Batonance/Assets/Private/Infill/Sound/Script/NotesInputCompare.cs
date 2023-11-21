using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NotesData;
/// <summary>
/// 入力と譜面を比較して、差異を計算する
/// </summary>
public class NotesInputCompare : MonoBehaviour
{
    [SerializeField, Tooltip("PlayerのDealDamageを入れる")]
    private DealDamage dealDamage;
    private float timer = 0;
    private NotesManager notesManager;
    private (int, float) data;
    private bool hitCheck = false;//false => 処理が終わったノーツ True=>最新ノーツ
    public static NotesInputCompare instance;

    private NotesCount notesCount;
    // Start is called before the first frame update
    private void Awake() {
        if (!instance) instance = this;
        else Destroy(this);
    }
    void Start()
    {
        GameObject notesManagerObject = GameObject.Find("NotesManager");
        notesCount = notesManagerObject.GetComponent<NotesCount>();
        notesManager = notesManagerObject.GetComponent<NotesManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        timer += Time.deltaTime;
    }

    //TODO:方向指定が実装できたら引数で取る方へシフト。
    public void InputAttack(int way)
    {
        int result = CompareTiming(timer, way);
        Debug.Log($"result: {result}");
        Debug.Log(timer);
    }
    public int CompareTiming(float inputTime,int way)
    {
        //0 = 良？とかでリスト化かenum化
        int result = 0;
        (int, float) _data;
        Debug.Log("DeQueue");
        if(!hitCheck)
        {
            hitCheck = true;
            data = notesManager.GetNotesTime();
        }
        _data = data;
        if(way == _data.Item1)
        {
            float compareTime = Mathf.Abs(_data.Item2 - inputTime);
            result = CompareTimeToInput(compareTime);
            Debug.Log($"result:{result}");
            // TODO: resultの結果に合わせてDealDamageを呼び出す
            if (result == 0) dealDamage.DefeatEnemy();
            Debug.Log("DeQueue:" + result);
        }
        return result;
    }
    //3秒以上はスルー、それ以外は有効。
    private int CompareTimeToInput(float compareTime)
    {
        if(compareTime > 3f)
        {
            return 0;
        }
        hitCheck = false;
        if (compareTime < 0.5f) 
        {
            return 1;
        }
        if (compareTime < 3f)
        {
            return 2;
        }
        else return 3;
        
    }
}
