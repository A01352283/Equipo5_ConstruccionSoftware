using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickSound : MonoBehaviour
{
    public AudioSource source { get { return GetComponent<AudioSource> (); }}
    public Button instrumentButton { get { return GetComponent<Button> (); }} // instrument button 
    public AudioClip clip; // clip of instrument 
    void Start()
    {
        gameObject.AddComponent<AudioSource>();
        instrumentButton.onClick.AddListener (PlaySound); // if the button is press, play sound 
    }

    void PlaySound()
    {
        source.PlayOneShot (clip);// is necesary only one shot to play the clip of instrument 
    }

/*
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
    */

    
}
