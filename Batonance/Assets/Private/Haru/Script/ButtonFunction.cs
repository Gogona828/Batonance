using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonFunction : MonoBehaviour
{
    [SerializeField]
    private EventSystem eventSystem;
    /// <summary>
    /// タイトルシーンに移行する関数
    /// </summary>
    public void GoTitle()
    {
        Debug.Log("タイトルに戻るぞ〜");
    }
    /// <summary>
    /// アプリケーションを終了する関数
    /// </summary>
    public void AppEnd()
    {
        Debug.Log("ゲーム、やめるぞ〜");
        Application.Quit();
    }
    /// <summary>
    /// コンフィグを表示する関数
    /// </summary>
    public void DisplayConfig(GameObject config)
    {
        Debug.Log("コンフィグ開けたぞ！");
        //eventSystem.currentSelectedGameObject.transform.position += new Vector3(100,100,100);
        config.SetActive(!config.activeSelf);
    }
}
