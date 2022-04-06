using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState {FreeRoam, Dialogue}

public class GameController : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    GameState state;

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

    private void Update() {
        if (state == GameState.FreeRoam){
            playerController.HandleUpdate();
        }
        else if(state == GameState.Dialogue){
            DialogueManager.Instance.HandleUpdate();
        }
    }
}
