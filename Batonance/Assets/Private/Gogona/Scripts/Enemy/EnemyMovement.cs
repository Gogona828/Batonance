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
    public NavMeshAgent navmesh;
    private EnemyAttack enemyAtk;
    public GameObject player;
    //視野範囲にプレイヤーがいるとT、いないなら
    public bool isLooking;
    // 攻撃範囲内かどうか
    public bool InAttackRange() {
        if (navmesh.remainingDistance <= navmesh.stoppingDistance) return true;
        else return false;
    }
    [SerializeField, Tooltip("アニメーターの取得")]
    private Animator animator;
    [SerializeField]
    private float minVelocity;
    private bool isWalk;
    private float latePos;
    private float velocity;

    void Start()
    {
        enemyAtk = GetComponent<EnemyAttack>();
        isWalk = true;
    }

    private void FixedUpdate()
    {
        transform.position += new Vector3(0, 0, -speed);
    }

    /// <summary>
    /// 移動速度を取得する
    /// </summary>
    /// <param name="_spe"></param>
    public void GetEnemySpeed(float _spe)
    {
        speed = _spe;
    }
}
