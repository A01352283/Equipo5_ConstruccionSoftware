using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{

    [SerializeField] List<Sprite> walkDownSprites;
    [SerializeField] List<Sprite> walkUpSprites;
    [SerializeField] List<Sprite> walkLeftSprites;
    [SerializeField] List<Sprite> walkRightSprites;

    //Parameters
    public float MoveX {get; set;}
    public float MoveY {get; set;}
    public bool isMoving {get; set;}

    //States
    SpriteAnimator walkDownAnim;
    SpriteAnimator walkUpAnim;
    SpriteAnimator walkLeftAnim;
    SpriteAnimator walkRightAnim;

    SpriteAnimator currentAnim;
    bool wasPreviouslyMoving;

    //References
    SpriteRenderer spriteRenderer;

    private void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        //Initializes all the animations
        walkDownAnim = new SpriteAnimator(walkDownSprites, spriteRenderer);
        walkUpAnim = new SpriteAnimator(walkUpSprites, spriteRenderer);
        walkLeftAnim = new SpriteAnimator(walkLeftSprites, spriteRenderer);
        walkRightAnim = new SpriteAnimator(walkRightSprites, spriteRenderer);

        currentAnim = walkDownAnim;
    }

    private void Update() {

        var prevAnim = currentAnim;

        if (MoveX == 1)
            currentAnim = walkRightAnim;
        else if (MoveX == -1)
            currentAnim = walkLeftAnim;
        else if (MoveY == -1)
            currentAnim = walkDownAnim;
        else if (MoveY == 1)
            currentAnim = walkUpAnim;
        

        if (currentAnim != prevAnim || isMoving != wasPreviouslyMoving) //The current animation must change
            currentAnim.Start(); 


        if (isMoving == true)
            currentAnim.HandleUpdate();
        else
            spriteRenderer.sprite = currentAnim.Frames[0]; //Sets it to the first sprite of the sprite renderer

        wasPreviouslyMoving = isMoving;
    }

}   
