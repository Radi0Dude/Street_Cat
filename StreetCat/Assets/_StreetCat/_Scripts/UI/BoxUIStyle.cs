using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BoxUIStyle : MonoBehaviour
{
    [SerializeField]
    private GameObject imageMiddle;
    [SerializeField]
    private GameObject imageDefense;
    [SerializeField]
    private GameObject imageAttack;
    private void UiMiddleStyle()
    {
        imageMiddle.SetActive(true);
        imageDefense.SetActive(false);
        imageAttack.SetActive(false);
    }
    private void UiDefenseStyle()
    {
        imageMiddle.SetActive(false);
        imageDefense.SetActive(true);
        imageAttack.SetActive(false);
    }
    private void UiAttackStyle()
    {
        imageMiddle.SetActive(false);
        imageDefense.SetActive(false);
        imageAttack.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetButtonDown("1"))
        {
            UiDefenseStyle();
        }

        if (Input.GetButtonDown("2"))
        {
            UiMiddleStyle();
        }

        if (Input.GetButtonDown("3"))
        {
            UiAttackStyle();
        }

    }
}

