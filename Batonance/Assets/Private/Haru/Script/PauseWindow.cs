using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseWindow : MonoBehaviour
{
    private Canvas pauseCanvas;
    [SerializeField]
    private List<Image> buttonList;
    private int buttonIndex;
    private Image selectButton;
    private Color defaultButtonColor;
    // Start is called before the first frame update
    void Start()
    {
        pauseCanvas = this.gameObject.GetComponent<Canvas>();
        pauseCanvas.enabled = false;
        selectButton = buttonList[0];
        buttonIndex = 0;
        defaultButtonColor = selectButton.color;
        selectButton.color = new Color(20, 0, 0, 225);//選ばれている演出
    }
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 1 - Time.timeScale;
            pauseCanvas.enabled = !pauseCanvas.enabled;
        }
        if(Input.GetKeyDown(KeyCode.D))
        {
            selectButton.color = defaultButtonColor;//選ばれていない演出
            buttonIndex = (buttonIndex+1)%buttonList.Count;
            selectButton = buttonList[buttonIndex];
            selectButton.color = new Color(20, 0, 0, 225);//選ばれている演出
        }
        if(Input.GetKeyDown(KeyCode.A))
        {
            selectButton.color = defaultButtonColor;//選ばれていない演出
            buttonIndex =(buttonList.Count + buttonIndex - 1)% buttonList.Count;
            selectButton = buttonList[buttonIndex];
            selectButton.color = new Color(20, 0, 0, 225);//選ばれている演出
        }
        
    }
}
