using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;

using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class S_HitboxCollider_TLHF : MonoBehaviour
{
    public Collider[] attackHitboxes;

	[Layer]
	[SerializeField] 
	string hurtBoxLayer;

	[Tag]
	[SerializeField]
	string hurtBoxTag;

	[Tag]
	[SerializeField]
	string enemyTag;

	[ReadOnly]
	public int styleChanger;

	float attackDamage;
	bool cooldownMidhAttack;
	bool cooldownLowAttack;

	[SerializeField]
	Material mats;

	[SerializeField]
	private Animator animator;

	[AnimatorParam("animator")]
	[SerializeField]
	private string lowAttack;

	[AnimatorParam("animator")]
	[SerializeField]
	private string highAttack;

	[SerializeField]
	float timeToBeStunned;
	

	private void Start()
	{
		animator = GetComponent<Animator>();
	}
	public void MidAttaclKick()
	{
		if(!cooldownMidhAttack)
		{
			animator.SetTrigger(highAttack);

			StartCoroutine(CooldownHigh());
			Debug.Log("(Mid attack)");
		}
		

	}
	public void LowAttackKick()
	{
		if (!cooldownLowAttack)
		{
			animator.SetTrigger(lowAttack);			


			StartCoroutine(CooldownLow());	
			Debug.Log("(Low attack)");
		}
		

	}

	public void StyleMid()
	{
		styleChanger = 1;
		
	}
	public void StyleDef()
	{
		styleChanger = 2;
	}
	public void StyleAtck()
	{
		styleChanger = 3;
	}

	public void StyleChanger()
	{
		switch(styleChanger)
		{
			case 1:
				mats.color = Color.green;

				break;
			case 2:
				mats.color = Color.red;

                break;
			case 3:
				mats.color = Color.blue;

                break;

		}
	}

	private void Update()
	{
		StyleChanger();
		//When frameData is done i can add the whole thing here or to a fixedUpdate

		//if(!cooldownLowAttack)
		//{
		//	attackHitboxes[0].transform.gameObject.SetActive(false);
		//}
		//else
		//{
		//	attackHitboxes[0].transform.gameObject.SetActive(true);
		//}
		//if(!cooldownMidhAttack)
		//{
		//	attackHitboxes[1].transform.gameObject.SetActive(false);
		//}
		//else
		//{
		//	attackHitboxes[1].transform.gameObject.SetActive(true);
		//}
	}

	//
	private void kickAttack(Collider collider)
	{
		Debug.Log(collider.name);
		Debug.Log(collider.bounds + "This is bounds");
		Debug.Log(collider.bounds.extents + "THis is extents");
	
		Collider[] cols = Physics.OverlapBox(collider.bounds.center, collider.bounds.extents, Quaternion.identity, LayerMask.GetMask(hurtBoxLayer));
		Debug.Log(cols.Length);
		foreach (Collider col in cols)
		{
			Debug.Log(col.transform.root.name);
			if(col.transform.root == transform) 
				continue;
			float attackDamage = 0f;
			switch(col.tag)
			{
				case "HurtBox":
					attackDamage = 30;
					Debug.Log("Herlo");

				break;
				default:
					Debug.Log("Make Sure that it be a hurtBox");	
				break;
				
			}
			if(transform.root.tag == "Player")
			{
				col.SendMessageUpwards("TakeDamage", attackDamage);
			}

			if(transform.root.tag == enemyTag)
			{
				float[] sentObjects = new float[2];
				sentObjects[0] = timeToBeStunned;
				sentObjects[1] = attackDamage;
				col.SendMessageUpwards("gotHit", sentObjects);
			}

		}
	}

	IEnumerator CooldownHigh()
	{
		
		cooldownMidhAttack = true;
		kickAttack(attackHitboxes[0]);
		yield return new WaitForSeconds(0.5f);
		animator.SetBool(highAttack, false);
		cooldownMidhAttack = false;
	}
	IEnumerator CooldownLow()
	{
		
		cooldownLowAttack = true;
		kickAttack(attackHitboxes[1]);
		yield return new WaitForSeconds(0.5f);
		animator.SetBool(lowAttack, false);
		cooldownLowAttack = false;
	}
}
