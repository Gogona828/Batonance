using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/EnemyDataBase")]
public class EnemyDataBase : ScriptableObject
{
    public List<EnemyData> enemyDatas = new List<EnemyData>();

    [System.Serializable]
    public class EnemyData
    {
        [Tooltip("キャラクターのID")]
        public int id;
        [Tooltip("キャラクターの名前")]
        public string name;
        [Tooltip("HP")]
        public int hP;
        [Tooltip("基礎攻撃力")]
        public int baseAtk;
        [Tooltip("基礎防御力")]
        public int baseDef;
        [Tooltip("移動速度")]
        public float baseSpd;
    }
}
