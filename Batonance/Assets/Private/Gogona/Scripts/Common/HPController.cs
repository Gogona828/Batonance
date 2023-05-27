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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    /// <summary>
    /// ダメージを受けた時に呼び出す
    /// </summary>
    /// <param name="_damage"></param>
    public void Damage(float _damage)
    {
        // ダメージ分減少
        currentHP -= _damage;
        hPBar.value = currentHP / maxHP;

        // 現在HPが0以下なら
        if (currentHP <= 0) {
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
