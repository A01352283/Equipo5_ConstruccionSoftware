using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState {FreeRoam, Dialogue, Paused, Menu, KeyInventory, NonKeyInventory, Minigame}

public class GameController : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] InventoryUI inventoryUI;
    
    GameState state;
    GameState prevState;

    public SceneDetails CurrentScene {get; private set;}
    public SceneDetails PrevScene {get; private set;}

    MenuController menuController;

    public static GameController Instance { get; private set;}

    private void Awake() {
        Instance = this;

        menuController = GetComponent<MenuController>();

        ItemDB.Init();
        QuestDB.Init();
    
        //Locks and hides the mouse cursor
        /* Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false; */
    }

    private void Start() {
        
        DialogueManager.Instance.OnShowDialogue += () =>//Lambda function to change the state
        {
            prevState = state;
            state = GameState.Dialogue; //Start dialogue state

        };    

        DialogueManager.Instance.OnCloseDialogue += () =>//Lambda function to change the state
        {   
            if (state == GameState.Dialogue){ //Turn back the state into free roam
                state = prevState;
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
            prevState = state;
            state = GameState.Paused;
        }
        else{
            state = prevState;
        }
    }

    private void Update() {
        if (state == GameState.FreeRoam){
            playerController.HandleUpdate();

            //Opens the menu UI on Enter key press
            if (Input.GetKeyDown(KeyCode.Return) | Input.GetKeyDown(KeyCode.Escape)){
                playerController.Character.Animator.isMoving = false; //Stops the walking animation when opening the menu
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
            SavingSystem.i.Save("saveSlot1");
            //Sets the state back to free roam
            state = GameState.FreeRoam;
        }
        else if (selectedItem == 2){
            //Load
            SavingSystem.i.Load("saveSlot1");
            //Sets the state back to free roam
            state = GameState.FreeRoam;
        }

    }
}
