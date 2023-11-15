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
    [SerializeField, Tooltip("アニメーターの取得")]
    private Animator animator;
    [SerializeField, Tooltip("アニメーションの時間")]
    private float animationCoolTime;
    public bool isEnemyAttack = false;
    [SerializeField, Tooltip("攻撃範囲に入っているかどうか")]
    private bool inAttackRange = false;

    private void Start() => Init();

    /// <summary>
    /// 初期化をする
    /// </summary>
    private void Init()
    {
        dealDamage.gameObject.tag = "Enemy";
        enemyMov = GetComponent<EnemyMovement>();
    }

    /// <summary>
    /// 攻撃シグナルが呼ばれたら攻撃をする
    /// </summary>
    /// <returns></returns>
    public async void AttackSignal()
    {
        if (!enemyMov.isLooking) return;
        if (!inAttackRange) return;
        isEnemyAttack = true;
        animator.SetTrigger("Attack");
        await AttackTagSwitching();
    }

    /// <summary>
    /// 攻撃時にだけ攻撃判定を持たせる
    /// </summary>
    /// <returns></returns>
    public async UniTask AttackTagSwitching()
    {
        dealDamage.gameObject.tag = "EnemyAttack";
        // アニメーションの時間分待機
        await UniTask.Delay(TimeSpan.FromSeconds(animator.GetCurrentAnimatorStateInfo(0).length - 1/60));
        dealDamage.gameObject.tag = "Untagged";
        isEnemyAttack = false;
    }

    /// <summary>
    /// 攻撃力を取得する
    /// </summary>
    /// <param name="_atk"></param>
    public void GetEnemyAtk(float _atk)
    {
        atkPower = _atk;
        dealDamage.SetAttackPower(atkPower);
    }
}