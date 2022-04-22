using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonKeyInventory : MonoBehaviour
{
    [SerializeField] List<ItemSlot> slots;
    public List<ItemSlot> Slots => slots; //Exposes the slots

    public static NonKeyInventory GetNonKeyInventory(){
        return FindObjectOfType<PlayerController>().GetComponent<NonKeyInventory>();
    }

}

[Serializable]
public class ItemSlot{
    [SerializeField] ItemBase item;
    [SerializeField] int count;

    public ItemBase Item => item;
    public int Count => count;
}