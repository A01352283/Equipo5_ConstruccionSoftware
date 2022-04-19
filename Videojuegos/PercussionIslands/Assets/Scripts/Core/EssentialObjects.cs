using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EssentialObjects : MonoBehaviour
{
    private void Awake() {
        DontDestroyOnLoad(gameObject); //So the essential objects don't get destroyed when changing scenes
    }
}
