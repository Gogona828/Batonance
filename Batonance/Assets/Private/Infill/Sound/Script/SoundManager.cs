using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private BGMManager bgmManager;
    private void Awake() {

    }
    // Start is called before the first frame update
    void Start(){
        bgmManager = GameObject.Find("BGMManager").GetComponent<BGMManager>();
        Debug.Log("SoundManager_Start");
        SetBGM_ButtleScene();
    }

    // Update is called once per frame
    void Update(){
        
    }

    void SetBGM_ButtleScene()
    {
        bgmManager.InitializeLoad();
    }
}
