using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : MonoBehaviour
{
    [SerializeField]
    private float damage;
    public bool isCounterAttack = false;

    private HPController hPCtrl;

    public void DefeatEnemy(int way)
    {
        EffectManager.instance.PlayEffect(way);
        SEManager.instance.PlaySE(1);
        EnemyManager.instance.enemiesQueue.Peek().GetComponent<EnemyDeathProcess>().DestroyEnemy();
    }

    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    /*private void OnTriggerEnter(Collider other)
    {
        // ダメージを与えるのがPlayerの場合
        if (gameObject.CompareTag("PlayerAttack")) {
            switch (other.gameObject.tag) {
                case "Enemy":
                    Debug.Log($"enemyだよ" + other.gameObject.name);
                    other.gameObject.GetComponent<HPController>().Damage(damage);
                    gameObject.tag = "Untagged";
                    break;
                default:
                    break;
            }
        }

        // ダメージを与えるのがEnemyの場合
        if (gameObject.CompareTag("EnemyAttack")) {
            switch (other.gameObject.tag) {
                case "Player":
                    Debug.Log($"Playerにあたったで！！" + other.gameObject.name);
                    if (other.gameObject.transform.root.gameObject.name != "Player") return;
                    other.gameObject.GetComponent<HPController>().Damage(damage);
                    gameObject.tag = "Untagged";
                    break;
                default:
                    break;
            }
        }
    }*/

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
