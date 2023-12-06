using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    //エネミーの移動スピード
    [SerializeField]
    private float speed;
    //エネミーがプレイヤーを追いかける限界の距離
    [SerializeField]
    private float personalSpace;
    private EnemyAttack enemyAtk;
    public GameObject player;
    //視野範囲にプレイヤーがいるとT、いないなら
    public bool isLooking;

    [SerializeField, Tooltip("アニメーターの取得")]
    private Animator animator;
    [SerializeField]
    private float minVelocity;
    private bool isWalk;
    private float latePos;
    private float velocity;
    private float oneBeat;

    void Start()
    {
        enemyAtk = GetComponent<EnemyAttack>();
        isWalk = true;
    }

    private void FixedUpdate()
    {
        transform.position += new Vector3(0, 0, -speed) * Time.deltaTime;
    }

    private void EnemyMoveSpeed()
    {
        
    }

    /// <summary>
    /// 移動速度を取得する
    /// </summary>
    /// <param name="_spe"></param>
    public void GetEnemySpeed(float _spe)
    {
        float bpm = 180;
        // TODO: Enemyの移動速度を決める
        // 1拍の計算
        oneBeat = 60 / bpm;
        // 何拍遅れで近づいてくるか（_speが拍数）
        speed = 4 / (oneBeat * _spe);
        Debug.Log($"speed: {speed}");
    }
}
