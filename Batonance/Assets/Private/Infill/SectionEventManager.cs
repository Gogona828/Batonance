using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SectionEventManager : MonoBehaviour
{
    public UnityEvent subject = new UnityEvent();
    private int nowSection = 0;
    public int NowSection { get { return nowSection; }　private set { value = nowSection; } }
    private SectionCount sectionCount;
    [SerializeField] GameObject sectionCountObject;
    private void Start()
    {
        sectionCount = sectionCountObject.GetComponent<SectionCount>();
    }
    public void Initialize()
    {
        nowSection = sectionCount.MaxSection;
        subject.Invoke();
    }
}
