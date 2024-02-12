using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S_Interract_JPM : MonoBehaviour
{

    [Tag]
    [SerializeField]
    private string interactTag;

    [SerializeField]
    Collider thisInteract;

	private void OnTriggerStay(Collider other)
	{
		if (other.tag == interactTag)
		{

			if (Input.GetKeyDown(KeyCode.E))
			{

				other.GetComponent<S_Interractable_JPM>().Interractable();
			}
		}
	}

	

	//public void Interract(Collider collider)
 //   {
 //       Collider[] colliders = Physics.OverlapBox(thisInteract.bounds.center, thisInteract.bounds.extents, Quaternion.identity, LayerMask.GetMask(interractLayer));
 //       foreach (Collider col in colliders) 
 //       {
 //           if(col.transform.root == transform)
 //           {
 //               continue;
 //           }
 //           switch (col.tag)
 //           {

 //               case "Interract":
 //                   col.SendMessageUpwards("Interractable");
 //                   break;
 //           }
            
 //       }
 //   }
    
   
}
