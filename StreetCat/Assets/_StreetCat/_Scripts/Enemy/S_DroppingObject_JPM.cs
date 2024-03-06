using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_DroppingObject_JPM : MonoBehaviour
{
    [SerializeField]
    private GameObject objectToDrop;

    [SerializeField]
    private GameObject ragdoll;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {      
        Instantiate(ragdoll, gameObject.transform.position, Quaternion.identity);
        Instantiate(objectToDrop, gameObject.transform.position,Quaternion.identity);
    }
}
