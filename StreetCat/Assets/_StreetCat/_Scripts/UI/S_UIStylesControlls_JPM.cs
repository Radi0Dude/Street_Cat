using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_UIStylesControlls_JPM : MonoBehaviour
{
    [SerializeField]
    private GameObject attack;
    [SerializeField]
    private GameObject middle;
    [SerializeField]
    private GameObject defence;

    private void Update()
    {
        if (attack.transform.rotation != attack.transform.rotation)
        {
            attack.transform.rotation = attack.transform.rotation;
        }
        if (middle.transform.rotation != middle.transform.rotation)
        {
            middle.transform.rotation = middle.transform.rotation;
        }
        if (defence.transform.rotation != defence.transform.rotation)
        {
            defence.transform.rotation = defence.transform.rotation;
        }
        if (Input.GetKeyDown("1"))
        {
            attack.SetActive(true);
            middle.SetActive(false);
            defence.SetActive(false);
        }
        if (Input.GetKeyDown("2"))
        {
            attack.SetActive(false);
            middle.SetActive(true);
            defence.SetActive(false);
        }
        if (Input.GetKeyDown("3"))
        {
            attack.SetActive(false);
            middle.SetActive(false);
            defence.SetActive(true);
        }
    }

}
