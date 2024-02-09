using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S_Interract_JPM : MonoBehaviour
{

    [Layer]
    [SerializeField]
    private string interractLayer;

    [SerializeField]
    Collider thisInteract;
    
    
    public void Interract(Collider collider)
    {
        Collider[] colliders = Physics.OverlapBox(thisInteract.bounds.center, thisInteract.bounds.extents, Quaternion.identity, LayerMask.GetMask(interractLayer));
        foreach (Collider col in colliders) 
        {
            if(col.transform.root == transform)
            {
                continue;
            }
            switch (col.tag)
            {

                case "Interract":
                    col.SendMessageUpwards("Interractable");
                    break;
            }
            
        }
    }
    
   
}