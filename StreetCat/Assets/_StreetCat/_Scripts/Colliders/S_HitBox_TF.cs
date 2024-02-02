using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S_HitBox_TF : MonoBehaviour
{
	public Vector3 hitBoxSize = Vector3.one;
	Vector3 boxRot;
	[SerializeField]
	LayerMask mask;

	public float radius;

	public bool useSphere = false;
	
	


	private ColliderState state;
	
	private void OnOverlap()
	{
		Collider[] colliedrs = Physics.OverlapBox(transform.position, hitBoxSize, Quaternion.Euler(boxRot), mask); 
		if (colliedrs.Length > 0)
		{
			Debug.Log("Hit");
		}

	}

	//Show collider
	private void OnDrawGizmos()
	{
		
	}
}
public enum ColliderState
{
	Closed,
	Open,
	colliding
}
