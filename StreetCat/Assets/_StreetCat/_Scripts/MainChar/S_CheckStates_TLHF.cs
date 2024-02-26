using NaughtyAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S_CheckStates_TLHF : MonoBehaviour
{
    private int style = 2;

    private bool fightingState = false;

    [SerializeField] 
    private Animator animator;

    [AnimatorParam("animator")]
    [SerializeField]
    private string fightingStateAnim;

    
	[SerializeField]
	private List<string> fightingStyleAnimList = new List<string>();

    

    [Scene]
    [SerializeField]
    private string oneVOneScene;
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
        CheckState();
		if(fightingState)
        {
            IsInFightingMode();
        }
        else
        {
            animator.SetBool(fightingStateAnim, false);
        }
	}

    private void CheckState()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 10);
        if(SceneManager.GetActiveScene().name == oneVOneScene)
        {
            IsInFightingMode();
        }
        else
        {
            for (int i = 0; i < colliders.Length; i++)
            {             
                if (colliders[i].transform.tag == "Enemy")
                {
                    IsInFightingMode();
                }
                else
                {
                    NormalMode();
                }            
            }
        }
    }

    private void NormalMode()
    {
        

        //Fighting styles
		animator.SetBool(fightingStyleAnimList[0], false);
		animator.SetBool(fightingStyleAnimList[1], false);
		animator.SetBool(fightingStyleAnimList[2], false);

        //Fighting State
		animator.SetBool(fightingStateAnim, true);
	}
    private void IsInFightingMode()
    {
        animator.SetBool(fightingStateAnim, true);

        //Normal Anim
		
		switch (style)
        {
            case 0:
                DefStyleAnim();
                break;
            case 1:
                MidStyleAnim();
                break;
            case 2:
                AggStyleAnim();
                break;
        }
    }

	

	private void DefStyleAnim()
	{
        animator.SetBool(fightingStyleAnimList[0], true);
        animator.SetBool(fightingStyleAnimList[1], false);
        animator.SetBool(fightingStyleAnimList[2], false);
	}
	private void MidStyleAnim()
	{
		animator.SetBool(fightingStyleAnimList[0], false);
		animator.SetBool(fightingStyleAnimList[1], true);
		animator.SetBool(fightingStyleAnimList[2], false);
	}
    private void AggStyleAnim()
	{
		animator.SetBool(fightingStyleAnimList[0], false);
		animator.SetBool(fightingStyleAnimList[1], false);
		animator.SetBool(fightingStyleAnimList[2], true);
	}
}
