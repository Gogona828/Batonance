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

    // NotsManagerの取得
    [SerializeField]
    private NotesManager notesManager;
    // ノーツの位置データ
    private Queue<(int lane, float time)> notesPositionData = new Queue<(int lane, float time)>();
    [SerializeField]
    private const float delayTime = 4;
    [SerializeField, Tooltip("いずれはBGMManagerからの参照か何かにしたい")]
    private int bpm = 180;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    private void Awake() => Initialize();
    
    private void Initialize()
    {
        if (!instance) {
            instance = this;
        }
        else {
            Destroy(this);
        }
    }

    public void PrepareGeneration(int count)
    {
        // TODO: CreateEnemyをする
        if (notesPositionData.Count == 0) return;
        if (notesPositionData.Peek().time != count) return;
        CreateEnemy(notesPositionData.Dequeue().lane);
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
    private void CreateEnemy(int popPosition)
    {
        enemyTypesRndNum = Random.Range(0, enemyTypes.Length);
        // MEMO: popPositionの値が入れば下は無視する予定
        /* spawnPointsRndNum = Random.Range(0, spawnPoints.Length);
        Instantiate(enemyTypes[enemyTypesRndNum], spawnPoints[spawnPointsRndNum].transform.position,
            Quaternion.identity); */
        Instantiate(enemyTypes[enemyTypesRndNum], spawnPoints[popPosition].transform.position,
             Quaternion.identity);
    }

    public void GetNotesList(List<(int _lane, float _time)> _notesList)
    {
        (int, float) _temporaryNotes;
    
        // Debug.Log($"default time: {_notesList[0]._time}");
        
        // 生成タイミングをずらす
        for (int i = 0; i < _notesList.Count; i++) {
            _temporaryNotes = (_notesList[i]._lane, _notesList[i]._time * (bpm / 60) - delayTime);
            notesPositionData.Enqueue(_temporaryNotes);
        }
        // Debug.Log($"fixed time: {notesPositionData.Peek().time}");
    }
}
