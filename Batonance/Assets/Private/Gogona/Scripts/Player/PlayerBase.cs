using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    private PlayerDataBase data;
    // Start is called before the first frame update
    void Start()
    {
        data = DataBaseManager.instance.GetPlayerData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
