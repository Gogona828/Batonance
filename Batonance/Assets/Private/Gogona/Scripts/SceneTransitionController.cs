using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionController : MonoBehaviour
{
    public bool isCreditOpening = false;
    [SerializeField, Tooltip("Credit")] private ImageDisplay imageDisplay;
    private bool isTitleScene = false;
    private string currentSceneName;
    private string titleSceneName = "TitleScene";
    private string mainSceneName = "MainScene";

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        currentSceneName = SceneManager.GetActiveScene().name;
        if (currentSceneName == titleSceneName) isTitleScene = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isTitleScene && Input.GetMouseButton(0)) return;
        if (Input.GetButtonDown("Jump") && imageDisplay && !isCreditOpening) imageDisplay.ShowImage();
        else if ((Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Jump")) && imageDisplay && isCreditOpening) imageDisplay.HideImage(); 
        if (isTitleScene && Input.GetButtonDown("CrossButton") && !isCreditOpening) {
            SceneTransition(mainSceneName);
        }
    }

    public void SceneTransition(string _sceneName)
    {
        SceneManager.LoadScene(_sceneName);
    }

    public void SceneReload()
    {
        SectionCount.instance.ReLoad();
    }

    public void SceneReset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
