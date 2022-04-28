using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum InventoryUIState { ItemSelection, Busy}

public class InventoryUI : MonoBehaviour
{
    [SerializeField] GameObject itemList;
    [SerializeField] ItemSlotUI itemSlotUI;

    [SerializeField] Text categoryText;
    [SerializeField] Image itemIcon;
    [SerializeField] Text itemDescription;

    [SerializeField] Image upArrow;
    [SerializeField] Image downArrow;

    const int itemsInViewPort = 7;
    int selectedItem = 0;
    int selectedCategory = 0;

    InventoryUIState state;

    List<ItemSlotUI> slotUIList;
    NonKeyInventory inventory;
    RectTransform itemListRect;

    private void Awake() {
        inventory = NonKeyInventory.GetNonKeyInventory();
        itemListRect = itemList.GetComponent<RectTransform>();
    }

    private void Start() {
        UpdateItemList();

        inventory.OnUpdated += UpdateItemList; //Subscribes to the OnUpdated event
    }

    void UpdateItemList(){
        //Clear all existing items
        foreach (Transform child in itemList.transform){
            Destroy(child.gameObject);
        }

        slotUIList = new List<ItemSlotUI>(); 
        foreach (var itemSlot in inventory.GetSlotsByCategory(selectedCategory)){
            var slotUIObj = Instantiate(itemSlotUI, itemList.transform);
            slotUIObj.SetData(itemSlot);
            
            slotUIList.Add(slotUIObj);
        }

        UpdateItemSelection();
    }

    public void HandleUpdate(Action onBack){
        
        if (state == InventoryUIState.ItemSelection){
            int prevSelection = selectedItem;
            int prevCategory = selectedCategory;    

            //Move within the menu
            if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)){ //Move down on the menu
                ++selectedItem;
                AudioManager.i.PlaySFX(AudioID.UISelect);
            }
            else if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)){ //Move up on the menu
                --selectedItem;
                AudioManager.i.PlaySFX(AudioID.UISelect);
            }
            else if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)){ //Move to left category
                --selectedCategory;
                AudioManager.i.PlaySFX(AudioID.UISelect);
            }
            else if(Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)){ //Move to right category
                ++selectedCategory;
                AudioManager.i.PlaySFX(AudioID.UISelect);
            }

            //Wraps the selection to the first/last item
            if (selectedCategory > NonKeyInventory.ItemCategories.Count - 1){
                selectedCategory = 0;
            }
            else if (selectedCategory < 0){
                selectedCategory = NonKeyInventory.ItemCategories.Count - 1;
            }

            //To prevent from going further than the existing menu options
            selectedItem = Mathf.Clamp(selectedItem, 0, inventory.GetSlotsByCategory(selectedCategory).Count - 1);

            //Updates the item list in the UI
            if (prevCategory != selectedCategory){
                ResetSelection();
                categoryText.text = NonKeyInventory.ItemCategories[selectedCategory];
                UpdateItemList();
            }
            //To prevent calling it when the selection is not changed
            else if (prevSelection != selectedItem)
            {
                UpdateItemSelection();
            }


            //Select action
            if (Input.GetKeyDown(KeyCode.Z) | Input.GetKeyDown(KeyCode.I)){
                
            }            
            //Cancel action
            else if (Input.GetKeyDown(KeyCode.X) | Input.GetKeyDown(KeyCode.O)){
                AudioManager.i.PlaySFX(AudioID.UICloseMenu);
                onBack?.Invoke();
            }
        }

    }

    IEnumerator UseItem(){
        state = InventoryUIState.Busy;

        var usedItem = inventory.UseItem(selectedItem, selectedCategory);
        if (usedItem != null){
            yield return DialogueManager.Instance.ShowDialogueText($"The player used {usedItem.Name}");
        }
        else{
            yield return DialogueManager.Instance.ShowDialogueText($"It won't have an effect");
        }
    }

    void UpdateItemSelection(){

        var slots = inventory.GetSlotsByCategory(selectedCategory);
        
        //Fixes edge case where the last item of the list is consumed and it had 1 left
        selectedItem = Mathf.Clamp(selectedItem, 0, slots.Count - 1);

        for (int i = 0; i < slotUIList.Count; i++){
            if (i == selectedItem){
                slotUIList[i].NameText.color = GlobalSettings.i.HighlightedColor;
            }
            else{
                slotUIList[i].NameText.color = Color.black;
            }
        }

        //Prevents errors when the category is empty
        if (slots.Count > 0){
            //Updates item and description on scroll
            var item = slots[selectedItem].Item;
            itemIcon.sprite = item.Icon;
            itemDescription.text = item.Description; 
        }

        HandleScrolling();
    }

    //Makes the selections go down when moving down the menu
    void HandleScrolling(){
        if (slotUIList.Count <= itemsInViewPort) return;

        float scrollPos = Mathf.Clamp(selectedItem - Mathf.FloorToInt(itemsInViewPort / 2), 0, selectedItem) * slotUIList[0].Height; //This makes the scrolling occur once the selection goes over half the items displayed in the viewport
        itemListRect.localPosition = new Vector2(itemListRect.localPosition.x, scrollPos);

        //Hides and shows selection arrows based on the current selection
        bool showUpArrow = selectedItem > Mathf.FloorToInt(itemsInViewPort / 2);
        upArrow.gameObject.SetActive(showUpArrow);

        bool showDownArrow = selectedItem + Mathf.FloorToInt(itemsInViewPort / 2) < slotUIList.Count;
        downArrow.gameObject.SetActive(showDownArrow);

    }

    void ResetSelection(){
        selectedItem = 0;
        upArrow.gameObject.SetActive(false);
        downArrow.gameObject.SetActive(false);

        itemIcon.sprite = null; //Resets the spirte
        itemDescription.text = "";

    }

}
