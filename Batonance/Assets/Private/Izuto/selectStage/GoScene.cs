using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class GoScene : MonoBehaviour
{
    public string sceneName;
    private void Start()
    {
        var button = GetComponent<Button>();
        button.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(sceneName);
        });
    }
}