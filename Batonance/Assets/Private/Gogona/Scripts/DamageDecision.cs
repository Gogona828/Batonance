using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDecision : MonoBehaviour
{
    [SerializeField, Tooltip("攻撃力の参照")]
    private PlayerAttack playerAtk;
    // PlayerのHP
    private IDamagable playerHP;
    // EnemyのHP
    private IDamagable enemyHP;

    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"相手の情報\n名前：" + other.name + "\nタグ：" + other.tag);
        // 相手が敵なら
        if (other.gameObject.CompareTag("Enemy")) {
            Debug.Log($"i attacked enemy");
            enemyHP = other.GetComponent<IDamagable>();
            Debug.Log($"エネミー：" + enemyHP);
            DamageManager.instance.DamageCalculation(playerAtk.attackPower, enemyHP);
            /* SpecialAttackGauge.instance.AddGaugePoint(3); */
        }
        else if (other.gameObject.CompareTag("Player")) {
            playerHP = other.GetComponent<IDamagable>();
            DamageManager.instance.DamageCalculation(playerAtk.attackPower, playerHP);
        }
    }
}
