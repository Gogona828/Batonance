using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionController : MonoBehaviour
{
    private bool isTitleScene = false;
    private string currentSceneName;
    private string titleSceneName = "TitleScene";
    private string mainSceneName = "MainScene";

    // Start is called before the first frame update
    void Start()
    {
        currentSceneName = SceneManager.GetActiveScene().name;
        if (currentSceneName == titleSceneName) isTitleScene = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isTitleScene && Input.anyKey) {
            SceneTransition(mainSceneName);
        }
    }

    /// <summary>
    /// シーン遷移
    /// </summary>
    /// <param name="_sceneName"></param>
    /// <returns></returns>
    public void SceneTransition(string _sceneName)
    {
        SceneManager.LoadScene(_sceneName);
    }
}
