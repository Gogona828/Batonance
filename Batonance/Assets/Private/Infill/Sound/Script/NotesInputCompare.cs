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
    public (int, float, int) data;
    // private bool hitCheck = false; //false => 処理が終わったノーツ True=>最新ノーツ
    public static NotesInputCompare instance;

    private NotesCount notesCount;

    // Start is called before the first frame update
    private void Awake()
    {
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
        // DebugTextUpdater.instance.hitCheck = hitCheck;
    }

    public void ReSetTimer()
    {
        timer = 0f;
        Debug.Log($"reset");
    }

    //TODO:方向指定が実装できたら引数で取る方へシフト。
    public void InputAttack(int way)
    {
        int result = CompareTiming(timer, way);
        // Debug.Log($"result: {result}");
        // Debug.Log(timer);
    }

    public int CompareTiming(float inputTime, int way)
    {
        //0 = 良？とかでリスト化かenum化
        int result = 0;
        (int, float, int) _data;
        // if (!hitCheck)
        // {
        //     hitCheck = true;
            data = notesManager.GetNotesTime();
        // }

        _data = data;
        Debug.Log($"notes time : {_data.Item2}, input time : {inputTime}");
        if (way == _data.Item1)
        {
            float compareTime = Mathf.Abs(_data.Item2 - inputTime);
            result = CompareTimeToInput(compareTime, way, _data);
            DebugTextUpdater.instance.lastResult = result;
            Debug.Log($"result:{compareTime}");
            // TODO: resultの結果に合わせてDealDamageを呼び出す
            if (result == 1)
            {
                dealDamage.StartCoroutine("DefeatEnemy", way);
            }
            Debug.Log("DeQueue:" + result);
            return result;
        }
        else return 2;
    }

    //3秒以上はスルー、それ以外は有効。
    private int CompareTimeToInput(float compareTime,int way,(int, float, int) _data)
    {
        // hitCheck = false;
        DebugTextUpdater.instance.distance = compareTime;
        if (compareTime > 0.3f)
        {
            return 0;
        }
        // hitCheck = false;
        if (compareTime < 0.3f && way == _data.Item1)
        {
            return 1;
        }
        if (compareTime < 0.3f)
        {
            Missed();
            return 2;
        }
        else
        {
            Missed();
            return 2;
        }
    }

    /// <summary>
    /// ミスしたときの処理
    /// </summary>
    public void Missed()
    {
        Debug.Log("Missed");
        data = (0, 0f, 0);
        SEManager.instance.PlaySE(0);
        AdministerGameState.instance.GameOver();
    }
}
