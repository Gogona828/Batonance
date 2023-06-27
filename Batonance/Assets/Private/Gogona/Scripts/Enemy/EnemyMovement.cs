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
    // [System.NonSerialized]
    public NavMeshAgent navmesh;
    public GameObject player;
    //視野範囲にプレイヤーがいるとT、いないならF
    /* [System.NonSerialized] */
    public bool isLooking;
    private Animator animator;
    void Start()
    {
        // navmesh = this.gameObject.GetComponent<NavMeshAgent>();
        navmesh.isStopped = true;//最初は止まっている
        navmesh.SetDestination(player.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (isLooking)//プレイヤーが視野範囲にいる時
        {
            navmesh.SetDestination(player.transform.position); //追尾位置更新
            transform.LookAt(player.transform); //プレイヤーの方見る
            if (navmesh.remainingDistance <= personalSpace)
            {
                navmesh.isStopped = true;//止める
            }
            else
            {
                navmesh.isStopped = false;//動く
            }
            //animator.SetBool("Run", !navmesh.isStopped);
        }
    }

    public void GetEnemySpeed(float _spe)
    {
        speed = _spe;
        navmesh.speed = speed;
    }
}
