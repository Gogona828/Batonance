using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{
    [SerializeField, Tooltip("アニメーターを取得")]
    private Animator animator;
    [SerializeField, Tooltip("エフェクトリスト")]
    private List<GameObject> effectList = new List<GameObject>();
    private PlayerAttack playerAttack;

    // 左入力の感知
    private bool isLeftInputFound() {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetButton("SquareButton"))
            return true;
        else return false;
    }
    // 前入力の感知
    private bool isFrontInputFound() {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetButton("TriangleButton"))
            return true;
        else return false;
    }
    // 右入力の感知
    private bool isRightInputFound() {
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetButton("CircleButton"))
            return true;
        else return false;
    }

    private void Start()
    {
        playerAttack = GetComponent<PlayerAttack>();
    }

    private void Update()
    {
        DetectButtonEntry();
    }
    
    public void DetectButtonEntry()
    {
        if (Time.timeScale == 0) return;
        if (isLeftInputFound()) {
            Debug.Log($"left attack");
            LeftEntry();
        }
        else if (isFrontInputFound()) {
            Debug.Log($"front attack");
            FrontEntry();
        }
        else if (isRightInputFound()) {
            Debug.Log($"right attack");
            RightEntry();
        }
    }

    /// <summary>
    /// 左入力が入った時、左に攻撃をする
    /// </summary>
    public void LeftEntry()
    {
        playerAttack.Attack();
        animator.SetTrigger("LeftAttack");
        NotesInputCompare.instance.InputAttack(0);
    }

    /// <summary>
    /// 前入力が入った時、前方向に攻撃をする
    /// </summary>
    public void FrontEntry()
    {
        playerAttack.Attack();
        animator.SetTrigger("FrontAttack");
        NotesInputCompare.instance.InputAttack(1);
    }

    /// <summary>
    /// 右入力が入った時、右方向に攻撃をする
    /// </summary>
    public void RightEntry()
    {
        playerAttack.Attack();
        animator.SetTrigger("RightAttack");
        NotesInputCompare.instance.InputAttack(2);
    }
}
