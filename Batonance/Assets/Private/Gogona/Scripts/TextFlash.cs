using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextFlash : MonoBehaviour
{
    private CanvasGroup canvasGroup;
    private bool isIncreese = false;
    [SerializeField]
    private float increaseRate = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        isIncreese = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (canvasGroup.alpha == 1) {
            isIncreese = false;
        }
        else if (canvasGroup.alpha == 0) {
            isIncreese = true;
        }

        if (isIncreese) {
            canvasGroup.alpha += increaseRate;
        }
        else if (!isIncreese) {
            canvasGroup.alpha -= increaseRate;
        }
    }
}
