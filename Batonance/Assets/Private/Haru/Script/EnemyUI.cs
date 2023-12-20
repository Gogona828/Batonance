using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUI : MonoBehaviour
{
    [SerializeField]
    private GameObject[] imageObject;
    public void ChangeGif(int Index)
    {
        Debug.Log(Index);
        Instantiate(imageObject[Index], transform);
    }
    public void UIReset(Transform root)
    {
        foreach (Transform child in root)
        {
            Destroy(child.gameObject);
        }
    }
}
