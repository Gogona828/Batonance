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

    public void LeftEntry()
    {
        // TODO: 左入力の処理
        playerAttack.Attack();
    }
    public void FrontEntry()
    {
        // TODO: 前入力の処理
        playerAttack.Attack();
    }
    public void RightEntry()
    {
        // TODO: 右入力の処理
        playerAttack.Attack();
    }
}
