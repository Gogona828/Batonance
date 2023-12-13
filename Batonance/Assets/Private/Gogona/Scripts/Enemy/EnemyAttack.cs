using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField, Tooltip("攻撃力")]
    private float atkPower;
    private EnemyMovement enemyMov;
    [SerializeField, Tooltip("アニメーターの取得")]
    private Animator animator;
    [SerializeField, Tooltip("アニメーションの時間")]
    private float animationCoolTime;

    [SerializeField, Tooltip("EffectControllerを入れる")]
    private EffectController[] effectControllers;
    public bool isEnemyAttack = false;

    private void Start() => Init();

    /// <summary>
    /// 初期化をする
    /// </summary>
    private void Init()
    {
        enemyMov = GetComponent<EnemyMovement>();
    }

    public IEnumerator AttackPlayer()
    {
        yield return new WaitForSeconds(0.4f);
        animator.SetTrigger("Attack");
        yield return new WaitForSeconds(0.9f);
        foreach (var _effectController in effectControllers)
        {
            _effectController.PlayEffect();
        }
    }

    /// <summary>
    /// 攻撃力を取得する
    /// </summary>
    /// <param name="_atk"></param>
    public void GetEnemyAtk(float _atk)
    {
        atkPower = _atk;
    }
}