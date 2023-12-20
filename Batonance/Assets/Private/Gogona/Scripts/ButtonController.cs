using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    [SerializeField]
    private List<CanvasGroup> buttonList = new List<CanvasGroup>();
    [SerializeField]
    private int buttonNumber;
    [SerializeField, Range(0,1)]
    private float alpha = 0.5f;
    private bool isPressedButton;
    public bool canSelectButton;

    void Start()
    {
        buttonNumber = 0;
        isPressedButton = false;
        canSelectButton = false;
        ButtonSelection();
    }

    // Update is called once per frame
    void Update()
    {
        if (!canSelectButton) return;
        if (!isPressedButton && buttonList[buttonNumber].alpha == 1 && (Input.GetButtonDown("CrossButton") || Input.GetKeyDown(KeyCode.Space))) {
            buttonList[buttonNumber].gameObject.GetComponent<Button>().onClick.Invoke();
        }
        Debug.Log($"isPressedButton:{isPressedButton}");
        if (!isPressedButton && (Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("ControllerVertical") == 1))
        {
            isPressedButton = true;
            Debug.Log($"upper key pressed: {isPressedButton}");
            buttonNumber--;
            if (buttonNumber < 0)
                buttonNumber = buttonList.Count - 1;
            ButtonSelection();
        }

        else if (!isPressedButton && (Input.GetAxisRaw("Vertical") == -1 || Input.GetAxisRaw("ControllerVertical") == -1))
        {
            isPressedButton = true;
            buttonNumber++;
            if (buttonNumber > buttonList.Count - 1)
                buttonNumber = 0;
            ButtonSelection();
        }

        if (isPressedButton && (Mathf.Abs(Input.GetAxisRaw("Vertical")) != 1 && Mathf.Abs(Input.GetAxisRaw("ControllerVertical")) != 1))
        {
            isPressedButton = false;
        }
    }

    public void ButtonSelection()
    {
        for (int i = 0; i < buttonList.Count; i++)
        {
            buttonList[i].alpha = alpha;
        }
        buttonList[buttonNumber].alpha = 1;
    }
}
