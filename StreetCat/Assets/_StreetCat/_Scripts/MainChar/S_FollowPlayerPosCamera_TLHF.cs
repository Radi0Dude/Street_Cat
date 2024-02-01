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
	Vector3 hasMoved;
	float distanceMoved;

	bool hasMultiplePlayers;

	private void Start()
	{
		OnSpawnPosition();
		hasMoved = playerPos.position;
	}
	private void Update()
	{
		CalculateDistance();

		Debug.Log(difference);	
	}

	private void OnSpawnPosition()
	{
		transform.position =  new Vector3(amountToSpawnInFront + playerPos.position.x, 0, playerPos.position.z);
	}
	private void CalculateDistance()
	{
		playerXDistance = pointPos.position.x - playerPos.position.x;
		cameraXDistance = pointPos.position.x - transform.position.x;
		difference = cameraXDistance / playerXDistance;

		if(hasMoved.x != playerPos.position.x)
		{
			float distance = playerPos.position.x - hasMoved.x;
			transform.position = new Vector3(transform.position.x + (distance * difference), 0, playerPos.position.z);
			Debug.Log(hasMoved);
			hasMoved.x = playerPos.position.x;
		}

		



		
	}
}
