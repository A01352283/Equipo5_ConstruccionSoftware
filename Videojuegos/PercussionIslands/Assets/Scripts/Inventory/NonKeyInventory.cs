using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum ItemCategory {NormalInstruments, KeyInstruments}

public class NonKeyInventory : MonoBehaviour
{
    [SerializeField] List<ItemSlot> slots;
    public List<ItemSlot> Slots => slots; //Exposes the slots

    public void UseItem(int itemIndex){
        var item = slots[itemIndex].Item;
        bool itemUsed = item.Use();

        if (itemUsed){
            
        }
    }

    //Decreased count of the item in the inventory
    public void removeItem(ItemBase item){
        var itemSlot = slots.First(slot => slot.Item == item);
        itemSlot.Count--;

        //Removes the item slot if there are no more items of this type left
        if (itemSlot.Count == 0)
            slots.Remove(itemSlot);
    }

    public static NonKeyInventory GetNonKeyInventory(){
        return FindObjectOfType<PlayerController>().GetComponent<NonKeyInventory>();
    }

    public void AddItem(ItemBase item, int count=1){

    }

    ItemCategory GetCategoryFromItem (ItemBase item){
         return ItemCategory.NormalInstruments;
    }

}

[Serializable]
public class ItemSlot{
    [SerializeField] ItemBase item;
    [SerializeField] int count;

    public ItemBase Item => item;
    public int Count{
        get => count;
        set => count = value;
    }
}