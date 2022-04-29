//This functions generates the buttons that will detect when the user selects a specific memory card inside the game 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddButtons : MonoBehaviour
{
    [SerializeField]
    private Transform puzzleField;

    [SerializeField]
    private GameObject btn;
    void Awake(){
        //Loop that creates the buttons and set them inside the puzzle field
        for(int i=0; i<18; i++){
            GameObject button = Instantiate(btn);
            button.name= ""+ i;
            button.transform.SetParent(puzzleField, false);
        }
    }
}
