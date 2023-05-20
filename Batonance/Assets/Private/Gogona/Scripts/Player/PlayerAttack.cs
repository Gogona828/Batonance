using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System;

public class PlayerAttack : MonoBehaviour
{
    [Tooltip("攻撃力")]
    public float attackPower = 2.0f;
    [SerializeField, Tooltip("クールタイム")]
    private float coolTime = 0.1f;
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
    /* [SerializeField, Tooltip("斬撃エフェクト")]
    private List<ParticleSystem> effectList = new List<ParticleSystem>(); */
    /* [SerializeField, Tooltip("斬撃SE")]
    private List<AudioClip> attackSEList = new List<AudioClip>();
    private AudioSource audioSource; */

    [SerializeField, Header("デバック用")]
    private bool canAttack = true;

    // Start is called before the first frame update
    void Start()
    {
        /* for (int i = 0; i < effectList.Count; i++) {
            effectList[i].Stop();
            effectList[i].gameObject.GetComponent<BoxCollider>().enabled = false;
        }
        //Componentを取得
        audioSource = GetComponent<AudioSource>(); */
    }

    // Update is called once per frame
    void Update()
    {
        // 通常状態でないとリターン
        /* if (!StateManager.instance.isNormalMode) return; */
        time += Time.deltaTime;
        // 攻撃をする
        if (time >= coolTime && Input.GetMouseButtonDown(0) && canAttack) {
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
        // 最大コンボ数なら攻撃を中断
        if (comboCount == maxComboNumber) return;
        animator.SetTrigger("Attack");
        /* await AttackEffect(comboCount);
        await AttackSE(comboCount); */
        
        // コンボカウントを足す
        comboCount++;

        // コンボが続くかを判定
        Debug.Log(time);
        if (time <= timeContinueCombo && comboCount > 1) {
            await Combo();
        }
        
        time = 0;
    }

    /// <summary>
    /// コンボの処理
    /// </summary>
    public async UniTask Combo()
    {
        Debug.Log($"コンボ数：" + comboCount);

        // 最大コンボ数に到達した時
        if (comboCount == maxComboNumber) {
            Debug.Log("最大コンボ！！");
            canAttack = false;

            // 最後のコンボのクールタイム
            await UniTask.Delay(TimeSpan.FromSeconds(comboEndCoolTime));

            canAttack = true;
            comboCount = 0;
        }
    }

    /* /// <summary>
    /// エフェクト操作
    /// </summary>
    /// <param name="effectNumber"></param>
    /// <returns></returns>
    private async UniTask AttackEffect(int effectNumber)
    {
        effectList[effectNumber].Play();
        effectList[effectNumber].gameObject.GetComponent<BoxCollider>().enabled = true;
        await UniTask.Delay(TimeSpan.FromSeconds(effectList[effectNumber].startLifetime + effectList[effectNumber].startDelay));
        effectList[effectNumber].Stop();
        effectList[effectNumber].gameObject.GetComponent<BoxCollider>().enabled = false;
    }

    private async UniTask AttackSE(int sENumber)
    {
        await UniTask.Delay(TimeSpan.FromSeconds(effectList[sENumber].startDelay));
        audioSource.PlayOneShot(attackSEList[sENumber]);
    } */

    public void GetPlayerAttackPower(float _atkPower)
    {
        attackPower = _atkPower;
    }
}
