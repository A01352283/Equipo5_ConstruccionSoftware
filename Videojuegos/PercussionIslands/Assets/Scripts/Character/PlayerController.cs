using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
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
                StartCoroutine(character.Move(input));
            }
        }

        character.HandleUpdate();

        if (Input.GetKeyDown(KeyCode.I) | Input.GetKeyDown(KeyCode.Z)){
            Interact();
        }

    }

    //Reusable interaction system
    void Interact(){
        var faceingDir = new Vector3(character.Animator.MoveX, character.Animator.MoveY);
        var interactPos = transform.position + faceingDir;

        var collider = Physics2D.OverlapCircle(interactPos, 0.3f, GameLayers.i.InteractableLayer);
        if (collider != null){
            collider.GetComponent<Interactable>()?.Interact(transform);
        }
        
    }
}

