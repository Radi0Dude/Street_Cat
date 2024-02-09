using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;

public class S_HealthAndDamage_TLHF : MonoBehaviour
{
    
    [ShowNonSerializedField]
    private int currentHealthAmount;
    [SerializeField]
    private int maxHealthAmount;

	private void Start()
	{
		currentHealthAmount = maxHealthAmount;
	}
	private void TakeDamage(int amount)
    {
        if (currentHealthAmount > 0)
        {
			currentHealthAmount -= amount;
			Debug.Log(currentHealthAmount);
		}
		if (currentHealthAmount <= 0)
		{
			Destroy(gameObject);
		}
    }

	private void OnBecameInvisible()
	{
		StartCoroutine(Inpact());
	}

	IEnumerator Inpact()
	{

		yield return new WaitForSeconds(.25f);
	}

}
