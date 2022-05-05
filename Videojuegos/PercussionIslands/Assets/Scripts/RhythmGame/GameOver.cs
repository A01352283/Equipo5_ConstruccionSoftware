using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    //Script that invokes the game over screen.
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        Invoke("FinishGame", 70f);
    }

    void FinishGame()
    {
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}