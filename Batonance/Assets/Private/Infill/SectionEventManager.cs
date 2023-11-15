using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SectionEventManager : MonoBehaviour
{
    public UnityEvent subject = new UnityEvent();
    private int nowSection = 0;
    public int NowSection { get { return nowSection; }　private set { value = nowSection; } }
    public void Initialize(int _nowSection)
    {
        NowSection = _nowSection;
        subject.Invoke();
    }
}
