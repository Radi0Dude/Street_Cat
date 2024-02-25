using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

[CreateAssetMenu]
public class S_AttackList_TLHF : ScriptableObject
{
    [Required("this is needed, also give this name to counter attack if you can counter")]
    [SerializeField]
    private string attackName;

    [InfoBox("1 is deffensive style, 2 is middle style, 3 is aggresive style", EInfoBoxType.Normal)]
    [MinValue(1), MaxValue(3)]
    [SerializeField]
    private int style;

    [SerializeField]
    private int damage;

    [InfoBox("How big is the collider?", EInfoBoxType.Normal)]
    [SerializeField]
    private float range;

    [AnimatorParam("animator")]
    [SerializeField]
    private string attack;

    [SerializeField]
    private List<string> counter = new List<string>();


}
