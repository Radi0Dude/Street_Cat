using Cinemachine;
using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;

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

	[Scene]
	[SerializeField]
	string nameOfScene;

	[SerializeField]
	CinemachineVirtualCamera virtualCamera;
	

	[SerializeField]
	private GameObject trainingDummy;

	private bool playerOneSpawned;
	private bool playerTwoSpawned;
	private bool trainingDummySpawned;

	private GameObject dummy;

	private float followOfset;
	private float amountMoreThanNine;
	
	public void PlayerJoinedEvent()
	{		
		if(playerOneSpawned)
		{
			if(!playerTwoSpawned)
			{
				playerTwoSpawned = true;
				Debug.Log("Herlo");
			}
		}
		if(!playerOneSpawned)
		{
			playerOnePos = GameObject.FindGameObjectWithTag(playertag).transform;	
			this.transform.position = playerOnePos.position;		
			OnSpawnPositionOnePlayer();		
	
			hasMultiplePlayers = false;			
			playerTwoPos = null;
		
			playerOneSpawned = true;				
			hasMoved = playerOnePos.position;	
		}

		if(SceneManager.GetActiveScene().name == nameOfScene)
		{
			hasMultiplePlayers = true;
			if (GameObject.FindGameObjectsWithTag(playertag).Length >= 2)
			{
				playerOnePos = GameObject.FindGameObjectsWithTag(playertag)[0].transform;
				playerTwoPos = GameObject.FindGameObjectsWithTag(playertag)[1].transform;
				
			}
			else if (GameObject.FindGameObjectsWithTag(playertag).Length == 1)
			{
				playerOnePos = GameObject.FindGameObjectsWithTag(playertag)[0].transform;
				playerOnePos.position = this.transform.position;
				playerTwoPos = null;
				OnSpawnPositionOnePlayer();

				hasMoved = playerOnePos.position;

			}
			
		}
		else
		{
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
		
		
	}
	private void Update()
	{
		if(playerOneSpawned)
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

		
	}

	private void OnSpawnPositionOnePlayer()
	{
		transform.position =  new Vector3(playerOnePos.position.x, 0, amountToSpawnInFront + playerOnePos.position.z);
	}
	
	private void CalculateDistancePlayerOne()
	{
		playerXDistance = pointPos.position.z - playerOnePos.position.z;
		cameraXDistance = pointPos.position.z - transform.position.z;
		difference = cameraXDistance / playerXDistance;


		if(hasMoved.x != playerOnePos.position.x)
		{
			float distance = playerOnePos.position.z - hasMoved.z;
			transform.position = new Vector3(transform.position.x, 0, playerOnePos.position.z + (distance * difference));

			hasMoved.z = playerOnePos.position.z;
		}
	}
	private void CalculateDistancePlayerIfTwo()
	{
		if(playerTwoSpawned)
		{
			if(dummy != null) 
			{
				Destroy(dummy);
				playerTwoPos = GameObject.FindGameObjectsWithTag(playertag)[1].transform;
			}
			transform.position = new Vector3((playerOnePos.position.x + playerTwoPos.position.x) / 2, (playerOnePos.position.y + playerTwoPos.position.y) + 1, (playerOnePos.position.z + playerTwoPos.position.z) / 2);

		}
		
		if (playerOneSpawned)
		{
			if(!trainingDummySpawned)
			{
				dummy = Instantiate(trainingDummy, new Vector3(playerOnePos.position.x, transform.position.y, transform.position.z + 6), Quaternion.identity);
				playerTwoPos = dummy.transform;
				trainingDummySpawned = true;
			}
			transform.position = new Vector3((playerOnePos.position.x + playerTwoPos.position.x) / 2, (playerOnePos.position.y + playerTwoPos.position.y) + 1, (playerOnePos.position.z + playerTwoPos.position.z) / 2);

			if(Vector3.Distance(playerOnePos.position, playerTwoPos.position) > 9)
			{
				virtualCamera.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset.x = 2.5f + Vector3.Distance(playerOnePos.position, playerTwoPos.position) - 9;
			}
			else
			{
				virtualCamera.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset.x = 2.5f;
			}
		}

	}
}
