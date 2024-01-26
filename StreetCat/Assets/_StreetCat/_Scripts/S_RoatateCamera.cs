using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class S_RoatateCamera : MonoBehaviour
{
	[SerializeField]
	[Required]
	Transform playerTransform;
	[SerializeField]
	Transform playerPoint;

	[SerializeField, Tag]
	string enemyTag;

	[SerializeField]
	[InfoBox("add All of the world roataable objects", EInfoBoxType.Warning)]
	List<GameObject> rotatable = new List<GameObject>();

	[SerializeField]
	private List<Vector3> enemyPos = new List<Vector3>();

	[SerializeField]
	
	float rotationSpeed;

	bool allowedRotation = false;
	bool firstFrameAllowedRot;

	float lerpPrecentage;

	Quaternion lookRotation;

	private void Start()
	{
		for (int i = 0; i < GameObject.FindGameObjectsWithTag(enemyTag).Length; i++)
		{
			enemyPos.Add(GameObject.FindGameObjectsWithTag(enemyTag)[i].transform.position);
			rotatable.Add(GameObject.FindGameObjectsWithTag(enemyTag)[i].gameObject);
		}

	}

	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.Space) && allowedRotation == false)
		{
			allowedRotation = true;
		}
		if(allowedRotation == true)
		{
			RotateObject(); 
			firstFrameAllowedRot = true;
		}
		
		
	}

	void RotateObject()
	{
		if(firstFrameAllowedRot)
		{
			transform.position = playerTransform.position;
			int randomNum = Random.Range(0, enemyPos.Count);
			Vector3 newDir = Vector3.RotateTowards(transform.forward, enemyPos[randomNum], 0.1f, 0);
			transform.rotation = Quaternion.Euler(0, transform.rotation.y, 0);
			transform.rotation = Quaternion.LookRotation(newDir);
			lookRotation = Quaternion.LookRotation(playerPoint.position);

			for (int i = 0; i < rotatable.Count; i++)
			{
			rotatable[i].transform.parent = this.transform;
			}
			firstFrameAllowedRot = false;
		}
		lerpPrecentage = Mathf.MoveTowards(lerpPrecentage, 1,  rotationSpeed);

		transform.rotation =Quaternion.Euler(0, Quaternion.Slerp(transform.rotation, lookRotation, lerpPrecentage).eulerAngles.y, 0);
		

		if(lerpPrecentage >= 1)
		{
			allowedRotation = false;
		}
	}

	
}
