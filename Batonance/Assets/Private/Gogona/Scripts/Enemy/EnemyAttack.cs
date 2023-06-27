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
    [SerializeField]
    private Animator animator;
    [SerializeField, Tooltip("アニメーションの時間")]
    private float animationCoolTime;

    private void Start()
    {
        dealDamage.gameObject.tag = "Enemy";
    }

    public async void Attack()
    {
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
    }
}