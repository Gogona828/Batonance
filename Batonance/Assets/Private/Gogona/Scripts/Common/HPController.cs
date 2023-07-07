using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPController : MonoBehaviour, IDamagable
{
    [SerializeField, Tooltip("最大HP")]
    private float maxHP;
    [SerializeField, Tooltip("現在HP")]
    private float currentHP;
    [SerializeField, Tooltip("HPバー")]
    private Slider hPBar;

    private PlayerGuard playerDef;
    private CounterAttack counterAtk;

    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.CompareTag("Player")) {
            playerDef = GetComponent<PlayerGuard>();
            counterAtk = GetComponent<CounterAttack>();
        }
    }

    /// <summary>
    /// ダメージを受けた時に呼び出す
    /// </summary>
    /// <param name="_damage"></param>
    public void Damage(float _damage)
    {
        if (gameObject.layer == 6 && playerDef.isGuard) {
            counterAtk.AddCounterLevel(playerDef.parryTimes);
            return;
        }
        else if (gameObject.CompareTag("Player") && playerDef.isGuard) {
            _damage = playerDef.DamageDecrease(_damage);
        }
        // ダメージ分減少
        currentHP -= _damage;
        hPBar.value = currentHP / maxHP;

        // 現在HPが0以下なら
        if (currentHP <= 0) {
            if (gameObject.CompareTag("Player")) return;
            else {
                EnemyManager.instance.DecreaseEnemy(gameObject);
            }
            // ゲームオブジェクトを破壊
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// HPの取得
    /// </summary>
    /// <param name="hP"></param>
    public void GetCharHP(float hP)
    {
        maxHP = hP;
        // 現在HPを最大HPにする
        currentHP = maxHP;
        hPBar.value = currentHP / maxHP;
    }
}
