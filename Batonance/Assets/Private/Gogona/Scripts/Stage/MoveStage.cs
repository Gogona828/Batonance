using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveStage : MonoBehaviour
{
    [SerializeField, Tooltip("ステージが移動する速度")]
    private float moveSpeed = 3f;

    [SerializeField, Tooltip("ステージが消える位置")]
    private float positionDisappearPoint = -6f;

    [SerializeField, Tooltip("ステージを消すかどうか")]
    private bool shouldEraseStage() {
        if (transform.position.z <= positionDisappearPoint) return true;
        else return false;
    }
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, 0, -moveSpeed);
        if (shouldEraseStage()) Destroy(gameObject);
    }
}
