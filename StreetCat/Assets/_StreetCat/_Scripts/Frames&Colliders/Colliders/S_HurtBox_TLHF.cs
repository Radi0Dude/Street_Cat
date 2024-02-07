using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_HurtBox_TLHF : MonoBehaviour
{
	
		public Collider collider;
		private ColliderState _state = ColliderState.Open;
		public Color inactiveColor;
		public Color collisionOpenColor;
		public Color collidingColor;

		private ColliderState state;
		public bool getHitBy(int damage)
		{
			return 0 > damage;
		}

		private void OnDrawGizmos()
		{

			switch (state)
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
	
}
