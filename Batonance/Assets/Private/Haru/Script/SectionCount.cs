using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionCount : MonoBehaviour
{
    [SerializeField]
    private int currentSection = 1;
    public int CurrentSection { get { return currentSection; } private set{ value = currentSection; } }
    [SerializeField]
    private int maxSection = 1;
    public int MaxSection { get { return maxSection; } private set{ value = maxSection; } }
    public static SectionCount instance;
    private void Awake()
    {
        //シングルトン
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
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
        //Debug.Log(currentSection);
    }

    /// <summary>
    /// 初期ロード
    /// </summary>
    // TODO: private化してStartへ
    public void InitialLoad()
    {
        currentSection = 1;
        maxSection = 1;
        Debug.Log("初期化しました");
    }
    /// <summary>
    /// ゲームオーバ時の再ロード
    /// </summary>
    public void ReLoad()
    {
        // TODO: セクションを保存する必要がある
        currentSection = 1;
        Debug.Log("再スタートしました");
    }

    // TODO: 名前をもっと具体化する
    public void Clear()
    {
        currentSection++;
        if (currentSection > maxSection) maxSection = currentSection;
        Debug.Log("クリアしました");
    }

}
