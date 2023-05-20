using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SignalReceiver : MonoBehaviour
{
    // [SerializeField]
    // private float timeSpeed;
    [SerializeField]
    private TextMeshProUGUI text;
    private float time = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        text.text = time.ToString("f3");
    }

    public void SignalReceive()
    {
        Debug.Log("敵の攻撃アニメーション再生");
        // Time.timeScale = timeSpeed;
    }
}
