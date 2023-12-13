using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HPController))]
public class EnemyBase : MonoBehaviour
{
    [SerializeField, Tooltip("キャラクタのID")]
    private int charId;
    private EnemyDataBase.EnemyData data;

    // 各クラスの取得
    private HPController hPCtrl;
    private EnemyAttack enemyAtk;
    private EnemyMovement enemyMov;
    private float aliveTime = 0;

    // Start is called before the first frame update
    void Start() => Init();

    /// <summary>
    /// 初期化をする
    /// </summary>
    private void Init()
    {
        // データベースからキャラデータを取得
        data = DataBaseManager.instance.GetEnemyData(charId);
        GetClassData();
        hPCtrl.GetCharHP(data.baseHP);
        enemyAtk.GetEnemyAtk(data.baseAtk);
        enemyMov.GetEnemySpeed(data.baseSpd);
        EnemyManager.instance.enemiesQueue.Enqueue(gameObject);
        enemyAtk.StartCoroutine("AttackPlayer");
    }

    private void Update()
    {
        transform.LookAt(AdministerGameState.instance.GetPlayerPosition());
    }

    /// <summary>
    /// 各クラスのデータを取得
    /// </summary>
    private void GetClassData()
    {
        hPCtrl = GetComponent<HPController>();
        enemyAtk = GetComponent<EnemyAttack>();
        enemyMov = GetComponent<EnemyMovement>();
    }
}
