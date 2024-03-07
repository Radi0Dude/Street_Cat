using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using UnityEditor.Animations;

[CreateAssetMenu]
public class S_AttackList_TLHF : ScriptableObject
{
    [Required("this is needed, also give this name to counter attack if you can counter")]
    
    public string attackName;

    [InfoBox("if true is high if false its low")]
    [SerializeField]
    public bool attackHighOrLow;

    public bool isUniversal;

    [ShowIf("showInt")]
    [InfoBox("1 is deffensive style, 2 is middle style, 3 is aggresive style", EInfoBoxType.Normal)]
    [MinValue(1), MaxValue(3)]
    public int style;

   

    public int damage;

    [InfoBox("How big is the collider?", EInfoBoxType.Normal)]
    public float range;

   

    [AnimatorParam("animator")]
    public string attackanim;

    
    public List<string> counter = new List<string>();

    public bool showInt { get { return !isUniversal; } set { showInt = false; } }

}
