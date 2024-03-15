using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_DeployPoints_TLHF : MonoBehaviour
{
	[SerializeField]
	GameObject pointPrefab;
	[SerializeField]
	public List<Transform> points = new List<Transform>();

	float timeSinceStart;
	[SerializeField]
	float timerThingyplus;
	float timeToNextPointDeploy;

	bool canSpawn;

	private void Update()
	{
		timeSinceStart = Time.realtimeSinceStartup;

		if(timeSinceStart > timeToNextPointDeploy)
		{
			
			Transform newPoint = Instantiate(pointPrefab, transform.position, Quaternion.identity).transform;
			points.Add(newPoint);
			timeToNextPointDeploy += timerThingyplus;
			
		}
		

	}
}
