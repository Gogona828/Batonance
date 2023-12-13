using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/*
// 別スクリプトからエフェクトを再生する例
int effectIndex = 0; // 再生したいエフェクトのインデックス
GetComponent<EffectManager>().PlayEffect(effectIndex);
*/

public class EffectManager : MonoBehaviour
{
    public static EffectManager instance;
    public List<GameObject> effectList = new List<GameObject>();

    private void Awake()
    {
        if (!instance) instance = this;
        else Destroy(this);
    }

    // エフェクトを再生するための関数
    public void PlayEffect(int index)
    {
        if (index >= 0 && index < effectList.Count)
        {
            if (index == 1) Debug.Log($"one");
            // EffectControllerがあれば再生する
            effectList[index].GetComponent<EffectController>()?.PlayEffect();
            
            // ここでエフェクトの位置や他のパラメータを設定できます
            // 例: effect.transform.position = transform.position;
        }
        else
        {
            Debug.LogError("Invalid index for effect.");
        }
    }
}
