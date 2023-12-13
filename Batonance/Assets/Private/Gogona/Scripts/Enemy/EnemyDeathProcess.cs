using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathProcess : MonoBehaviour
{
    [SerializeField, Tooltip("敵のアニメーター")] private Animator animator;

    private EnemyMovement enemyMovement;

    private void Start()
    {
        enemyMovement = GetComponent<EnemyMovement>();
    }

    public void DestroyEnemy()
    {
        gameObject.tag = "Untagged";
        Debug.Log($"enemy tag : {gameObject.tag}");
        animator.SetTrigger("Dead");
        Destroy(EnemyManager.instance.enemiesQueue.Dequeue(), 1);
    }
}
