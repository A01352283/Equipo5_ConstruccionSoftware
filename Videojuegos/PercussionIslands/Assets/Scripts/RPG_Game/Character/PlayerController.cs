using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerController : MonoBehaviour, ISavable
{
    private Vector2 input;

    private Character character;

    private void Awake() {
        character = GetComponent<Character>();
    }

    // Update is called once per frame
    public void HandleUpdate()
    {   
        //When the player is not moving, take movement input from the player
        if (!character.isMoving){
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            //Remove diagonal movement
            if (input.x != 0) input.y = 0;
        
            //If we got player input indicate where the player will move
            if (input != Vector2.zero){
                StartCoroutine(character.Move(input, OnMoveOver));
            }
        }

        character.HandleUpdate();

        if (Input.GetKeyDown(KeyCode.I) | Input.GetKeyDown(KeyCode.Z)){
            StartCoroutine(Interact());
        }

    }

    //Reusable interaction system
    IEnumerator Interact(){
        var faceingDir = new Vector3(character.Animator.MoveX, character.Animator.MoveY);
        var interactPos = transform.position + faceingDir;

        var collider = Physics2D.OverlapCircle(interactPos, 0.3f, GameLayers.i.InteractableLayer);
        if (collider != null){
            yield return collider.GetComponent<Interactable>()?.Interact(transform);
        }   
    }

    IPlayerTriggerable currentlyInTrigger;

    private void OnMoveOver(){
        //Overlap circle only returns the first object which collides with it, so we use OverlapCircleAll, which returns an array
        var colliders = Physics2D.OverlapCircleAll(transform.position - new Vector3(0, character.OffsetY), 0.2f, GameLayers.i.TriggerableLayers);

        IPlayerTriggerable triggerable = null;

        foreach (var collider in colliders){
            triggerable = collider.GetComponent<IPlayerTriggerable>();

            if (triggerable != null){

                if (triggerable == currentlyInTrigger && triggerable.TriggerRepeatedly == false){
                    break;
                }

                triggerable.OnPlayerTriggered(this);
                currentlyInTrigger = triggerable;
                break;
            }
        }
        
        if (colliders.Count() == 0 || triggerable != currentlyInTrigger){
            currentlyInTrigger = null;
        }

    }


    //Save system interface implementataions
    //Saving
    public object CaptureState()
    {
        float[] position = new float[] { transform.position.x,  transform.position.y }; //Gets the x and y positions like this, since tranform.position is not serializable
        return position;
    }

    //Loading
    public void RestoreState(object state)
    {
        var position = (float[])state;
        transform.position = new Vector3(position[0], position[1]); //Converts the array back into a vector3
    }

    //Properties
    public Character Character => character;
}

