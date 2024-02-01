using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class S_Movement_TF : MonoBehaviour
{

	[SerializeField]
	[MinValue(0.0f)]
	[ValidateInput("MoreThanZero", "Speed needs to be grater than zero to be able move")]
	float speed;

	float raySomething;
	[InputAxis]
	[SerializeField] string moveAxis;

	[SerializeField] Vector2 moveAmount;
	bool collision;

	public float moveDir = 0;
	float rayDir;
	Vector3 debugRayDir;
	Ray ray;
	 public float horizontal;

	public void OnMove(InputAction.CallbackContext callbackContext)
	{
		moveAmount = callbackContext.ReadValue<Vector2>();
	}

	private void Update()
	{
		Movement();
	}

	private void Movement()
	{
		horizontal = moveAmount.x;


		if (horizontal > 0)
		{
			rayDir = 0.51f;
			transform.eulerAngles = new Vector3(0, 0, 0);
			moveDir = horizontal;
			debugRayDir = transform.right;
			raySomething = 1;
			//Maybe add animation here, get a check to see which way the animation was last frame
		}
		if (horizontal < 0)
		{
			rayDir = 0.52f;
			transform.eulerAngles = new Vector3(0, 180, 0);
			moveDir = -horizontal;
			debugRayDir = transform.right;
			raySomething = -1;
			//Maybe add animation here, get a check to see which way the animation was last frame
		}
		else if (horizontal == 0)
		{
			moveDir = 0;
			//Idle would go here!!
		}
		Debug.DrawRay(transform.position, transform.TransformDirection(debugRayDir) * 10f, Color.green);



		ray = new Ray(transform.position, debugRayDir);

		if (Physics.Raycast(ray, rayDir + raySomething * Time.deltaTime))
		{
			collision = true;
			moveDir = 0;
		}
		Vector3 movement = new Vector3(moveDir * speed, 0, 0) * Time.deltaTime;

		transform.Translate(movement);
	}

}