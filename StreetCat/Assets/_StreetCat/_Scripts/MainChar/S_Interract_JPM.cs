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

	[Scene]
	[SerializeField]
	string sceneName;

	bool canChangeScene;

	private void OnTriggerStay(Collider other)
	{
		if (other.tag == interactTag)
		{
			canChangeScene = true;
			
		}
	}
	private void OnTriggerExit(Collider other)
	{
		if (other.tag == interactTag)
		{
			canChangeScene = false;

		}
	}
	private void Update()
	{
		if(canChangeScene)
		{
			if(Input.GetKeyUp(KeyCode.E)) 
			{
				SceneManager.LoadScene(sceneName);
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
