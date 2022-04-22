 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour, Interactable
{

    [SerializeField] Dialogue dialogue; //Stores all the lines of dialogue for the NPC
    [SerializeField] List<Vector2> movementPattern; //Stores the pattern in which the NPC will move
    [SerializeField] float timeBetweenPattern; //Delay of pattern repetitions

    Character character;
    
    NPCState state;
    float IdleTimer = 0f; //Time where NPC will stay idle between pattern movements
    int currentMovementPattern = 0; //Current step of the movement pattern

    private void Awake() {
        character = GetComponent<Character>();
    }

    public IEnumerator Interact(Transform initiator){ //Initiator is the transform of the player that started the interaction
        //To have and instance of the dialogue manager and be able to call all the functions inside it
        if (state == NPCState.Idle){
            state = NPCState.Dialogue;
            character.LookToward(initiator.position);
            
            yield return DialogueManager.Instance.ShowDialogue(dialogue);

            IdleTimer = 0f;
            state = NPCState.Idle; //Lambda to change the state to idle, this prevents other NPC's to stop moving when talking to one of them
        }
    } 

    private void Update() {
        //Makes the NPC move in the given pattern with the given idle time between movements
        if(state == NPCState.Idle){
            IdleTimer += Time.deltaTime;
            if (IdleTimer > timeBetweenPattern){
                IdleTimer = 0f;
                if (movementPattern.Count > 0){
                    StartCoroutine(Walk());
                }
            }
        }

        character.HandleUpdate();
    }


    IEnumerator Walk(){
        state = NPCState.Walking;

        var oldPos = transform.position;
        
        yield return character.Move(movementPattern[currentMovementPattern]);

        //To know if the character walked in the previous pattern
        if (transform.position != oldPos){
            currentMovementPattern = (currentMovementPattern + 1) % movementPattern.Count; //So it goes back to the first on the last step
        } 



        state = NPCState.Idle;
    }
}


public enum NPCState{ Idle, Walking, Dialogue }