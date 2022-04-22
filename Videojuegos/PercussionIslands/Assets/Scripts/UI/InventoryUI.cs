using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public void HandleUpdate(Action onBack){
        Debug.Log("IIIIIII");
        if (Input.GetKeyDown(KeyCode.X) | Input.GetKeyDown(KeyCode.O)){
            Debug.Log("Aaaaaa");
            onBack?.Invoke();
        }
    }
}
