using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Agent_TLHF : MonoBehaviour
{
    

	[SerializeField]
	List<Transform> pointsToGoTo = new List<Transform>();

	[SerializeField]
	GameObject player;

	int goToThisPoint = 0;

	[SerializeField]
	float speed;

	S_DeployPoints_TLHF scriptOther;
	private void Update()
	{
		if(pointsToGoTo.Count != scriptOther.points.Count) 
		{ 
			for (int i = 0; i < scriptOther.points.Count; ++i)
			{
				pointsToGoTo.Add(scriptOther.points[i]);
			}		
		}

		
		if(Vector3.Distance(transform.position, pointsToGoTo[goToThisPoint].position) < 0.1f)
		{
			goToThisPoint++;
		}

		Vector3 dir = this.transform.position - pointsToGoTo[goToThisPoint].position;

		transform.Translate(dir * Time.deltaTime * speed);

	}


}
