using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterAttack : MonoBehaviour
{
    [SerializeField, Tooltip("カウンター回数")]
    private int counterTimes = 0;
    [SerializeField, Tooltip("Batonance")]
    private MeshRenderer batonance;
    [SerializeField, Tooltip("カウンター時に変わる色")]
    private Material[] mat;
    /* [SerializeField, Tooltip("カウンターのアニメーション")]
    private Animator animator; */

    private int countMax = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /* if (Input.GetKeyDown(KeyCode.Space)) {
            Counter();
        } */
    }

    public void Counter()
    {
        if (counterTimes > countMax - 1) return;

        counterTimes++;
        batonance.material = mat[counterTimes];
    }
}
