using NaughtyAttributes;
using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

//This is simple FSM and will be more random
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

    float timeToChangeStyle;
    bool changeStyle;
    float timeToBeStunned;
    int gotHitTimes;
    float timeSinceLatHit;

    
    
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
    private string attackStateAnim;

    [Foldout("AnimationNames")]
    [AnimatorParam("animator")]
    [SerializeField]
    private string defensiveStyleAnim;

    [Foldout("AnimationNames")]
    [AnimatorParam("animator")]
    [SerializeField]
    private string middleStyleAnim;

    [Foldout("AnimationNames")]
    [AnimatorParam("animator")]
    [SerializeField]
    private string aggresiveStyleAnim;

    [Foldout("AnimationNames")]
    [AnimatorParam("animator")]
    [SerializeField]
    private string isBlockinAnim;
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
        Debug.Log(playerPos.position + "Hello");

	}

    protected override void FMSUpdate()
	{
		Debug.Log(playerPos.position + "Hello");
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
            case State.Stunned:
                StunnedState();
                break;
		}

        timeSinceStart = Time.realtimeSinceStartup;
        if(health <= 0)
        {
            state = State.Attack;
        }
    }

    public void GotHit(float[] attackAndStun)
    {
        if(isBlocking)
        {
            //PlayAnim hit whilst blocking;
        }
        else
        {
            timeToBeStunned = attackAndStun[0] + timeSinceStart;
            SendMessage("TakeDamage", attackAndStun[1]);
            state = State.Stunned;
            if(timeSinceLatHit + 1 < timeSinceStart)
            {   timeSinceLatHit = timeSinceStart;
                gotHitTimes++;
            }
            else
            {
                gotHitTimes = 0;
            }
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
        if(Vector3.Distance(this.transform.position, playerPos.position) <= 30)
        {
            state = State.Chase;
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

        Vector3 dir = playerPos.position - transform.position;
        if (dist <= 10)
        {
            state = State.Attack;
        }
        else if (dist >= 50)
        {
            state = State.Idle;
        }

        transform.Translate(dir.normalized * speed * Time.deltaTime);
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

    private void StunnedState()
    {
        if(timeToBeStunned > timeSinceStart)
        {
            //Play Stunned Anim/Hit Anim
        }
        else
        {
            state = State.Attack;
        }
    }
	//Attacking state
	#region
	private void AttackState()
    {
        destination = playerPos.position;
        Vector3 dir = new Vector3(playerPos.position.x - transform.position.x, transform.position.y, playerPos.position.z - transform.position.z);
        float distance = Vector3.Distance(transform.position, playerPos.position);

        animator.SetBool(attackStateAnim, true);

        if (changeStyle)
        {

            timeToChangeStyle = timeSinceStart + Random.Range(10, 20); 
            attackingState = (StorPaellaPanna)Random.Range(0, 2);
            changeStyle = false;
        }

        if(timeToChangeStyle == timeSinceStart && !changeStyle)
        {
            changeStyle = true;
        }
        if(distance >= 10)
        {
            state = State.Chase;
        }

        if(dir.z < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
			if (distance >= 1f)
			{
				transform.Translate(-dir.normalized * attackStateSpeed * Time.deltaTime);
			}
		}
        else if(dir.z > 0) 
        {
			transform.rotation = Quaternion.Euler(0, 0, 0);
			if (distance >= 1f)
			{
				transform.Translate(dir.normalized * attackStateSpeed * Time.deltaTime);
			}
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
        animator.SetBool(defensiveStyleAnim, true);
        animator.SetBool(middleStyleAnim, false);
        animator.SetBool(aggresiveStyleAnim, false);
        if(gotHitTimes >= 2)
        {
            isBlocking = true;
        }
        if(isBlocking)
        {
            animator.SetBool(isBlockinAnim, true);
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
		animator.SetBool(defensiveStyleAnim, false);
		animator.SetBool(middleStyleAnim, true);
		animator.SetBool(aggresiveStyleAnim, false);
		if (gotHitTimes >= 2)
		{
			isBlocking = true;
		}
		if (isBlocking)
		{
			animator.SetBool(isBlockinAnim, true);
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
		animator.SetBool(defensiveStyleAnim, false);
		animator.SetBool(middleStyleAnim, false);
		animator.SetBool(aggresiveStyleAnim, true);
		if (gotHitTimes >= 2)
		{
			isBlocking = true;
		}
		if (isBlocking)
		{
            animator.SetBool(isBlockinAnim, true);
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
		Stunned,
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
