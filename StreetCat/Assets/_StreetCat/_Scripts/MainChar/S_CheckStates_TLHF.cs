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

    
	

    [AnimatorParam("animator")]
    [SerializeField]
    private string defStyle;

    [AnimatorParam("animator")]
    [SerializeField]
    private string midStyle;

    [AnimatorParam("animator")]
    [SerializeField]
    private string aggStyle;


	[Scene]
    [SerializeField]
    private string oneVOneScene;

	private void Start()
	{
        style = 0;
	}
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
		animator.SetBool(defStyle, false);
		animator.SetBool(midStyle, false);
		animator.SetBool(aggStyle, false);

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
        animator.SetBool(defStyle, true);
        animator.SetBool(midStyle, false);
        animator.SetBool(aggStyle, false);
	}
	private void MidStyleAnim()
	{
		animator.SetBool(defStyle, false);
		animator.SetBool(midStyle, true);
		animator.SetBool(aggStyle, false);
	}
    private void AggStyleAnim()
	{
		animator.SetBool(defStyle, false);
		animator.SetBool(midStyle, false);
		animator.SetBool(aggStyle, true);
	}
}
