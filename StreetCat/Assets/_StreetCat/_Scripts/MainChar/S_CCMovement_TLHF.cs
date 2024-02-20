using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class S_CCMovement_TLHF : MonoBehaviour
{
	[InputAxis]
	[SerializeField] 
	private string moveAxis;
    [SerializeField]
	private float speed;
	[SerializeField]
	private Animator animator;
	[Scene]
	[SerializeField]
	private string fightingSceneName;

	[SerializeField]
	private string animatorMoveName;
	[SerializeField]
	private string animatorFightingName;

	private CharacterController controller;			
	public Vector2 moveAmount;
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
		
		if(animator != null )
		{
			animator.SetFloat(animatorMoveName, moveChar);
		}

		if(transform.position.x != 0)
		{
			transform.position = new Vector3(0, this.transform.position.y, this.transform.position.z);
		}
		//if(velocity > 0.05f)
		//{
		//	transform.rotation = Quaternion.Euler(0, 0, 0);
		//}
		//else if (velocity < 0.05f)
		//{
		//	transform.rotation = Quaternion.Euler(0, 180, 0);
		//}
	}

	private void CheckState()
	{
		if(SceneManager.GetActiveScene().name == fightingSceneName) 
		{
			animator.SetBool(animatorFightingName, true);
		}

	}

	private void Update()
	{
		Movement();
	}

}
