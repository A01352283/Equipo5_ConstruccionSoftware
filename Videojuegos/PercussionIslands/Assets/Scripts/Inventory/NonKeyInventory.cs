using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum ItemCategory {NormalInstruments, KeyInstruments}

public class NonKeyInventory : MonoBehaviour
{
    [SerializeField] List<ItemSlot> slots;
    [SerializeField] List<ItemSlot> keySlots;

    List<List<ItemSlot>> allSlots;

    public event Action OnUpdated;

    private void Awake() {
        allSlots = new List<List<ItemSlot>>() { slots, keySlots};
    }

    public static List<string> ItemCategories { get; set;} = new List<string>(){
        "Instruments", "Key Instruments"
    };

    //Returns all the slot categories of items
    public List<ItemSlot> GetSlotsByCategory(int categoryIndex){
        return allSlots[categoryIndex];
    }

    public ItemBase UseItem(int itemIndex, int selectedCategory){
        var currentSlots = GetSlotsByCategory(selectedCategory);

        var item = currentSlots[itemIndex].Item;
        bool itemUsed = item.Use();

        if (itemUsed){
            //RemoveItem(item, selectedCategory); //Decreases the item count
            return item;
        }

        return null; //The item was not used
    }

    public void AddItem(ItemBase item, int count=1){
        int category = (int)GetCategoryFromItem(item); //Returns the category as an enum if we don't convert it
        var currentSlots = GetSlotsByCategory(category);

        var itemSlot = currentSlots.FirstOrDefault(slot => slot.Item == item); //If the item has a slot, it will return it, otherwise it returns a null

        if (itemSlot != null){ //Adds 1 to the count of that item if there are items of that type in the inventory
            itemSlot.Count += count;
        }
        else{ //Adds the item to the inventory if there wasn't one of that type
            currentSlots.Add(new ItemSlot(){
                Item = item,
                Count = count
            });
        }

        OnUpdated?.Invoke(); //Calls OnUpdated so the changes are reflected in the UI
    }

    //Decreased count of the item in the inventory
    public void RemoveItem(ItemBase item, int category){
        var currentSlots = GetSlotsByCategory(category);

        var itemSlot = slots.First(slot => slot.Item == item);
        itemSlot.Count--;

        //Removes the item slot if there are no more items of this type left
        if (itemSlot.Count == 0)
            currentSlots.Remove(itemSlot);

        OnUpdated.Invoke();
    }

    public static NonKeyInventory GetNonKeyInventory(){
        return FindObjectOfType<PlayerController>().GetComponent<NonKeyInventory>();
    }

    ItemCategory GetCategoryFromItem (ItemBase item){
        
        if (item is KeyInstruments){
            return ItemCategory.KeyInstruments;
        }
        else{
            return ItemCategory.NormalInstruments;
        }
    }

}

[Serializable]
public class ItemSlot{
    [SerializeField] ItemBase item;
    [SerializeField] int count;

    public ItemBase Item {
        get => item;
        set => item = value;
    }
    public int Count{
        get => count;
        set => count = value;
    }
}