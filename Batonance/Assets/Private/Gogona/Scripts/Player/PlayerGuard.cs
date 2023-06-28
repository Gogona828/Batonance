using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System;

public class PlayerGuard : MonoBehaviour
{
    [Header("ガード関連")]
    [SerializeField, Tooltip("防御力")]
    private float defensePower;
    [SerializeField, Tooltip("ガードオブジェクト")]
    private GameObject guard;
    [SerializeField, Tooltip("ガード中かどうか")]
    public bool isGuard;

    [Header("アニメーション")]
    [SerializeField, Tooltip("ガードのアニメーション")]
    private Animator animator;

    [Header("パリィ関連")]
    // CounterAttackの参照
    private CounterAttack counterAtk;
    [Tooltip("パリィ回数")]
    public int parryTimes = 0;
    [Tooltip("パリィの上限")]
    public int parryMax = 3;
    [SerializeField, Tooltip("Justの適応時間")]
    private float justAdaptationTime = 0.2f;
    /* [SerializeField, Tooltip("パリィ状態かどうか")]
    private bool isParryState; */
    // Justタイム時に適用される
    private int latency = 0;
    
    /* [SerializeField, Tooltip("パリィのクールタイム")]
    private float parryCoolTime = 0.2f; */

    // Start is called before the first frame update
    void Start()
    {
        guard.SetActive(false);
        latency = (int)Math.Floor(justAdaptationTime * 1000);
        counterAtk = GetComponent<CounterAttack>();
    }

    // Update is called once per frame
    async void Update()
    {
        if (Input.GetKey(KeyCode.Space) || Input.GetButton("SquareButton")) {
            await Guard();
        }
        else {
            isGuard = false;
            guard.SetActive(false);
        }
    }

    private async UniTask Guard()
    {
        isGuard = true;
        // animator.SetTrigger("Defence");
        guard.SetActive(true);

        // レイヤーを"Just"に変更
        gameObject.layer = 6;
        await UniTask.Delay(latency);
        // レイヤーを"Default"に変更
        gameObject.layer = 0;
    }

    public float DamageDecrease(float _damage)
    {
        _damage -= defensePower;
        return _damage;
    }

    public void GetPlayerGuard(float _def)
    {
        defensePower = _def;
    }
}
