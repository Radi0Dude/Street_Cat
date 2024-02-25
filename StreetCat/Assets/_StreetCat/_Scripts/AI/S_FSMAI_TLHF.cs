using NaughtyAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_FSMAI_TLHF : S_EnemyFSM_TLHF
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

	//Animations
	private Animator animator;

	[AnimatorParam("animator")]
    [SerializeField]
    private string IdleAnim;

    [AnimatorParam("animator")]
    [SerializeField]
    private string deathAnim;

    [AnimatorParam("animator")]
    [SerializeField]
    private string defAnim;

    [AnimatorParam("animator")]
    [SerializeField]
    private string midAnim;

    [AnimatorParam("animator")]
    [SerializeField]
    private string aggAnim;

    [SerializeField]
    private List<S_AttackList_TLHF> attacks = new List<S_AttackList_TLHF>();


	protected override void Initialize()
    {
        state = State.Idle;
        attackingState = StorPaellaPanna.MidState;
        
        isDead = false;

        animator = GetComponent<Animator>();

        player = GameObject.FindGameObjectWithTag(playerTag);

		playerPos = player.transform;


	}

    protected override void FMSUpdate()
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

        timeSinceStart = Time.deltaTime;
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
        destination = playerPos.position;

        float dist = Vector3.Distance(transform.position, playerPos.position);

        if (dist <= 10)
        {
            state = State.Attack;
        }
        else if (dist >= 50)
        {
            state = State.Idle;

        }

        transform.Translate(playerPos.position * Time.deltaTime * speed);
    }


    private void DeadState()
    {
        if (!isDead)
        {
            isDead = true;
            //playe death anim

            Destroy(gameObject, 10f);
        }
    }
    private void AttackState()
    {
        destination = playerPos.position;

        float distamce = Vector3.Distance(transform.position, playerPos.position);

        if(distamce >= 10)
        {
            state = State.Chase;
        }

        switch (attackingState) 
        { 
            case StorPaellaPanna.DefState:
                DefensiveState(destination, distamce);
                break;
            case StorPaellaPanna.MidState:
                MiddleState(destination, distamce);
                break;
            case StorPaellaPanna.AggState:
                AggresiveState(destination, distamce);
                break;
        }
    }

	
	private void DefensiveState(Vector3 dest, float dist)
	{
        
	}
	private void MiddleState(Vector3 dest, float dist)
	{

	}
	private void AggresiveState(Vector3 dest, float dist)
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
        DefState,
        MidState,
        AggState,
    }
    public enum PaellaPanne // Health state
    {
        None,
        HighHealt,
        LowHealth
    }



    
}
