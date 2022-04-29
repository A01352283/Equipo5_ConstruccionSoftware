using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/Create new key instrument")]

public class KeyInstruments : ItemBase
{
    [Header("KeyInstrument")]
    [SerializeField] AudioSource audioSource;
}
