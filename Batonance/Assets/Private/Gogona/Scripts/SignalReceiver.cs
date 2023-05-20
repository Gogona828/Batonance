using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalReceiver : MonoBehaviour
{
    // [SerializeField]
    // private float timeSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SignalReceive()
    {
        Debug.Log("敵の攻撃アニメーション再生");
        // Time.timeScale = timeSpeed;
    }
}
