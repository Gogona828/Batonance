using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
// SEを再生する例
int seIndex = 1; // 再生したいSEのインデックス
GetComponent<SEManager>().PlaySE(seIndex);
*/
public class SEManager : MonoBehaviour
{
    public List<AudioClip> seList = new List<AudioClip>();
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // SEを再生するための関数
    public void PlaySE(int index)
    {
        if (index >= 0 && index < seList.Count)
        {
            audioSource.PlayOneShot(seList[index]);
        }
        else
        {
            Debug.LogError("Invalid index for SE.");
        }
    }
}
