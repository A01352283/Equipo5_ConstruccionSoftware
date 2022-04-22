using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState {FreeRoam, Dialogue, Paused, Menu, KeyInventory}

public class GameController : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] InventoryUI inventoryUI;
    
    GameState state;
    GameState stateBeforePause;

    public SceneDetails CurrentScene {get; private set;}
    public SceneDetails PrevScene {get; private set;}

    MenuController menuController;

    public static GameController Instance { get; private set;}

    private void Awake() {
        Instance = this;

        menuController = GetComponent<MenuController>();
    }

    private void Start() {
        
        DialogueManager.Instance.OnShowDialogue += () =>//Lambda function to change the state
        {
            state = GameState.Dialogue; //Start dialogue state

        };    

        DialogueManager.Instance.OnCloseDialogue += () =>//Lambda function to change the state
        {   
            if (state == GameState.Dialogue){ //Turn back the state into free roam
                state = GameState.FreeRoam;
            }
            
        };  

        //Lambda to change the state back to free roam when closing the menu
        menuController.onBack += () => 
        {
            state = GameState.FreeRoam;
        };

        //Subscribes to the menu selection event
        menuController.onMenuSelected += OnMenuSelected;
    }

    //This is used to prevent the game from carrying on the targetpos from the previous scene
    public void PauseGame(bool pause){
        if (pause){   
            stateBeforePause = state;
            state = GameState.Paused;
        }
        else{
            state = stateBeforePause;
        }
    }

    private void Update() {
        if (state == GameState.FreeRoam){
            playerController.HandleUpdate();

            //Opens the menu UI on Enter key press
            if (Input.GetKeyDown(KeyCode.Return)){
                menuController.OpenMenu();
                state = GameState.Menu;
            }

        }
        else if(state == GameState.Dialogue){
            DialogueManager.Instance.HandleUpdate();
        }
        else if(state == GameState.Menu){
            menuController.HandleUpdate();
        }
        else if (state == GameState.KeyInventory){
            
            Action onBack = () =>
            {
                inventoryUI.gameObject.SetActive(false);
                state = GameState.FreeRoam;
            };

            inventoryUI.HandleUpdate(onBack);
        }
    }

    public void SetCurrentScene(SceneDetails currScene){
        PrevScene = CurrentScene;
        CurrentScene = currScene;
    }

    //Actions for each menu item
    void OnMenuSelected (int selectedItem){
        if (selectedItem == 0){
            //Inventory
            inventoryUI.gameObject.SetActive(true);
            state = GameState.KeyInventory;
        }
        else if (selectedItem == 1){
            //Save
            state = GameState.FreeRoam;
        }
        else if (selectedItem == 2){
            //Load
            state = GameState.FreeRoam;
        }

        //Sets the state back to free roam
        state = GameState.FreeRoam;
    }
}
