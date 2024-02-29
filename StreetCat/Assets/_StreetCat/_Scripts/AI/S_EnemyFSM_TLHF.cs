using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_EnemyFSM_TLHF : MonoBehaviour
{
    protected Transform playerPos;

    protected Vector3 destination;

	protected float reactionTime;
    protected float timeSinceStart;

    protected virtual void Initialize() { }
    protected virtual void FMSUpdate() { }

    protected virtual void FMSFixedUpdate() { }

	private void Start()
	{
        Initialize();
	}
	private void Update()
	{
		FMSUpdate();
	}
	private void FixedUpdate()
	{
		FMSFixedUpdate();
	}
}
