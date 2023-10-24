using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
// 別スクリプトからエフェクトを再生する例
int effectIndex = 0; // 再生したいエフェクトのインデックス
GetComponent<EffectManager>().PlayEffect(effectIndex);
*/

public class EfectManager : MonoBehaviour
{
    public List<GameObject> effectList = new List<GameObject>();

    // エフェクトを再生するための関数
    public void PlayEffect(int index)
    {
        if (index >= 0 && index < effectList.Count)
        {
            GameObject effect = Instantiate(effectList[index]);
            // ここでエフェクトの位置や他のパラメータを設定できます
            // 例: effect.transform.position = transform.position;
        }
        else
        {
            Debug.LogError("Invalid index for effect.");
        }
    }
}
