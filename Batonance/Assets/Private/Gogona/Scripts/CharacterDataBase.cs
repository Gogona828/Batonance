using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/CharacterDataBase")]
public class CharacterDataBase : ScriptableObject
{
    public List<CharacterData> charDatas = new List<CharacterData>();

    [System.Serializable]
    public class CharacterData
    {
        [Tooltip("キャラクターのID")]
        public int id;
        [Tooltip("キャラクターの名前")]
        public string name;
        [Tooltip("HP")]
        public int hP;
        [Tooltip("基礎攻撃力")]
        public int baseATK;
        [Tooltip("基礎防御力")]
        public int baseDEF;
        [Tooltip("移動速度")]
        public float speed;
    }
}
