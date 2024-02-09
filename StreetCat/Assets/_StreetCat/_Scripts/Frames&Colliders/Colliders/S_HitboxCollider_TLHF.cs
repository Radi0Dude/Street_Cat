using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

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

	public void MidAttaclKick()
	{
		if(!cooldownMidhAttack)
		{
			kickAttack(attackHitboxes[0]);
			StartCoroutine(Cooldown());
			Debug.Log("Ohh youre soooo good at hitting this button *Bites lip* (Mid attack)");
		}


	}
	public void LowAttackKick()
	{
		if (!cooldownLowAttack)
		{
			kickAttack(attackHitboxes[1]);
			StartCoroutine(Cooldown());		
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

	IEnumerator Cooldown()
	{
		cooldownLowAttack = true;
		cooldownMidhAttack = true;
		yield return new WaitForSeconds(1);
		cooldownMidhAttack = false;
		cooldownLowAttack = false;
	}
}
