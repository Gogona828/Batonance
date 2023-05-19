using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFunction : MonoBehaviour
{
    public void GoTitle()
    {
        Debug.Log("タイトルに戻るぞ〜");
    }
    public void AppEnd()
    {
        Debug.Log("ゲーム、やめるぞ〜");
        Application.Quit();
    }
    public void DisplayConfig()
    {
        Debug.Log("コンフィグ開けたぞ！");
    }
}
