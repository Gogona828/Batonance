using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField, Tooltip("攻撃力")]
    private float atkPower;
    [SerializeField, Tooltip("DealDamageの参照")]
    private DealDamage dealDamage;
    private EnemyMovement enemyMov;
    [SerializeField]
    private Animator animator;
    [SerializeField, Tooltip("アニメーションの時間")]
    private float animationCoolTime;
    public bool isEnemyAttack = false;
    [SerializeField]
    private bool inAttackRange = false;

    private void Start()
    {
        dealDamage.gameObject.tag = "Enemy";
        enemyMov = GetComponent<EnemyMovement>();
    }

    public async void AttackSignal()
    {
        // 視野範囲に入ってなかったらリターン
        inAttackRange = enemyMov.InAttackRange();
        if (!enemyMov.isLooking) return;
        if (!inAttackRange) return;
        isEnemyAttack = true;
        animator.SetTrigger("Attack");
        await AttackTagSwitching();
    }

    public void GetEnemyAtk(float _atk)
    {
        atkPower = _atk;
        dealDamage.SetAttackPower(atkPower);
    }

    public async UniTask AttackTagSwitching()
    {
        dealDamage.gameObject.tag = "EnemyAttack";
        await UniTask.Delay(TimeSpan.FromSeconds(animationCoolTime));
        dealDamage.gameObject.tag = "Enemy";
        isEnemyAttack = false;
    }
}