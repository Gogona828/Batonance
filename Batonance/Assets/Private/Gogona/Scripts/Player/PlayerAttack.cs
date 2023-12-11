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
    
    private float time = 0;
    [SerializeField]
    private Animator animator;
    [SerializeField, Tooltip("アニメーションの時間")]
    private float[] animationCoolTime;

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
    }

    /// <summary>
    /// 攻撃の処理
    /// </summary>
    public async void Attack()
    {
        isAttack = true;
        
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
