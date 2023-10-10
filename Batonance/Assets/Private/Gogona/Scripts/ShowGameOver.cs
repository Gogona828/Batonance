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
    }
    
    /// <summary>
    /// ゲームオーバーUIを非表示にする
    /// </summary>
    void HideUI()
    {
        gameOverUI.alpha = 0;
        // ボタンを押せるようにする
        retryButton.interactable = false;
        giveUpButton.interactable = false;
    }
}