using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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

	[Layer]
	[SerializeField]
	string hurtBoxTag;

	int styleChanger;

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

	

	private void Start()
	{
		animator = GetComponent<Animator>();
	}
	public void MidAttaclKick()
	{
		if(!cooldownMidhAttack)
		{
			animator.SetTrigger(highAttack);
			kickAttack(attackHitboxes[0]);
			StartCoroutine(CooldownHigh());
			Debug.Log("Ohh youre soooo good at hitting this button *Bites lip* (Mid attack)");
		}
		

	}
	public void LowAttackKick()
	{
		if (!cooldownLowAttack)
		{
			animator.SetTrigger(lowAttack);
			kickAttack(attackHitboxes[1]);
			StartCoroutine(CooldownLow());		
			Debug.Log("Ohh youre soooo good at hitting this button *Bites lip* (Low arrack)");
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

		if(!cooldownLowAttack)
		{
			attackHitboxes[0].transform.gameObject.SetActive(false);
		}
		else
		{
			attackHitboxes[0].transform.gameObject.SetActive(true);
		}
		if(!cooldownMidhAttack)
		{
			attackHitboxes[1].transform.gameObject.SetActive(false);
		}
		else
		{
			attackHitboxes[1].transform.gameObject.SetActive(true);
		}
	}

	private void kickAttack(Collider collider)
	{

		Collider[] cols = Physics.OverlapBox(collider.bounds.center, collider.bounds.extents, Quaternion.identity, LayerMask.GetMask(hurtBoxLayer));
		foreach (Collider col in cols)
		{
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
			col.SendMessageUpwards("TakeDamage", attackDamage);
		}
	}

	IEnumerator CooldownHigh()
	{
		cooldownMidhAttack = true;
		yield return new WaitForSeconds(0.5f);
		animator.SetBool(highAttack, false);
		cooldownMidhAttack = false;
	}
	IEnumerator CooldownLow()
	{
		cooldownLowAttack = true;
		yield return new WaitForSeconds(0.5f);
		animator.SetBool(lowAttack, false);
		cooldownLowAttack = false;
	}
}
