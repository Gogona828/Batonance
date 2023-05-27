using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : MonoBehaviour
{
    [SerializeField]
    private float damage;

    private HPController hPCtrl;

    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Deal damage for " + other.gameObject.name);

        // ダメージを与えるのがPlayerの場合
        if (gameObject.CompareTag("Player")) {
            if (other.gameObject.CompareTag("Enemy")) {
                hPCtrl = other.gameObject.GetComponent<HPController>();
                hPCtrl.Damage(damage);
            }
        }

        // ダメージを与えるのがEnemyの場合
        if (gameObject.CompareTag("Enemy")) {
            if (other.gameObject.CompareTag("Player")) {
                hPCtrl = other.gameObject.GetComponent<HPController>();
                hPCtrl.Damage(damage);
            }
        }
    }

    /// <summary>
    /// 与えるダメージを設定する
    /// </summary>
    /// <param name="_damage"></param>
    public void SetAttackPower(float _damage)
    {
        // 与えるダメージを代入
        damage = _damage;
    }
}
