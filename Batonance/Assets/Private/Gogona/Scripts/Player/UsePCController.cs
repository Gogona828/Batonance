using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsePCController : MonoBehaviour
{
    public static bool s_shouldUseCntl;
    [SerializeField, Tooltip("コントローラーが使えるかどうか")]
    private bool m_shouldUseCntl;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        s_shouldUseCntl = m_shouldUseCntl;
    }
}
