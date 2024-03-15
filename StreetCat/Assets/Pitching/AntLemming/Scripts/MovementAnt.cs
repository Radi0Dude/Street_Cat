using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementAnt : MonoBehaviour
{
    private Vector3 dir;
    private CharacterController cC;

    [SerializeField]
    private float speed;

    private void Start()
    {
        cC = GetComponent<CharacterController>();
    }


    private void Update()
    {
        float mouseX = Input.GetAxis("Horizontal");
        float mouseY = Input.GetAxis("Vertical");

        dir = transform.forward * mouseX + transform.right * mouseY;
        dir.y -= 9.81f / speed;
        cC.Move(dir * speed * Time.deltaTime);



        Debug.Log(dir);

    }
}
