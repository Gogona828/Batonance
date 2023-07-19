using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System;

public class AttackSignal : MonoBehaviour
{
    // [SerializeField, Tooltip("攻撃前エフェクト")]
    // private ParticleSystem effectBeforeAttack;
    [SerializeField, Tooltip("エフェクト再生時間")]
    private int effectReproducingTime;

    // Start is called before the first frame update
    void Start()
    {
        // effectBeforeAttack.Stop();
        gameObject.GetComponent<MeshRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// 攻撃前の合図をする
    /// </summary>
    public async void MakeSignalBeforeAttack()
    {
        await ControlEffectReproducingTime();
    }

    public async UniTask ControlEffectReproducingTime()
    {
        // effectBeforeAttack.Play();
        gameObject.GetComponent<MeshRenderer>().enabled = true;
        await UniTask.Delay(effectReproducingTime);
        // effectBeforeAttack.Stop();
        gameObject.GetComponent<MeshRenderer>().enabled = false;
    }
}
