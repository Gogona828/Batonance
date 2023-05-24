using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField, Tooltip("攻撃力")]
    private float atkPower;
    [SerializeField]
    private Animator animator;

    public void Attack()
    {
        animator.SetTrigger("Attack");
    }

    public void GetEnemyAtk(float atk)
    {
        atkPower = atk;
    }
}