using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseWindow : MonoBehaviour
{
    private Canvas pauseCanvas;
    // Start is called before the first frame update
    void Start()
    {
        pauseCanvas = this.gameObject.GetComponent<Canvas>();
        pauseCanvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 1 - Time.timeScale;
            pauseCanvas.enabled = !pauseCanvas.enabled;
        }
        
    }
}
