using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickSound : MonoBehaviour
{
    public AudioSource source { get { return GetComponent<AudioSource> (); }}
    public Button instrumentButton { get { return GetComponent<Button> (); }}
    public AudioClip clip; 
    void Start()
    {
        gameObject.AddComponent<AudioSource>();
        instrumentButton.onClick.AddListener (PlaySound);
    }

    void PlaySound()
    {
        source.PlayOneShot (clip);
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
