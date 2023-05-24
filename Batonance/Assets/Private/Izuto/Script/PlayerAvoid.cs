using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAvoid : MonoBehaviour
{
    [SerializeField] private float avoidDistance = 5f; // 回避距離
    [SerializeField] private float avoidSpeed = 10f; // 回避速度
    private Vector3 avoidDirection = Vector3.zero;
    bool canDodge = true;
    private Vector3 moveDirection;
    [SerializeField]
    private PlayerMovement moveScript;
    [SerializeField]
    private Animator animator;
    void Start()
    {
        // animator = moveScript.animator;
    }
    void Update()
    {
         //WASDキーで移動方向を取得
        moveDirection = moveScript.facingReinforcement;

        // Shiftキーを押したときの処理
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDodge)
        {
            animator.SetTrigger("Avoidance");
            avoidDirection = moveDirection.normalized; // .normalizedでベクトルを正規化し方向のみ取得
            StartCoroutine(Dodge());
        }
    }

    IEnumerator Dodge()// 回避後の移動
    {
        Debug.Log("Avoid");
        float avoidTime = 0f;
        float justDodge = 0.2f;
        float dodgeCoolTime = 0.1f;
        canDodge = false;
        gameObject.tag = "Just";
        yield return new WaitForSeconds(justDodge);
        gameObject.tag = "Player";
        while (avoidTime < avoidDistance / avoidSpeed)// 実質回避の所要時間
        {
            transform.position += avoidDirection * avoidSpeed * Time.deltaTime;
            avoidTime += Time.deltaTime;
            yield return null;
        }
        yield return new WaitForSeconds(dodgeCoolTime);
        canDodge = true;
    }
}
