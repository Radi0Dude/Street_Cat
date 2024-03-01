using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_UiLDA : MonoBehaviour
{
    [SerializeField] public CanvasGroup myUIGroup;
    [SerializeField] private bool fadeIn = false;
    [SerializeField] private bool fadeOut = false;


    public void ShowUI()
    {
        fadeIn = true;
    }

    public void HideUI() 
    {
        fadeOut = true;
    }
    private void Update()
    {
       
        if (fadeIn)
        {
            if (myUIGroup.alpha < 1)
            {
                myUIGroup.alpha += Time.deltaTime;
                if(myUIGroup.alpha >= 1)
                {
                    fadeIn = false; 
                }
            }
        }
        if (fadeOut) 
        {
            if(myUIGroup.alpha >= 1)
            {
                myUIGroup.alpha += Time.deltaTime;
                if ( myUIGroup.alpha >= 1)
                {
                    fadeIn = false;
                }
            }
        }
    }  
}
