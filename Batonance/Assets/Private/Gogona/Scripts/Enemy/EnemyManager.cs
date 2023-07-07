using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyManager : MonoBehaviour
{
    [Tooltip("Enemyリスト")]
    public List<GameObject> enemiesList = new List<GameObject>();

    public static EnemyManager instance;
    
    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {
        if (instance == null) {
            instance = this;
        }
        else {
            Destroy(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    /// <summary>
    /// enemiesListの中身を減らす
    /// </summary>
    /// <param name="_enemy"></param>
    public void DecreaseEnemy(GameObject _enemy)
    {
        for (int i = 0; i < enemiesList.Count; i++) {
            if (enemiesList[i] == _enemy) {
                enemiesList.RemoveAt(i);
            }
        }
        DoGameEndJudgement();
    }

    /// <summary>
    /// ゲームが終了するかどうかを判定
    /// </summary>
    public void DoGameEndJudgement()
    {
        if (enemiesList.Count != 0) return;
        SceneManager.LoadScene("EndScene");
    }
}
