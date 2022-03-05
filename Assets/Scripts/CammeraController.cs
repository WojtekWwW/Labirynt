using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CammeraController : MonoBehaviour
{
    [SerializeField]
    float mouseSensitivity = 100f;
    Transform playerBody;
    float xRotation = 0f;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        playerBody = transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        cameraRotation();
    }
    void cameraRotation()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        /*Debug.Log("MouseX:" + mouseX.ToString());
        Debug.Log("MouseY:" + mouseY.ToString());*/
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 80f);
        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        playerBody.Rotate(Vector3.up * mouseX);

    }
}
