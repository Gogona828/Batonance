using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : MonoBehaviour
{
    [SerializeField]
    private float damage;

    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Deal damage for " + other.gameObject.name);
        // 自分と同じタグならリターン
        if (gameObject.tag == other.gameObject.tag) return;

        // 相手にHPControllerが付いていたらダメージを与える。
        if (other.gameObject.TryGetComponent(out HPController hPCtrl)) {
            hPCtrl.Damage(damage);
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
