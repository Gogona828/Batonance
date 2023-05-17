using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/PlayerDataBase")]
public class PlayerDataBase : ScriptableObject
{
    [Tooltip("HP")]
    public int baseHP;
    [Tooltip("基礎攻撃力")]
    public int baseAtk;
    [Tooltip("基礎防御力")]
    public int baseDef;
    [Tooltip("移動速度")]
    public float baseSpd;
}
