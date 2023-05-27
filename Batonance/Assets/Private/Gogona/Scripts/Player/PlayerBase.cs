using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HPController))]
public class PlayerBase : MonoBehaviour
{
    private PlayerDataBase data;
    private HPController hPCtrl;
    private PlayerAttack playerAtk;
    private PlayerMovement playerMov;
    private PlayreGuard playerDef;

    // Start is called before the first frame update
    void Start()
    {
        ClassReference();
        ValueDelivery();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// 各クラスの参照
    /// </summary>
    private void ClassReference()
    {
        hPCtrl = GetComponent<HPController>();
        playerAtk = GetComponent<PlayerAttack>();
        playerMov = GetComponent<PlayerMovement>();
        playerDef = GetComponent<PlayreGuard>();
    }

    /// <summary>
    /// 他クラスへの値の受け渡し
    /// </summary>
    private void ValueDelivery()
    {
        data = DataBaseManager.instance.GetPlayerData();
        hPCtrl.GetCharHP(data.baseHP);
        playerAtk.GetPlayerAttackPower(data.baseAtk);
        playerMov.GetPlayerSpeed(data.baseSpd);
        playerDef.GetPlayerGuard(data.baseDef);
    }
}
