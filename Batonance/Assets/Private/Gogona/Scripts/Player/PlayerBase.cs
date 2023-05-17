using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HPController))]
public class PlayerBase : MonoBehaviour
{
    private PlayerDataBase data;
    private HPController hPCtrl;
    // Start is called before the first frame update
    void Start()
    {
        data = DataBaseManager.instance.GetPlayerData();
        hPCtrl = GetComponent<HPController>();
        hPCtrl.GetCharHP(data.baseHP);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
