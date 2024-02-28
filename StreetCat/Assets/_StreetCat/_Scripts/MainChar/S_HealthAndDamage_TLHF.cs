using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class S_HealthAndDamage_TLHF : MonoBehaviour
{
    
    [ShowNonSerializedField]
    private int currentHealthAmount;
    [SerializeField]
    private int maxHealthAmount;

	[SerializeField] Slider healthslider;

	private void Start()
	{
		healthslider = GameObject.FindAnyObjectByType<Slider>();
		currentHealthAmount = maxHealthAmount;
		healthslider.maxValue = maxHealthAmount;
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
	private void Update()
	{
		healthslider.value = currentHealthAmount;
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
