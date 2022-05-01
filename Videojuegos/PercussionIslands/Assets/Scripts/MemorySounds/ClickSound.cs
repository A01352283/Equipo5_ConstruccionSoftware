using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSound : MonoBehaviour
{

    public AudioSource instrumentButton;
    public AudioClip sound; 
    void Start()
    {
        instrumentButton.clip = sound;
    }

    // Update is called once per frame
    void PlaySound()
    {
        instrumentButton.Play();
    }
}
