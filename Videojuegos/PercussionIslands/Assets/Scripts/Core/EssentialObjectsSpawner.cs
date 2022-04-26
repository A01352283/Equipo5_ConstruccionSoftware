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
            var spawnPos = new Vector3(0f, 0f, 0f); //Sets the spawn position of the player (helps testing the scenes independently)

            //Checks if there's a grid and spawns the player in the center of that grid
            var grid = FindObjectOfType<Grid>();
            if (grid != null){
                spawnPos = grid.transform.position;
            }

            //Instantiates the essential objects for the scene
            Instantiate(EssentialObjectsPrefab, spawnPos, Quaternion.identity);
        }
    }
}
