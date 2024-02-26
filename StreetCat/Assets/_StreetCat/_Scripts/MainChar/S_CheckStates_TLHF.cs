using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_CheckStates_TLHF : MonoBehaviour
{
    private int style = 2;

    private bool fightingState = false;

    [SerializeField] 
    private Animator animator;

    [AnimatorParam("animator")]
    [SerializeField]
    private string fightingStateAnim;

	[AnimatorParam("animator")]
	[SerializeField]
	private List<string> fightingStateAnimList = new List<string>();

	public void DefStyle()
    {
        style = 0;
    }
    public void MidStyle()
    {
        style = 1;
    }
    public void AggStyle()
    {
		style = 2;
	}

	private void Update()
	{
		if(fightingState)
        {
            IsInFightingMode();
        }
        else
        {
            animator.SetBool(fightingStateAnim, false);
        }
	}

    private void IsInFightingMode()
    {
        animator.SetBool(fightingStateAnim, true);
    }

}
