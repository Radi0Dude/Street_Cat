using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System.IO;
using Unity.VisualScripting;

public class S_Camera_TLHF : MonoBehaviour
{
	[SerializeField]
	Transform playerPos;
	[SerializeField]
	private CinemachineSmoothPath path;

	private void Update()
	{
		var distance = path.FindClosestPoint(playerPos.position, 0, -1, 10);
		Vector3 destination = path.EvaluatePositionAtUnit(distance, CinemachinePathBase.PositionUnits.Distance);
		transform.position = destination;
	}
}
