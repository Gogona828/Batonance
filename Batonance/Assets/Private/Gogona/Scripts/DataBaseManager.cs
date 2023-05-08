using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataBaseManager : MonoBehaviour
{
    [SerializeField, Tooltip("CharacterDataBaseの参照")]
    private CharacterDataBase charDB;
    // DataManagerのインスタンス
    public static DataBaseManager instance;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {
        // インスタンスの生成
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        // すでにあれば削除
        else {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// データの取得
    /// </summary>
    /// <param name="charId"></param>
    /// <returns></returns>
    public CharacterDataBase.CharacterData GetCharData(int charId)
    {
        // データベース内からそのキャラのIDを探す
        foreach (CharacterDataBase.CharacterData data in charDB.charDatas)
        {
            if (data.id == charId) {
                return data;
            }
        }
        return null;
    }
}
