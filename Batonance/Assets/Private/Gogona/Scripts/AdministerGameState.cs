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

    private void Update()
    {
        if (hasOveredGame)　{
            ExecuteGameOverProcess();
        }
    }

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
    /// ゲームオーバー処理を実行する
    /// </summary>
    public void ExecuteGameOverProcess()
    {
        showGameOver.ShowUI();
    }
}
