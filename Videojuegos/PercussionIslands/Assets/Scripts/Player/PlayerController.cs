using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Movement variables
    public float moveSpeed;
    public LayerMask solidObjectsLayer;

    private bool isMoving;
    private Vector2 input;

    private Animator animator;

    private void Awake() {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {   
        //When the player is not moving, take movement input from the player
        if (!isMoving){
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            //Remove diagonal movement
            if (input.x != 0) input.y = 0;
        
            //If we got player input indicate where the player will move
            if (input != Vector2.zero){
                animator.SetFloat("moveX", input.x);
                animator.SetFloat("moveY", input.y);

                var targetPos = transform.position;
                targetPos.x += input.x;
                targetPos.y += input.y;

                if (IsWalkable(targetPos)){
                    StartCoroutine(Move(targetPos));
                }
            }
        }

        animator.SetBool("isMoving", isMoving);

    }

    //Move the player
    IEnumerator Move(Vector3 targetPos){
        isMoving = true;

        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon){ //Whle the current position and the target position are bigger than a really small value
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime); //Moves the player a small amount
            yield return null; //Stops the current execution, to resume it in the next update
        }
        transform.position = targetPos; //Updates the current position

        isMoving = false;
    }

    //Checks if the objective is an obstacle to determine if the player can move there
    private bool IsWalkable(Vector3 targetPos){

        if (Physics2D.OverlapCircle(targetPos, 0.3f, solidObjectsLayer) != null){ //Checks if the collider overlaps with a circular area and checks if it is in the solid object layer
            return false;
        }

        return true;
    }
}
