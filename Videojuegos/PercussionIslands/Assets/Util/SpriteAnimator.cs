using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAnimator
{
    SpriteRenderer spriteRenderer;
    List<Sprite> frames; //Stores the frames of each animation
    float frameRate;

    int currentFrame;
    float timer;

    public SpriteAnimator(List<Sprite> frames, SpriteRenderer spriteRenderer, float frameRate = 0.16f){
        this.frames = frames;
        this.spriteRenderer = spriteRenderer;
        this.frameRate = frameRate;
    }

    public void Start(){
        currentFrame = 0;
        timer = 0f;
        spriteRenderer.sprite = frames[0];
    }

    public void HandleUpdate(){
        timer += Time.deltaTime;
        if (timer > frameRate){
            currentFrame = (currentFrame + 1) % frames.Count; //If the current frame is the last frame, it loops back to the first
            spriteRenderer.sprite = frames[currentFrame];
            timer -= frameRate; //Resets the timer
        }


    }

    public List<Sprite> Frames{
        get {return frames;}
    }

}
