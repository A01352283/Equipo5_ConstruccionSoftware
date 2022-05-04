using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This enables creating instances of the item
[CreateAssetMenu(menuName = "Items/Create new non key instrument")]

public class NonKeyInstruments : ItemBase
{   
    [Header("NonKeyInstrument")]
    
    [SerializeField] AudioClip instrumentSound;

    public override bool Use()
    {
        return false;   
    }

}
