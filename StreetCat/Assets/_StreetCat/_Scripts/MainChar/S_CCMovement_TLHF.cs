using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class S_CCMovement_TLHF : MonoBehaviour
{
    CharacterController controller;

	[SerializeField]
	private float speed;

	[SerializeField]
	private Animator animator;

	[InputAxis]
	[SerializeField] 
	string moveAxis;

	Vector2 moveAmount;

	float movement;

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
		movement = moveAmount.x;	
	}

}
