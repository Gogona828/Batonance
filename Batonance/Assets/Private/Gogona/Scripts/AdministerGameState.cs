using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdministerGameState : MonoBehaviour
{
    [SerializeField, Tooltip("Playerの位置")]
    private Transform playerPosition;
    [SerializeField, Tooltip("ShowGameOverを入れる")]
    private ShowGameOver showGameOver;
    [SerializeField, Tooltip("ShowGameClearを入れる")]
    private ShowGameClear showGameClear;
    [SerializeField, Tooltip("Game OverのButtonControllerを入れる")]
    private ButtonController overbuttonController;
    [SerializeField, Tooltip("Game ClearのButtonControllerを入れる")]
    private ButtonController clearbuttonController;
    [SerializeField, Tooltip("デバック用")]
    private bool hasOveredGame = false;
    
    // シングルトン用のインスタンス変数
    public static AdministerGameState instance;

    /// <summary>
    /// シングルトン化する
    /// </summary>
    private void Awake()
    {
        if (!instance) instance = this;
        else Destroy(this);
    }
    
    /// <summary>
    /// Playerの位置を取得する
    /// </summary>
    /// <returns></returns>
    public Transform GetPlayerPosition()
    {
        return playerPosition;
    }

    /// <summary>
    /// ゲームクリア処理を実行する
    /// </summary>
    public void GameClear()
    {
        Time.timeScale = 0;
        showGameClear.ShowClearUI();
        clearbuttonController.canSelectButton = true;
    }

    /// <summary>
    /// ゲームオーバー処理を実行する
    /// </summary>
    public void GameOver()
    {
        Time.timeScale = 0;
        BGMManager.instance.StopBGM();
        EnemyManager.instance.ClearEnemiesQueue();
        showGameOver.ShowUI();
        overbuttonController.canSelectButton = true;
    }

    public void GameStart()
    {
        Time.timeScale = 1;
        showGameOver.HideUI();
        showGameClear.HideClearUI();
        overbuttonController.canSelectButton = false;
    }
}
