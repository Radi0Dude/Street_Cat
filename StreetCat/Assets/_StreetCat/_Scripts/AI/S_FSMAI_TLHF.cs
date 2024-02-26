using NaughtyAttributes;
using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class S_FSMAI_TLHF : S_EnemyFSM_TLHF
{    
    
    private State state;
    private StorPaellaPanna attackingState;
  
    [SerializeField]
    private float speed;
    [SerializeField] 
    private float attackStateSpeed;
    [SerializeField]
    private float health;
    [SerializeField]
    private float attackTime;

    [Tag]
    [SerializeField]
    private string playerTag;

    //universal bools
    private bool isDead;
    private bool isAttacking;
    private bool isBlocking;

    //idle state spesifics
    private bool idleTime;
    private float timeUnitlAnimChange;

    private GameObject player;

    
	//Animations
	#region
	private Animator animator;

	[Foldout("AnimationNames")]
	[AnimatorParam("animator")]
    [SerializeField]
    private string IdleAnim;

	[Foldout("AnimationNames")]
	[AnimatorParam("animator")]
    [SerializeField]
    private string deathAnim;

	[Foldout("AnimationNames")]
	[AnimatorParam("animator")]
    [SerializeField]
    private string defAnim;

	[Foldout("AnimationNames")]
	[AnimatorParam("animator")]
    [SerializeField]
    private string midAnim;

	[Foldout("AnimationNames")]
	[AnimatorParam("animator")]
    [SerializeField]
    private string aggAnim;
	#endregion

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
            case State.Patrol:
                PatrolState();
                break;


        }

        timeSinceStart = Time.deltaTime;
        if(health <= 0)
        {
            state = State.Attack;
        }
    }
    //Idle state;
	#region 
	private void IdleState()
    {
        //play idle animation
        if(idleTime == true)
        {
            timeUnitlAnimChange = timeSinceStart + Random.Range(5f, 15f);
            //choose random anim, and change it to that, also has a chance to change to patrol, and if there is multiple enemies whitin range they will patrol togheter
            idleTime = false;
        }      
        if(timeUnitlAnimChange <= timeSinceStart && idleTime == false)
        {

        }
        //check its look dir, if player is in the direction it is looking and if player is whitin looking range and the looking dir is towards player change to chase
    }
	#endregion
	//Patrol State
	#region
	private void PatrolState()
    {
		//at start create two wanderpoints and walk between them, also find refrence to other players and have them walk with 
		//check its look dir, if player is in the direction it is looking and if player is whitin looking range and the looking dir is towards player change to chase
	}

	#endregion
	//Chase state
	#region
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
	#endregion
	//Dead State
	#region
	private void DeadState()
    {
        if (!isDead)
        {
            isDead = true;
            //playe death anim

            Destroy(gameObject, 10f);
        }
    }
	#endregion
	//Attacking state
	#region
	private void AttackState()
    {
        destination = playerPos.position;

        float distance = Vector3.Distance(transform.position, playerPos.position);

        if(distance >= 10)
        {
            state = State.Chase;
        }

        switch (attackingState) 
        { 
            case StorPaellaPanna.DefState:
                DefensiveState(destination, distance);
                break;
            case StorPaellaPanna.MidState:
                MiddleState(destination, distance);
                break;
            case StorPaellaPanna.AggState:
                AggresiveState(destination, distance);
                break;
        }
    }
	#endregion
	//defensive state
	#region
	private void DefensiveState(Vector3 dest, float dist)
	{
        //play Defensive state animation
        List<ScriptableObject> usableAttacks = new List<ScriptableObject>();
        for (int i = 0; i < attacks.Count; i++)
        {
            if (attacks[i].style == 1)
            {
                usableAttacks.Add(attacks[i]);
            }

            
        }

	}
	#endregion

    //Middle state;
	#region
	private void MiddleState(Vector3 dest, float dist)
	{
        List<ScriptableObject> usableAttacks = new List<ScriptableObject>();
        for(int i = 0; i < attacks.Count; i++)
        {
            if (attacks[i].style == 2)
            {
                usableAttacks.Add(attacks[i]);
            }
        }

	}
	#endregion

	//Aggresive State
	#region 
	private void AggresiveState(Vector3 dest, float dist)
	{
        //play aggresive state animation
        List<ScriptableObject> usableAttacks = new List<ScriptableObject>();
        for(int i = 0; i < attacks.Count; i++)
        {
            if (attacks[i].style == 3)
            {
                usableAttacks.Add(attacks[i]);
            }
        }

	}
	#endregion


    //All the different states
	#region
	public enum State
    {
        Idle,
        Chase,
        Patrol,
        Attack,
        Dead,
    }
	#endregion

    //Here are the different attacking states
	#region
	public enum StorPaellaPanna // Attacking state
    {
        DefState,
        MidState,
        AggState,
    }
	#endregion




    
}
