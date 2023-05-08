using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HPController))]
public class CharacterBase : MonoBehaviour
{
    [SerializeField, Tooltip("キャラクタのID")]
    private int charId;
    private CharacterDataBase.CharacterData data;

    // 最大HP
    private float maxHP;

    // 各クラスの取得
    private HPController hPCntl;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {
        // データベースからキャラデータを取得
        data = DataBaseManager.instance.GetCharData(charId);
        maxHP = data.hP;
    }

    // Start is called before the first frame update
    void Start()
    {
        GetClassData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// 各クラスのデータを取得
    /// </summary>
    private void GetClassData()
    {
        hPCntl = GetComponent<HPController>();
    }
}
