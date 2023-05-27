using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject mainCamera;
    private GameObject playerObject;
    public float rotateSpeed = 2.0f;
    private Vector3 angle;
    void Start()
    {
        mainCamera = Camera.main.gameObject;
        playerObject = transform.root.gameObject;
    }
    void FixedUpdate()
    {
        RotateCamera();
    }

    private void RotateCamera()
    {
        if (UsePCController.s_shouldUseCntl) {
            angle = new Vector3(Input.GetAxis("RStickX") * -rotateSpeed, 0, 0);
        }
        else {
            angle = new Vector3(Input.GetAxis("Mouse X") * -rotateSpeed, 0, 0);
        }
        mainCamera.transform.RotateAround(playerObject.transform.position, Vector3.down, angle.x * 2);

        Cursor.lockState = CursorLockMode.Locked;
    }
}
