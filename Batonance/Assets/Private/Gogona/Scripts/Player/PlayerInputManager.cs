using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{
    private PlayerAttack playerAttack;

    private void Start()
    {
        playerAttack = GetComponent<PlayerAttack>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) {
            Debug.Log($"left attack");
            LeftEntry();
        }
        else if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) {
            Debug.Log($"front attack");
            FrontEntry();
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) {
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
    }

    /// <summary>
    /// 前入力が入った時、前方向に攻撃をする
    /// </summary>
    public void FrontEntry()
    {
        playerAttack.Attack();
    }

    /// <summary>
    /// 右入力が入った時、右方向に攻撃をする
    /// </summary>
    public void RightEntry()
    {
        playerAttack.Attack();
    }
}
