using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BPMShakeObject : MonoBehaviour
{
    [SerializeField]
    private Animator shakerAnimator;
    private AnimatorClipInfo[] animatorStateinfo;

    void Start()
    {
        animatorStateinfo = shakerAnimator.GetCurrentAnimatorClipInfo(0);//現在のアニメーションクリップの情報を取得 引数0はレイヤーの番号
        Debug.Log(shakerAnimator.speed);//コンソールに表示
    }

    // Update is called once per frame
    void Update()
    {
        if(shakerAnimator.speed<=5) shakerAnimator.speed++;
        Debug.Log(shakerAnimator.speed);
    }
}
