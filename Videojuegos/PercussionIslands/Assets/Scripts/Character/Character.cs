using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    //Movement variables
    public float moveSpeed;

    //Properties
    public bool isMoving {get; private set;}
    public float OffsetY {get ; private set;} = 0.3f; //This is the offset that gives perspective to the characters in relation to the environment
    CharacterAnimator animator;

    private void Awake() {
        animator = GetComponent<CharacterAnimator>();
        SetPositionAndSnapToTile(transform.position);
    }

    //To automate the snapping of gameobjects to the middle of tiles
    public void SetPositionAndSnapToTile(Vector2 pos){
        pos.x = Mathf.Floor(pos.x) + 0.5f;
        pos.y = Mathf.Floor(pos.y) + 0.5f + OffsetY;

        transform.position = pos;
    }

    //Move the player
    public IEnumerator Move(Vector2 moveVector, Action OnMoveOver = null){

        animator.MoveX = Mathf.Clamp(moveVector.x, -1f, 1f);
        animator.MoveY = Mathf.Clamp(moveVector.y, -1f, 1f);

        var targetPos = transform.position;
        targetPos.x += moveVector.x;
        targetPos.y += moveVector.y;

        if(!IsPathClear(targetPos))
            yield break; //Stops the coroutine


        isMoving = true;

        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon){ //Whle the current position and the target position are bigger than a really small value
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime); //Moves the player a small amount
            yield return null; //Stops the current execution, to resume it in the next update
        }
        transform.position = targetPos; //Updates the current position

        isMoving = false;

        OnMoveOver?.Invoke(); //Uses null conditional operator so it won't get called when it0s null
    }

    public void HandleUpdate(){
        animator.isMoving = isMoving;
    }

    //This checks if all of the tiles between current position and target position are walkable
    //to prevent the NPC's from walking through objects
    private bool IsPathClear(Vector3 targetPosition){
        var diff = targetPosition - transform.position; //To determine where the boxcast will face, this is a vector
        var dir = diff.normalized; //Makes the length of the diff vector equal to 1

        //Adds the dir vector at the start, to make the box start from the tile next to the NPC, 
        //the subtraction to the magnitude compemsates for that. The boxcast returns true if there is a collider in the area of the box
        if (Physics2D.BoxCast(transform.position + dir, new Vector2(0.2f, 0.2f), 0f, dir, diff.magnitude - 1, GameLayers.i.SolidLayer | GameLayers.i.InteractableLayer | GameLayers.i.PlayerLayer) == true){
            return false; //Path is not clear
        } 

        return true; //Path is clear
    }


    //Check if the tile next to the character has a collider that prevents movement to that position
    private bool IsWalkable(Vector3 targetPos){

        if (Physics2D.OverlapCircle(targetPos, 0.3f, GameLayers.i.SolidLayer | GameLayers.i.InteractableLayer) != null){ //Checks if the collider overlaps with a circular area and checks if it is in the solid object layer
            return false;
        }

        return true;
    }

    //Makes the NPC look towards the player when being talked to 
    public void LookToward(Vector3 targetPos){
        var xdiff = Mathf.Floor(targetPos.x) - Mathf.Floor(transform.position.x); //Floor is used to return the value in number of tiles
        var ydiff = Mathf.Floor(targetPos.y) - Mathf.Floor(transform.position.y); //Floor is used to return the value in number of tiles

        //This is to only make the NPC look U, D, L or R, in other words, the same x or y coord
        if (xdiff == 0 || ydiff == 0){
            animator.MoveX = Mathf.Clamp(xdiff, -1f, 1f);
            animator.MoveY = Mathf.Clamp(ydiff, -1f, 1f);
        }
        else{
            Debug.LogError("Error in LookToward. You can't ask the NPC to look diagonally");
        }
    }

    //Property to get the character animator
    public CharacterAnimator Animator{
        get => animator;
    }
}
