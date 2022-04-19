using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EssentialObjectsSpawner : MonoBehaviour
{
    [SerializeField] GameObject EssentialObjectsPrefab;

    private void Awake() {
        var existingObjects = FindObjectsOfType<EssentialObjects>();

        //If there isn't another of the same prefab
        if (existingObjects.Length == 0){
            Instantiate(EssentialObjectsPrefab, new Vector3 (0f, 0f, 0f), Quaternion.identity);
        }
    }
}
