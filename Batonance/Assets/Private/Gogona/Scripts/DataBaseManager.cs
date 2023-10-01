using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataBaseManager : MonoBehaviour
{
    [SerializeField, Tooltip("PlayerDataBaseの参照")]
    private PlayerDataBase playerDB;
    [SerializeField, Tooltip("EnemyDataBaseの参照")]
    private EnemyDataBase enemyDB;
    // DataManagerのインスタンス
    public static DataBaseManager instance;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {
        // インスタンスの生成
        if (instance == null) {
            instance = this;
        }
        // すでにあれば削除
        else {
            Destroy(gameObject);
        }
    }

    public PlayerDataBase GetPlayerData()
    {
        return playerDB;
    }

    /// <summary>
    /// データの取得
    /// </summary>
    /// <param name="enemyId"></param>
    /// <returns></returns>
    public EnemyDataBase.EnemyData GetEnemyData(int enemyId)
    {
        // データベース内からそのキャラのIDを探す
        foreach (EnemyDataBase.EnemyData data in enemyDB.enemyDatas)
        {
            if (data.id == enemyId) {
                return data;
            }
        }
        return null;
    }
}
