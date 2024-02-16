using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S_UiOnTriggerShow_JPM : MonoBehaviour
{
    [SerializeField]
    private Canvas canvas;

    bool isEmpty;
    private void FixedUpdate()
    {
        isEmpty = true;
        if (isEmpty)
        {
            canvas.gameObject.SetActive(false);

        }
    }
    private void OnTriggerStay(Collider other)
    {
        isEmpty = false;
        if(other.tag == "Player")
        {
            canvas.gameObject.SetActive(true);
            Debug.Log("Hello");
        }
       
    }   
}
