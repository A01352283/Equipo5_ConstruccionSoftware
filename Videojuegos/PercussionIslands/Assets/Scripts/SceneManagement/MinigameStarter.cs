using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MinigameStarter : MonoBehaviour
{
    [SerializeField] string minigameToLoad;
    private GameObject canvasUI;
    private GameObject audioManager;
    private GameObject eventSystem;
    private GameObject player;

    //Loads the minigame async
    public IEnumerator LoadMinigame(){

        if (minigameToLoad != null){
            SceneManager.sceneUnloaded += OnSceneUnloaded; //Starts checking the scenes that are unloaded

            yield return DialogueManager.Instance.ShowDialogueText($"Starting {minigameToLoad}!");
            SceneManager.LoadScene(minigameToLoad, LoadSceneMode.Additive); //Loads the scene additively
            
            //Finds the essential gameObjects from the esentialObjects prefab with the given names
            canvasUI = GameObject.Find("UI Canvas");
            audioManager = GameObject.Find("AudioManager");
            eventSystem = GameObject.Find("EventSystemEssential");
            player = GameObject.Find("Player");
            
            //Disables the objects so the other game is playable
            canvasUI.SetActive(false);
            audioManager.SetActive(false);
            eventSystem.SetActive(false);
            player.GetComponent<Character>().moveSpeed = 0f; //Disables player movement during the minigame
        }
    }

    private void OnSceneUnloaded(Scene current){
        //Debug.Log("OnSceneUnloaded " + current.name);
        
        //If the unloaded scene is the minigame that was loaded
        if (current.name == minigameToLoad){
            Debug.Log("Essentials Reloaded");
            //Reenables all the disabled objects from the essentialObjects prefab
            canvasUI.SetActive(true);
            audioManager.SetActive(true);
            eventSystem.SetActive(true);
            player.GetComponent<Character>().moveSpeed = 5f; //Reenables player movement
        }
    }
}
