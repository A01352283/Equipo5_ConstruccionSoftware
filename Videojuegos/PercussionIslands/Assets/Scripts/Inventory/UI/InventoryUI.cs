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

    [SerializeField] Image itemIcon;
    [SerializeField] Text itemDescription;

    [SerializeField] Image upArrow;
    [SerializeField] Image downArrow;

    const int itemsInViewPort = 7;
    int selectedItem = 0;

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
    }

    void UpdateItemList(){
        //Clear all existing items
        foreach (Transform child in itemList.transform){
            Destroy(child.gameObject);
        }

        slotUIList = new List<ItemSlotUI>(); 
        foreach (var itemSlot in inventory.Slots){
            var slotUIObj = Instantiate(itemSlotUI, itemList.transform);
            slotUIObj.SetData(itemSlot);
            
            slotUIList.Add(slotUIObj);
        }

        UpdateItemSelection();
    }

    public void HandleUpdate(Action onBack){
        
        if (state == InventoryUIState.ItemSelection){
            int prevSelection = selectedItem;

            //Move within the menu
            if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)){ //Move down on the menu
                ++selectedItem;
            }
            else if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)){ //Move up on the menu
                --selectedItem;
            }

            //To prevent from going further than the existing menu options
            selectedItem = Mathf.Clamp(selectedItem, 0, inventory.Slots.Count - 1);

            //To prevent calling it when the selection is not changed
            if (prevSelection != selectedItem)
            {
                UpdateItemSelection();
            }


            //Select action
            if (Input.GetKeyDown(KeyCode.Z) | Input.GetKeyDown(KeyCode.I)){
                
            }            
            //Cancel action
            else if (Input.GetKeyDown(KeyCode.X) | Input.GetKeyDown(KeyCode.O)){
                onBack?.Invoke();
            }
        }

    }

    void UpdateItemSelection(){
        for (int i = 0; i < slotUIList.Count; i++){
            if (i == selectedItem){
                slotUIList[i].NameText.color = GlobalSettings.i.HighlightedColor;
            }
            else{
                slotUIList[i].NameText.color = Color.black;
            }
        }

        //Updates item and description on scroll
        var item = inventory.Slots[selectedItem].Item;
        itemIcon.sprite = item.Icon;
        itemDescription.text = item.Description; 

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

}
