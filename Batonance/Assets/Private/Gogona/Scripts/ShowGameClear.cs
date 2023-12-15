using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowGameClear : MonoBehaviour
{
    [SerializeField, Tooltip("GameClearUIを入れる")]
    private CanvasGroup gameClearUI;
    [SerializeField, Tooltip("RetryButtonを入れる")]
    private Button retryButton;
    [SerializeField, Tooltip("BackToTitleButtonを入れる")]
    private Button titleButton;

    [SerializeField, Tooltip("GameOverUIを入れる")]
    private GameObject gameOverUI;

    void Start()
    {
        Time.timeScale = 1;
        // ゲームオーバーUIを非表示にする
        HideClearUI();
    }
    
    /// <summary>
    /// ゲームオーバーUIを表示する
    /// </summary>
    public void ShowClearUI()
    {
        gameClearUI.alpha = 1;
        // ボタンを押せるようにする
        retryButton.interactable = true;
        titleButton.interactable = true;
        gameOverUI.SetActive(false);
    }
    
    /// <summary>
    /// ゲームオーバーUIを非表示にする
    /// </summary>
    public void HideClearUI()
    {
        gameClearUI.alpha = 0;
        Time.timeScale = 1;
        // ボタンを押せないようにする
        retryButton.interactable = false;
        titleButton.interactable = false;
    }
}
