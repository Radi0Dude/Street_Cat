using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_SpawnPoint_TLHF : MonoBehaviour
{
	[SerializeField]
	Transform playerPos;
	public void SpawnCharacterPosition()
	{
		playerPos.position = this.transform.position;
	}
}
