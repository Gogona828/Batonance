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
        //if (Input.GetKeyDown(KeyCode.I)) AudioSpectrumControl.instance.TurningSpectrum(0);//デバック用、左に傾ける
        //if (Input.GetKeyDown(KeyCode.N)) AudioSpectrumControl.instance.TurningSpectrum(1);//デバック用、真ん中にする
        //if (Input.GetKeyDown(KeyCode.S)) AudioSpectrumControl.instance.TurningSpectrum(2);//デバック用、右に傾ける
    }
    public void BPMSwitching(float bpm)
    {
        songBPM = bpm;
    }
}
