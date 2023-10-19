using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cysharp.Threading.Tasks;
using System;
using Random = UnityEngine.Random;

public class EnemyManager : MonoBehaviour
{
    [Tooltip("Enemyリスト")]
    public List<GameObject> enemiesList = new List<GameObject>();

    public static EnemyManager instance;
    
    [SerializeField, Tooltip("敵のスポーン位置")]
    private GameObject[] spawnPoints;

    [SerializeField, Tooltip("Enemyの種類")]
    private GameObject[] enemyTypes;

    // Enemyの種類の乱数
    private int enemyTypesRndNum;
    // スポーン位置の乱数
    private int spawnPointsRndNum;
    
    /// <summary>
    /// Awake is called when the script instance is being loaded.
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
    /// enemiesListの中身を減らす
    /// </summary>
    /// <param name="_enemy"></param>
    public async void DecreaseEnemy(GameObject _enemy)
    {
        for (int i = 0; i < enemiesList.Count; i++) {
            if (enemiesList[i] == _enemy) {
                enemiesList.RemoveAt(i);
            }
        }
        await DoGameEndJudgement();
    }

    /// <summary>
    /// ゲームが終了するかどうかを判定
    /// </summary>
    private async UniTask DoGameEndJudgement()
    {
        if (enemiesList.Count != 0) return;
        
        await UniTask.Delay(500);
        // SceneManager.LoadScene("EndScene");
    }

    /// <summary>
    /// 敵の種類、出現位置をランダムに生成
    /// </summary>
    /// <param name="popPosition"></param>
    public void CreateEnemy(int popPosition)
    {
        enemyTypesRndNum = Random.Range(0, enemyTypes.Length);
        // MEMO: popPositionの値が入れば下は無視する予定
        /* spawnPointsRndNum = Random.Range(0, spawnPoints.Length);
        Instantiate(enemyTypes[enemyTypesRndNum], spawnPoints[spawnPointsRndNum].transform.position,
            Quaternion.identity); */
        Instantiate(enemyTypes[enemyTypesRndNum], spawnPoints[popPosition].transform.position,
             Quaternion.identity);
    }
}
