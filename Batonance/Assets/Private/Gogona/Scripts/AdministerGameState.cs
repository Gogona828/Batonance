using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdministerGameState : MonoBehaviour
{
    [SerializeField, Tooltip("ShowGameOverを入れる")]
    private ShowGameOver showGameOver;
    [SerializeField, Tooltip("デバック用")]
    private bool hasOveredGame = false;
    
    // シングルトン用のインスタンス変数
    public static AdministerGameState instance;

    /// <summary>
    /// シングルトン化する
    /// </summary>
    private void Awake()
    {
        if (!instance) {
            instance = this;
        }
        else {
            Destroy(this);
        }
    }

    /// <summary>
    /// ゲームクリア処理を実行する
    /// </summary>
    public void GameClear()
    {
        // TODO: ゲームクリアに呼び出されるものを書く。
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
    }

    public void GameStart()
    {
        Time.timeScale = 1;
        showGameOver.HideUI();
    }
}
