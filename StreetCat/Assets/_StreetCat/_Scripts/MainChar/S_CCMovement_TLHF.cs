using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class S_CCMovement_TLHF : MonoBehaviour
{
	[InputAxis]
	[SerializeField] 
	private string moveAxis;
    [SerializeField]
	private float speed;
	[SerializeField]
	private Animator animator;


	private CharacterController controller;			
	private Vector2 moveAmount;
	private Vector3 movement;
	private float moveChar;
	private float velocity;
	private bool grounded;


	private void Start()
	{
		controller = GetComponent<CharacterController>();
	}

	public void OnMove(InputAction.CallbackContext callbackContext)
	{
		moveAmount = callbackContext.ReadValue<Vector2>();
	}
	private void Movement()
	{
		grounded = controller.isGrounded;

		moveChar = moveAmount.x;
		
		movement = new Vector3(0, 0, moveChar * speed) * Time.deltaTime;

		controller.Move(movement);

		velocity = controller.velocity.z;
	}

	private void Update()
	{
		Movement();
	}

}
