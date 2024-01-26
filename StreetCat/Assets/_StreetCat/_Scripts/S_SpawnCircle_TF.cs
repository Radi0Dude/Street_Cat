using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_SpawnCircle_TF : MonoBehaviour
{
	[SerializeField]
	[MinValue(2)]
	[Foldout("Floats")]
	float radius;

	[SerializeField]
	[MinValue(4)]
	[Foldout("Ints")]
	int numofEnemies;

	[SerializeField]
	[Required]
	Transform palyerTransform;

	[SerializeField]
	[Required]
	GameObject prefabEnemy;
		 

	private void Awake()
	{
		for(int i = 0; i < numofEnemies; i++)
		{
			float angle = i * Mathf.PI * 2f / numofEnemies;
			Vector3 pos = new Vector3(Mathf.Cos(angle) * radius, 0.5f, Mathf.Sin(angle) * radius);
			GameObject newPrefabEnemy = Instantiate(prefabEnemy, pos, Quaternion.identity);
		}
	}
}
