using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class S_FollowPlayerPosCamera_TLHF : MonoBehaviour
{
	[SerializeField] Transform playerPos;
	[SerializeField] Transform pointPos;

	[MinValue(3), MaxValue(10)]
	[SerializeField]
	float amountToSpawnInFront;

	float playerXDistance;
	float cameraXDistance;
	float difference;

	private void Start()
	{
		OnSpawnPosition();
	}
	private void Update()
	{
		CalculateDistance();

		Debug.Log(difference);

		
	}

	private void OnSpawnPosition()
	{
		transform.position =  new Vector3(amountToSpawnInFront + playerPos.position.x, 0, 0);
	}
	private void CalculateDistance()
	{
		playerXDistance = pointPos.position.x - playerPos.position.x;
		cameraXDistance = pointPos.position.x - transform.position.x;



		difference = cameraXDistance / playerXDistance;
	}
}
