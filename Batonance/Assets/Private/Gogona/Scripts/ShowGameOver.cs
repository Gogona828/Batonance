using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowGameOver : MonoBehaviour
{
    [SerializeField, Tooltip("RetryButtonを入れる")]
    private Button retryButton;
    [SerializeField, Tooltip("GiveUpButtonを入れる")]
    private Button giveUpButton;
    private CanvasGroup gameOverUI;

    void Start()
    {
        Time.timeScale = 1;
        gameOverUI = GetComponent<CanvasGroup>();
        // ゲームオーバーUIを非表示にする
        HideUI();
    }
    
    /// <summary>
    /// ゲームオーバーUIを表示する
    /// </summary>
    public void ShowUI()
    {
        gameOverUI.alpha = 1;
        // ボタンを押せなくする
        retryButton.interactable = true;
        giveUpButton.interactable = true;
        Time.timeScale = 0;
    }
    
    /// <summary>
    /// ゲームオーバーUIを非表示にする
    /// </summary>
    public void HideUI()
    {
        gameOverUI.alpha = 0;
        Time.timeScale = 1;
        // ボタンを押せるようにする
        retryButton.interactable = false;
        giveUpButton.interactable = false;
    }
}