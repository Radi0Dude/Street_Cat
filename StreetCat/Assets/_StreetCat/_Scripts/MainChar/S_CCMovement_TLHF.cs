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

	[AnimatorParam("animator")]
	[SerializeField]
	private string animatorMoveName;
	[AnimatorParam("animator")]
	[SerializeField]
	private string animatorFightingName;
	[AnimatorParam("animator")]
	[SerializeField]
	private string animatorTurn;

	private CharacterController controller;			
	public Vector2 moveAmount;
	private Vector3 movement;
	private float moveChar;
	private float velocity;
	private bool animationDir;

	

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
		if(moveChar > 0)
		{
			if(animationDir)
			{
				animator.SetTrigger(animatorTurn);
				animationDir = false;
			}

		}

		if (moveChar < 0)
		{
			if(!animationDir)
			{			
				animator.SetTrigger(animatorTurn);
				animationDir = true;
			}

		}
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
