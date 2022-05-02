using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstrumentPreview : MonoBehaviour
{

    public int instrumentID;
    public GameObject instrumentPreview;
    public AudioClip Sound;
    public bool innactive;
    public MemoryS_Manager gameManager;
    //Color baseColor; 
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void StartListSound()
    {
        innactive = false; 
        instrumentPreview.gameObject.SetActive(true);
        //AudioSource.PlayClipAtPoint(Sound);
    }
}

