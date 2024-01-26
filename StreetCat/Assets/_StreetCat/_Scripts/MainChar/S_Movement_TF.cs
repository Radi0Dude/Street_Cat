using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Movement_TF : MonoBehaviour
{

	[SerializeField]
	[MinValue(0.0f)]
	[ValidateInput("MoreThanZero", "Speed needs to be grater than zero to be able move")]
	float speed;

	[InputAxis]
	[SerializeField] string moveAxis;

	private bool MoreThanZero()
	{
		return speed > 0.0f;
	}

	

	private void Update()
	{
		float horizontal = Input.GetAxis(moveAxis);


		Vector3 movement = new Vector3(horizontal * speed, 0, 0) * Time.deltaTime;

		transform.Translate(movement);
	}

}
