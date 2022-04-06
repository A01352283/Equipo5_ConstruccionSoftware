using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLayers : MonoBehaviour
{
    [SerializeField] LayerMask solidObjectsLayer;
    [SerializeField] LayerMask interactableLayer;
    [SerializeField] LayerMask playerLayer;

    //Using the singleton pattern to make the script easily accessed from any script
    public static GameLayers i {get; set;} //Named i to make this line of code smaller and neater

    private void Awake() {
        i = this;
    }


    public LayerMask SolidLayer{
        get => solidObjectsLayer; //Lambda to return solidObjectsLayer
    }

    public LayerMask InteractableLayer{
        get => interactableLayer; //Lambda to return interactableLayer
    }

    public LayerMask PlayerLayer{
        get => playerLayer; //Lambda to return playerLayer
    }
}
