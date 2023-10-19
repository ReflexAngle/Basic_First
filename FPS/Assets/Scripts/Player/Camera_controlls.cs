using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_controlls : MonoBehaviour
{

    [Header("Mouse")]
    [SerializeField] private float mouseSensX = 400f;
    [SerializeField] private float mouseSensY = 400f;
    private float xRotation;
    private float yRotation;
    [SerializeField]private float mouseMultiplier = 0.01f;
    Camera _camera;
    float mouseX;
    float mouseY;
    // Start is called before the first frame update
    void Start()
    {
        _camera = GetComponentInChildren<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        CameraInput();

        _camera.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        transform.rotation = Quaternion.Euler(0, yRotation, 0);
    }
    private void CameraInput(){
        mouseX = Input.GetAxisRaw("Mouse X");
        mouseY = Input.GetAxisRaw("Mouse Y");

        yRotation += mouseX * mouseSensX * mouseMultiplier;
        xRotation -= mouseY * mouseSensY * mouseMultiplier;

        xRotation = Mathf.Clamp(xRotation, -85, 85);


    }
}
