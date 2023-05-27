using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FieldView : MonoBehaviour
{
    private EnemyMovement enemyMov;
    // Start is called before the first frame update
    void Start()
    {
        enemyMov = transform.root.gameObject.GetComponent<EnemyMovement>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject==enemyMov.player)//プレイヤーが視野範囲に入ってきた時
        {
            enemyMov.isLooking = true;
            enemyMov.navmesh.isStopped = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == enemyMov.player)//プレイヤーが視野範囲からでて行った時
        {
            enemyMov.isLooking = false;
            enemyMov.navmesh.isStopped = true;
        }
    }
}
