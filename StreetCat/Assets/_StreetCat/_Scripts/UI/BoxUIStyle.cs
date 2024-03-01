using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BoxUIStyle : MonoBehaviour
{
    [SerializeField]
    GameObject imageMiddle;
    [SerializeField]
    GameObject imageDefense;
    [SerializeField]
    GameObject imageAttack;
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
}

