using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Debug_Checkpoint_TF : MonoBehaviour
{
	[MinValue(1), MaxValue(3)]
	[SerializeField] float sphereRadius;
	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.green;
		Gizmos.DrawSphere(transform.position, sphereRadius);
	}
	
}
