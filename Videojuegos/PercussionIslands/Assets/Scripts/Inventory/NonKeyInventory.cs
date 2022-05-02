using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum ItemCategory {NormalInstruments, KeyInstruments}

public class NonKeyInventory : MonoBehaviour, ISavable
{
    [SerializeField] List<ItemSlot> slots;
    [SerializeField] List<ItemSlot> keySlots;

    List<List<ItemSlot>> allSlots;

    public event Action OnUpdated;

    private void Awake() {
        allSlots = new List<List<ItemSlot>>() { slots, keySlots };
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
            //RemoveItem(item); //Decreases the item count
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

        AudioManager.i.PlaySFX(AudioID.UIShop);

        OnUpdated?.Invoke(); //Calls OnUpdated so the changes are reflected in the UI
    }

    //Decreased count of the item in the inventory
    public void RemoveItem(ItemBase item){
        int category = (int)GetCategoryFromItem(item); //Finds the item's category
        var currentSlots = GetSlotsByCategory(category);

        var itemSlot = currentSlots.First(slot => slot.Item == item);
        itemSlot.Count--;

        //Removes the item slot if there are no more items of this type left
        if (itemSlot.Count == 0)
            currentSlots.Remove(itemSlot);

        OnUpdated?.Invoke();
    }

    //Checks if a certain item is in the player's inventory
    public bool HasItem(ItemBase item){
        int category = (int)GetCategoryFromItem(item); //Finds the item's category
        var currentSlots = GetSlotsByCategory(category);

        return currentSlots.Exists(slot => slot.Item == item); //Checks if the player has a slot for the item
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

    public object CaptureState()
    {
        //Gets all the names and counts of the items in all the categories
        var saveData = new InventorySaveData(){
            items = slots.Select(i => i.GetSaveData()).ToList(),
            keyItems = keySlots.Select(i => i.GetSaveData()).ToList()
        };

        return saveData;
    }

    public void RestoreState(object state)
    {
        var saveData = state as InventorySaveData;

        slots = saveData.items.Select(i => new ItemSlot(i)).ToList(); //Converts back to item slots objects
        keySlots = saveData.keyItems.Select(i => new ItemSlot(i)).ToList(); //Converts back to item slots objects

        allSlots = new List<List<ItemSlot>>() { slots, keySlots };

        OnUpdated?.Invoke();
    }
}

[Serializable]
public class ItemSlot{
    [SerializeField] ItemBase item;
    [SerializeField] int count;

    //Default constructor
    public ItemSlot() {

    }

    //So we can restore the item
    public ItemSlot(ItemSaveData saveData){
        item = ItemDB.GetObjectByName(saveData.name);
        count = saveData.count;
    }

    //To get the relevant info for saving the item in the ItemSaveData object
    public ItemSaveData GetSaveData(){
        var saveData = new ItemSaveData(){
            name = item.name,
            count = count
        };

        return saveData;
    }

    public ItemBase Item {
        get => item;
        set => item = value;
    }
    public int Count{
        get => count;
        set => count = value;
    }
}

[Serializable]
public class ItemSaveData{
    public string name;
    public int count;
}

[Serializable]
public class InventorySaveData{
    public List<ItemSaveData> items;
    public List<ItemSaveData> keyItems;
}