using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageDisplay : MonoBehaviour
{
    [SerializeField, Tooltip("表示したいImageを入力する")]
    private CanvasGroup canvasGroup;

    [SerializeField, Tooltip("title")] private SceneTransitionController sceneTransitionController;

    private void Start()
    {
        canvasGroup.alpha = 0;
    }

    public void ShowImage()
    {
        canvasGroup.alpha = 1;
        sceneTransitionController.isCreditOpening = true;
    }

    public void HideImage()
    {
        canvasGroup.alpha = 0;
        sceneTransitionController.isCreditOpening = false;
    }
}
