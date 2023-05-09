using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPController : MonoBehaviour
{
    [SerializeField, Tooltip("最大HP")]
    private float maxHP;
    [SerializeField, Tooltip("現在HP")]
    private float currentHP;

    // Start is called before the first frame update
    void Start()
    {
        // 現在HPを最大HPにする
        currentHP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// キャラクタのHPの取得
    /// </summary>
    /// <param name="hP"></param>
    public void GetCharHP(float hP)
    {
        maxHP = hP;
    }
}
