using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System;

public class PlayerAttack : MonoBehaviour
{
    [Tooltip("攻撃力")]
    public float attackPower = 0f;
    [SerializeField, Tooltip("クールタイム")]
    private float coolTime = 0.1f;
    [SerializeField, Tooltip("DealDamageの参照")]
    private DealDamage dealDamage;

    [Header("コンボ関連")]
    [SerializeField, Tooltip("コンボ終わりのクールタイム")]
    private float comboEndCoolTime = 1.0f;
    [SerializeField, Tooltip("コンボが継続する時間")]
    private float timeContinueCombo = 1.0f;
    [SerializeField, Tooltip("コンボ数")]
    private int comboCount = 0;
    [SerializeField, Tooltip("最大コンボ数")]
    private int maxComboNumber = 3;
    private float time = 0;
    [SerializeField]
    private Animator animator;
    [SerializeField, Tooltip("アニメーションの時間")]
    private float[] animationCoolTime;
    [SerializeField, Tooltip("斬撃エフェクト")]
    private GameObject slashEffect;
    [SerializeField, Tooltip("エフェクト生成位置")]
    private Transform effectGenerationPosition;

    //ノーツ判定
    private NotesInputCompare notesInputCompare;

    public bool isAttack;

    // Start is called before the first frame update
    void Start()
    {
        dealDamage.gameObject.tag = "Player";
        isAttack = false;

        //ノーツ判定
        notesInputCompare = GameObject.Find("NotesManager").GetComponent<NotesInputCompare>();
    }

    // Update is called once per frame
    void Update()
    {
        // 通常状態でないとリターン
        time += Time.deltaTime;
        // 攻撃をする
        if (time >= coolTime && (Input.GetMouseButtonDown(0) || Input.GetButtonDown("TriangleButton")) && !isAttack) {
            Attack();
        }
        // コンボをしなかったらcomboCountを0にする
        if (time > timeContinueCombo) {
            comboCount = 0;
        }
    }

    /// <summary>
    /// 攻撃の処理
    /// </summary>
    public async void Attack()
    {
        isAttack = true;
        // 最大コンボ数なら攻撃を中断
        if (comboCount == maxComboNumber) return;

        // 攻撃アニメーションの再生
        animator.SetTrigger("Attack");

        // コンボが続くかを判定
        if (time <= timeContinueCombo && comboCount > 0) {
            await Combo();
        }
        
        time = 0;
        isAttack = false;
    }

    public void GetPlayerAttackPower(float _atkPower)
    {
        // attackPowerに攻撃力を代入
        attackPower = _atkPower;
        // DealDamageに攻撃力を渡す
        dealDamage.SetAttackPower(attackPower);
    }
}
