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
        [Tooltip("EnemyのID")]
        public int id;
        [Tooltip("Enemyの名前")]
        public string name;
        [Tooltip("HP")]
        public int baseHP;
        [Tooltip("基礎攻撃力")]
        public int baseAtk;
        [Tooltip("基礎防御力")]
        public int baseDef;
        [Tooltip("移動速度")]
        public float baseSpd;
    }
}
