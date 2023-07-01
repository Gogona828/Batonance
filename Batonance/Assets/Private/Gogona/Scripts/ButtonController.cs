using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        canSelectButton = true;
        ButtonSelection();
    }

    // Update is called once per frame
    void Update()
    {
        if (!canSelectButton) return;
        if (!isPressedButton && (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.W)/*  || Input.GetAxisRaw("ArrowKeyLeftRight") == 1 || Input.GetAxisRaw("ArrowKeyUpAndDown") == 1 */))
        {
            isPressedButton = true;
            buttonNumber--;
            if (buttonNumber < 0)
                buttonNumber = buttonList.Count - 1;
            ButtonSelection();
        }

        else if (!isPressedButton && (Input.GetKeyDown(KeyCode.A)/* || Input.GetKeyDown(KeyCode.S) || Input.GetAxisRaw("ArrowKeyLeftRight") == -1 || Input.GetAxisRaw("ArrowKeyUpAndDown") == -1 */))
        {
            isPressedButton = true;
            buttonNumber++;
            if (buttonNumber > buttonList.Count - 1)
                buttonNumber = 0;
            ButtonSelection();
        }

        if (isPressedButton/*  && Mathf.Abs(Input.GetAxisRaw("ArrowKeyLeftRight")) != 1 && Mathf.Abs(Input.GetAxisRaw("ArrowKeyUpAndDown")) != 1 */)
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
