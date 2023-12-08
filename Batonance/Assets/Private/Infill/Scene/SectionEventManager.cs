using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SectionEventManager : MonoBehaviour
{
    public UnityEvent subject = new UnityEvent();
    private int nowSection = 0;
    public int NowSection { get { return nowSection; } private set { value = nowSection; } }
    public static SectionEventManager instance;

    /// <summary>
    /// 富田追加
    /// </summary>
    private void Awake()
    {
        if (!instance) instance = this;
        else Destroy(this);
    }

    private void Start()
    {
        if(this.gameObject.name != "SectionEventManager")
        {
            Debug.LogWarning("Not the best object name");
        }

        Initialize(0);
    }
    public void Initialize(int _nowSection)
    {
        Debug.Log("EventFire:Initialize(int)");
        NowSection = _nowSection;
        subject.Invoke();
    }
    public void Initialize()
    {
        Debug.Log("EventFire:Initialize()");
        nowSection = SectionCount.instance.CurrentSection;
        subject.Invoke();
    }
}
