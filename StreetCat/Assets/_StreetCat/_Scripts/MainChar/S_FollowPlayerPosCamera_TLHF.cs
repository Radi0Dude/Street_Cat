using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class S_FollowPlayerPosCamera_TLHF : MonoBehaviour
{
	[SerializeField] Transform playerOnePos;
	[SerializeField] Transform playerTwoPos;
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

	[Tag]
	[SerializeField]
	string pointTag;
	[Tag]
	[SerializeField]
	string playertag;

	private void Start()
	{
		
		//playerOnePos = null;

		playerTwoPos = null;
		hasMultiplePlayers = false;


	}

	public void PlayerJoinedEvent()
	{
		pointPos = GameObject.FindGameObjectWithTag(pointTag).transform;
		Debug.Log(GameObject.FindGameObjectsWithTag(playertag));
		if (GameObject.FindGameObjectsWithTag(playertag).Length >= 2)
		{
			playerOnePos = GameObject.FindGameObjectsWithTag(playertag)[0].transform;
			playerTwoPos = GameObject.FindGameObjectsWithTag(playertag)[1].transform;
			hasMultiplePlayers = true;
		}
		else if (GameObject.FindGameObjectsWithTag(playertag).Length == 1)
		{
			playerOnePos = GameObject.FindGameObjectsWithTag(playertag)[0].transform;
			playerOnePos.position = this.transform.position;
			playerTwoPos = null;
			OnSpawnPositionOnePlayer();
			hasMultiplePlayers = false;
			hasMoved = playerOnePos.position;

		}
		else if (GameObject.FindGameObjectsWithTag(playertag).Length < 1)
		{
			playerOnePos = null;
			playerTwoPos = null;
			hasMultiplePlayers = false;
		}


	}
	private void Update()
	{
		if(!hasMultiplePlayers)
		{
			CalculateDistancePlayerOne();
		}
		else
		{
			CalculateDistancePlayerIfTwo();
		}

		
	}

	private void OnSpawnPositionOnePlayer()
	{
		transform.position =  new Vector3(amountToSpawnInFront + playerOnePos.position.x, 0, playerOnePos.position.z);
	}
	
	private void CalculateDistancePlayerOne()
	{
		playerXDistance = pointPos.position.x - playerOnePos.position.x;
		cameraXDistance = pointPos.position.x - transform.position.x;
		difference = cameraXDistance / playerXDistance;

		if(hasMoved.x != playerOnePos.position.x)
		{
			float distance = playerOnePos.position.x - hasMoved.x;
			transform.position = new Vector3(transform.position.x + (distance * difference), 0, playerOnePos.position.z);
			hasMoved.x = playerOnePos.position.x;
		}
	}
	private void CalculateDistancePlayerIfTwo()
	{
		transform.position = (playerOnePos.position + playerTwoPos.position) / 2;
	}
}
