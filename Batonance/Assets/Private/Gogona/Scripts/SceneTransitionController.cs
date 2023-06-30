using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionController : MonoBehaviour
{
    [SerializeField, Tooltip("遷移先のシーンの名前")]
    private string sceneNameNextTransition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// シーンの遷移
    /// </summary>
    public void SceneTransition()
    {
        SceneManager.LoadScene(sceneNameNextTransition);
    }
}
