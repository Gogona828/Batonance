using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowGameClear : MonoBehaviour
{
    [SerializeField, Tooltip("RetryButtonを入れる")]
    private Button retryButton;
    [SerializeField, Tooltip("BackToTitleButtonを入れる")]
    private Button titleButton;

    [SerializeField, Tooltip("GameOverUIを入れる")]
    private GameObject gameOverUI;
    private CanvasGroup gameClearUI;

    void Start()
    {
        Time.timeScale = 1;
        gameClearUI = GetComponent<CanvasGroup>();
        // ゲームオーバーUIを非表示にする
        HideClearUI();
    }
    
    /// <summary>
    /// ゲームオーバーUIを表示する
    /// </summary>
    public void ShowClearUI()
    {
        Debug.Log($"show ui");
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
        if (!gameClearUI) return;
        gameClearUI.alpha = 0;
        Time.timeScale = 1;
        // ボタンを押せないようにする
        retryButton.interactable = false;
        titleButton.interactable = false;
    }
}
