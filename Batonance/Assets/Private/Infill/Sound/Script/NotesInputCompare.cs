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
    public float debugInputTimer = 0f;
    private bool hitCheck = true;     //タッチがノーツ判定圏外かの判定
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
        hitCheck = true;
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
        debugInputTimer = inputTime;
        //0 = 良？とかでリスト化かenum化
        int result = 999;
        (int, float, int) _data;
        if (hitCheck)
        {
            hitCheck = false;
            data = notesManager.GetNotesTime();
            Debug.Log($"Debug:{data}");
        }

        _data = data;
        Debug.Log($"notes time : {_data.Item2}, input time : {inputTime}");
        if (way == _data.Item1)
        {
            float compareTime = Mathf.Abs(_data.Item2 - inputTime);
            result = CompareTimeToInput(compareTime, way, _data);

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
        if (compareTime > 0.333f)
        {
            return 0;
        }
        hitCheck = true;
        if (compareTime < 0.333f && way == _data.Item1)
        {
            return 1;
        }
        if (compareTime < 0.5f)
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
        BGMManager.instance.isMissed = false;
        data = (0, 0f, 0);
        SEManager.instance.PlaySE(0);
        AdministerGameState.instance.GameOver();
    }
}
