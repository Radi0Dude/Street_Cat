using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class S_RoatateCamera : MonoBehaviour
{
	[SerializeField]
	[Required]
	Transform palyerTransform;

	[SerializeField, Tag]
	string enemyTag;

	[SerializeField]
	private List<Vector3> enemyPos = new List<Vector3>();

	private void Start()
	{
		for (int i = 0; i < GameObject.FindGameObjectsWithTag(enemyTag).Length; i++)
		{
			enemyPos.Add(GameObject.FindGameObjectsWithTag(enemyTag)[i].transform.position);
		}
	}

	private void Update()
	{
		
	}
}
