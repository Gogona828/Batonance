using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionCount : MonoBehaviour
{
    public int currentSection;
    public int maxSection;
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
        //InitialLoad();
        //Debug.Log(currentSection);
    }

    /// <summary>
    /// 初期ロード
    /// </summary>
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
        currentSection = 1;
        Debug.Log("再スタートしました");
    }
    public void Clear()
    {
        currentSection++;
        if (currentSection > maxSection) maxSection = currentSection;
        Debug.Log("クリアしました");
    }

}
