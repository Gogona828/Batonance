using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;

public class SectionCount : MonoBehaviour
{
    [SerializeField]
    private int currentSection = 1;//現在のセクションを保存する変数
    public int CurrentSection { get { return currentSection; } private set{ value = currentSection; } }
    [SerializeField]
    private int maxSection;//そのシーンのステージのセクション数
    public int MaxSection { get { return maxSection; } private set{ value = maxSection; } }
    public static SectionCount instance;
    [SerializeField] private SectionEventManager sectionEventManager;
    [SerializeField]
    private ShowGameOver bottonScript;
    private void Awake()
    {
        //シングルトン
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        InitialLoad();
    }

    /// <summary>
    /// 初期ロード
    /// </summary>
    private void InitialLoad()
    {
        currentSection = 1;
        Debug.Log("初期化しました");
        //セクション更新時に発火するやつ
        sectionEventManager.Initialize(currentSection);
    }
    /// <summary>
    /// ゲームオーバ時の再ロード
    /// </summary>
    public void ReLoad()
    {
        Debug.Log("再スタートしました");
        //セクション更新時に発火するやつ
        sectionEventManager.Initialize(currentSection);
    }
    /// <summary>
    /// 中間地点に辿り着いた時に呼び出す
    /// </summary>
    public void HalfwayPoint()
    {
        currentSection++;
        BGMManager.instance.isMissed = true;
        if (currentSection > maxSection)
        {
            //SceneManager.LoadScene("ClearScene");
            ////SceneTransition(ClearScene);
            bottonScript.ShowUI();
            InitialLoad();//ステージクリア
        }
    }

}
