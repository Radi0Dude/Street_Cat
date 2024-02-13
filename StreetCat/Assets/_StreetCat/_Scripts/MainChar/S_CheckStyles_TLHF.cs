using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_CheckStyles_TLHF : MonoBehaviour
{

    GameObject playerOneObject;
    GameObject playerTwoObject;

    int CheckAmountOfPlayers = 0;

    int playerOneStyle;
    int playerTwoStyle;

    public void OnPlayerJoinedEvent()
    {
        CheckAmountOfPlayers++;
        if(CheckAmountOfPlayers == 1)
        {
            playerOneObject = GameObject.FindGameObjectWithTag("Player");

		}
        if(CheckAmountOfPlayers == 2)
        {
            playerTwoObject = GameObject.FindGameObjectsWithTag("Player")[1];
        }
    }

	private void Update()
	{
        if(playerOneObject != null && playerTwoObject != null)
        {
            playerOneStyle = playerOneObject.GetComponent<S_HitboxCollider_TLHF>().styleChanger;  
            playerTwoStyle = playerTwoObject.GetComponent<S_HitboxCollider_TLHF>().styleChanger;  
            
            if(playerOneStyle == playerTwoStyle) 
            {
			    playerOneObject.GetComponent<S_HitboxCollider_TLHF>().attackDamageMultiplier = 1;
			    playerTwoObject.GetComponent<S_HitboxCollider_TLHF>().attackDamageMultiplier = 1;
		    }
            else if(playerOneStyle == 1 && playerTwoStyle == 3)
            {
			    playerOneObject.GetComponent<S_HitboxCollider_TLHF>().attackDamageMultiplier = 1.5f;
			    playerTwoObject.GetComponent<S_HitboxCollider_TLHF>().attackDamageMultiplier = 1;
		    }
            else if(playerOneStyle == 1 && playerTwoStyle == 2)
            {
			    playerOneObject.GetComponent<S_HitboxCollider_TLHF>().attackDamageMultiplier = 1f;
			    playerTwoObject.GetComponent<S_HitboxCollider_TLHF>().attackDamageMultiplier = 1.5f;
		    }
            else if(playerOneStyle == 2 && playerTwoStyle == 3)
            {
			    playerOneObject.GetComponent<S_HitboxCollider_TLHF>().attackDamageMultiplier = 1f;
			    playerTwoObject.GetComponent<S_HitboxCollider_TLHF>().attackDamageMultiplier = 1.5f;
		    }
            else if(playerOneStyle == 3 && playerTwoStyle == 1)
            {
			    playerOneObject.GetComponent<S_HitboxCollider_TLHF>().attackDamageMultiplier = 1f;
			    playerTwoObject.GetComponent<S_HitboxCollider_TLHF>().attackDamageMultiplier = 1.5f;
		    }
            else if(playerOneStyle == 2 && playerTwoStyle == 1)
            {
			    playerOneObject.GetComponent<S_HitboxCollider_TLHF>().attackDamageMultiplier = 1.5f;
			    playerTwoObject.GetComponent<S_HitboxCollider_TLHF>().attackDamageMultiplier = 1f;
		    }
            else if(playerOneStyle == 3 && playerTwoStyle == 2)
            {
			    playerOneObject.GetComponent<S_HitboxCollider_TLHF>().attackDamageMultiplier = 1.5f;
			    playerTwoObject.GetComponent<S_HitboxCollider_TLHF>().attackDamageMultiplier = 1f;
		    }
        }
        


      

	}
}
