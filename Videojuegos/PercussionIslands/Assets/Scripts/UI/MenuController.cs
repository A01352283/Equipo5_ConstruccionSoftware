using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class MenuController : MonoBehaviour
{
    [SerializeField] GameObject menu; 

    public event Action<int> onMenuSelected; //We pass the selected item as a parameter
    public event Action onBack;

    List<Text> menuItems;
    
    int selectedItem = 0;
    
    private void Awake() {
        menuItems = menu.GetComponentsInChildren<Text>().ToList();
    }

    //Shows the menu UI
    public void OpenMenu(){
        menu.SetActive(true);
        UpdateItemSelection();
    }

    //Closes the menu UI
    public void CloseMenu(){
        menu.SetActive(false);
    }

    public void HandleUpdate(){
        
        int prevSelection = selectedItem;

        //Move within the menu
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)){ //Move down on the menu
            ++selectedItem;
        }
        else if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)){ //Move up on the menu
            --selectedItem;
        }

        //To prevent from going further than the existing menu options
        selectedItem = Mathf.Clamp(selectedItem, 0, menuItems.Count - 1);

        //To prevent calling it when the selection is not changed
        if (prevSelection != selectedItem)
        {
            UpdateItemSelection();
        }

        //Menu confirm action
        if (Input.GetKeyDown(KeyCode.Z) | Input.GetKeyDown(KeyCode.I)){
            onMenuSelected?.Invoke(selectedItem);
            CloseMenu();
        }
        else if (Input.GetKeyDown(KeyCode.X) | Input.GetKeyDown(KeyCode.O)){ //Menu cancel action
            onBack?.Invoke();
            CloseMenu();
        }

    }

    //Highlights the currently selected color
    void UpdateItemSelection(){
        for (int i = 0; i < menuItems.Count; i++){
            if (i == selectedItem){
                menuItems[i].color = GlobalSettings.i.HighlightedColor;
            }
            else{
                menuItems[i].color = Color.black;
            }
        }
    }
}
