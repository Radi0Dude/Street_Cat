using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_UIStylesControlls_JPM : MonoBehaviour
{
    [SerializeField]
    private GameObject attack;
    [SerializeField]
    private GameObject middle;
    [SerializeField]
    private GameObject defence;

	[Tag]
	[SerializeField] private string UITag;

	private void Start()
	{
		attack = GameObject.FindGameObjectsWithTag(UITag)[2];
		middle = GameObject.FindGameObjectsWithTag(UITag)[0];
		defence = GameObject.FindGameObjectsWithTag(UITag)[1];
		
	}

	public void DefensiveStyle()
    {
		attack.SetActive(true);
		middle.SetActive(false);
		defence.SetActive(false);
	}

    public void MiddleStyle()
    {
		attack.SetActive(false);
		middle.SetActive(true);
		defence.SetActive(false);
	}

    public void AggresiveStyle()
    {
		attack.SetActive(false);
		middle.SetActive(false);
		defence.SetActive(true);
	}
}
