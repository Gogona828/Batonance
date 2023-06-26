using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System;

public class CounterAttack : MonoBehaviour
{
    [SerializeField, Tooltip("Batonanceの参照")]
    private MeshRenderer batonance;
    [SerializeField, Tooltip("カウンターレベルの色")]
    private Material[] mat;
    [SerializeField, Tooltip("カウンターの攻撃力"), Header("カウンター関連")]
    private float counterAttackPower;
    /* [SerializeField, Tooltip("カウンターのアニメーション")]
    private Animator animator; */

    // PlayerAttackの参照
    private PlayerAttack playerAtk;
    // PlayerGuardの参照
    private PlayerGuard playerDef;
    // DealDamageの参照
    private DealDamage dealDamage;

    // Start is called before the first frame update
    void Start()
    {
        playerAtk = GetComponent<PlayerAttack>();
        playerDef = GetComponent<PlayerGuard>();
        dealDamage = GetComponent<DealDamage>();
    }

    // Update is called once per frame
    void Update()
    {
        // Eキーでカウンター
        if ((Input.GetKeyDown(KeyCode.E) || Input.GetButtonDown("TriangleButton")) && playerDef.parryTimes != 0) {
            Counter(playerDef.parryTimes);
        };
    }

    /// <summary>
    /// カウンターレベルを加算する
    /// </summary>
    /// <param name="_counterLevel"></param>
    public void AddCounterLevel(int _counterLevel)
    {
        // パリィ上限が来たらリターン
        if (_counterLevel > playerDef.parryMax - 1) return;
        Debug.Log($"パリィ");
        _counterLevel++;
        batonance.material = mat[_counterLevel - 1];
    }

    /// <summary>
    /// カウンターアクション
    /// </summary>
    /// <param name="_counterLevel"></param>
    public void Counter(int _counterLevel)
    {
        // 攻撃力をカウンターレベルに応じて上昇させる
        counterAttackPower = (int)Math.Floor(Math.Pow(_counterLevel, 2) * playerAtk.attackPower);
        // 与えるダメージ量を変更
        dealDamage.SetAttackPower(counterAttackPower);
        playerDef.parryTimes = 0;
    }
}
