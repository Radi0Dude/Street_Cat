using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntCam : MonoBehaviour
{ 
    private float sensX; 
    private float sensY;
    [SerializeField]
    private float sens;

    public Transform orientation;

    float xRotaion;
    float yRotaion;

    [SerializeField]
    private GameObject playerTransform;
    
    void Start()
    {
        sensX = sens; sensY = sens;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    
    void Update()
    {

        transform.position = playerTransform.transform.position;
        

        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotaion += mouseX;
        xRotaion -= mouseY;
        xRotaion = Mathf.Clamp(xRotaion, -70f, 70f);

        transform.rotation = Quaternion.Euler(xRotaion, yRotaion, 0);
        orientation.rotation = Quaternion.Euler(0, yRotaion - 90, 0);
    }
}
