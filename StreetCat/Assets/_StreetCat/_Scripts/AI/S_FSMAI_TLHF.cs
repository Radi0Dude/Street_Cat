using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_FSMAI_TLHF : MonoBehaviour
{    
    
    private State state;
    private StorPaellaPanna attackingState;
    private PaellaPanne HealthState;

    [SerializeField]
    private float speed;
    [SerializeField]
    private float health;
    [SerializeField]
    private float attackTime;

    [Tag]
    [SerializeField]
    private string playerTag;

    private bool isDead;

    private GameObject player;
    private Transform playerTransform;

	private void Start()
	{
		Initialize();
	}
	private void Initialize()
    {
        state = State.Idle;
        
        isDead = false;

        player = GameObject.FindGameObjectWithTag(playerTag);
        playerTransform = player.transform;

    }

    private void UpdateState()
    {
        switch (state)
        {
            case State.Idle:
                IdleState();
                break;
            case State.Chase:
                CHaseState();
                break;
            case State.Attack: 
                AttackState(); 
                break;

        }
        if(health <= 0)
        {
            state = State.Dead;
        }
    }

    private void IdleState()
    {

    }
    private void CHaseState()
    {

    }
    private void AttackState()
    {

    }
    private void DeadState()
    {

    }

    public enum State
    {
        None,
        Idle,
        Chase,
        Attack,
    
        Dead,
    }
    public enum StorPaellaPanna // Attacking state
    {
        None,
        LowState,
        MidState,
        HighState,
    }
    public enum PaellaPanne // Health state
    {
        None,
        HighHealt,
        LowHealth
    }



    
}
