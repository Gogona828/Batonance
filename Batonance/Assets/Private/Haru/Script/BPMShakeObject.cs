using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BPMShakeObject : MonoBehaviour
{
    [SerializeField]
    private Animator shakerAnimator;
    [SerializeField]
    private int objectBPM;//スピードが1の場合のBPM
    public float songBPM;

    void Start()
    {
        Debug.Log(shakerAnimator.speed);//コンソールに表示
    }

    // Update is called once per frame
    void Update()
    {
        shakerAnimator.speed = songBPM/120;
        Debug.Log(shakerAnimator.speed);
    }
    public void BPMSwitching(float bpm)
    {
        songBPM = bpm;
    }
}
