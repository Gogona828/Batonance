using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectController : MonoBehaviour
{
    [SerializeField, Tooltip("子オブジェクトがあるならtrue")]
    private bool existsChild = false;
    private ParticleSystem particleSystem;
    private ParticleSystem[] childSystems;

    private void Start()
    {
        // ParticleSystemがあれば取得する
        if (TryGetComponent(out ParticleSystem _particleSystem))
        {
            particleSystem = _particleSystem;
            //　StopActionに登録する
            var _main = particleSystem.main;
            _main.stopAction = ParticleSystemStopAction.Callback;
        }
        
        // 子オブジェクトのParticleSystemを取得する
        if (existsChild) childSystems = this.GetComponentsInChildren<ParticleSystem>();
        
        StopEffect();
    }

    public void PlayEffect()
    {
        /*// 子オブジェクトの ParticleSystemを再生する
        foreach (var _childSystem in childSystems)
        {
            _childSystem?.Play();
        }*/
        
        // このオブジェクトにParticleSystemがなければ終了する
        if (!particleSystem) return;
        particleSystem.Play();
    }

    private void StopEffect()
    {
        Debug.Log($"stopped {gameObject.name}");
        /*// 子オブジェクトの ParticleSystemを停止する
        foreach (var _childSystem in childSystems)
        {
            Debug.Log($"{_childSystem.name}");
            _childSystem.Stop();
            _childSystem.time = 0;
        }*/
        
        // このオブジェクトにParticleSystemがなければ終了する
        if (!particleSystem) return;
        particleSystem.Stop();
        particleSystem.time = 0;
    }

    private void OnParticleSystemStopped() => StopEffect();
}
