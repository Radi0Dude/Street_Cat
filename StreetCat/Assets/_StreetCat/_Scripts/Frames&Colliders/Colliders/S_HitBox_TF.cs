using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class S_HitBox_TF : MonoBehaviour
{
	public Vector3 hitBoxSize = Vector3.one;
	Vector3 boxRot;
	[SerializeField]
	LayerMask mask;

	[MinValue(0.1f)]
	public float radius = 0.5f;

	public bool useSphere = false;

	private S_IHitBoxResponder_TLHF Iresponder = null;

	public Color inactiveColor;
	public Color collisionOpenColor;
	public Color collidingColor;

	private ColliderState state;
	
	private void OnOverlap()
	{
		Collider[] colliedrs = Physics.OverlapBox(transform.position, hitBoxSize, Quaternion.Euler(boxRot), mask); 
		for(int i = 0; i < colliedrs.Length; i++)
		{
			Collider aCol = colliedrs[i];
			Iresponder?.collisionWith(aCol);
		}

	}

	private void Update()
	{
		if(state == ColliderState.Closed) { return; }
		Collider[] colliedrs = Physics.OverlapBox(transform.position, hitBoxSize, Quaternion.Euler(boxRot), mask);
		for (int i = 0; i < colliedrs.Length; i++)
		{
			Collider aCol = colliedrs[i];
			Iresponder?.collisionWith(aCol);
		}

		state = colliedrs.Length > 0 ? ColliderState.colliding : ColliderState.Open;
	}

	public void StartCheckingColliders()
	{
		state = ColliderState.Open;
	}
	public void StopCheckingColliders()
	{
		state = ColliderState.Closed;
	}

	
	//Show collider
	private void OnDrawGizmos()
	{
		switch(state)
		{
			case ColliderState.Closed:
				Gizmos.color = inactiveColor;
				break;
			case ColliderState.Open:
				Gizmos.color = collisionOpenColor;
				break;
			case ColliderState.colliding:
				Gizmos.color = collidingColor;
				break;
		}
	}
	private void useResponder(S_IHitBoxResponder_TLHF responder)
	{
		Iresponder = responder;
	}
}

public enum ColliderState
{
	Closed,
	Open,
	colliding
}
