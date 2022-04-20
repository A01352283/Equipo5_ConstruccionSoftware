using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState {FreeRoam, Dialogue, Paused}

public class GameController : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    
    GameState state;
    GameState stateBeforePause;

    public SceneDetails CurrentScene {get; private set;}
    public SceneDetails PrevScene {get; private set;}

    public static GameController Instance { get; private set;}

    private void Awake() {
        Instance = this;
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
        }
        else if(state == GameState.Dialogue){
            DialogueManager.Instance.HandleUpdate();
        }
    }

    public void SetCurrentScene(SceneDetails currScene){
        PrevScene = CurrentScene;
        CurrentScene = currScene;
    }
}
