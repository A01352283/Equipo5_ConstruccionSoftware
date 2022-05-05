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
    private GameObject rpgCamera;

    //Loads the minigame async
    public IEnumerator LoadMinigame(){

        if (minigameToLoad != null){
            SceneManager.sceneUnloaded += OnSceneUnloaded; //Starts checking the scenes that are unloaded

            yield return DialogueManager.Instance.ShowDialogueText($"Starting minigame!");
            SceneManager.LoadScene(minigameToLoad, LoadSceneMode.Additive); //Loads the scene additively
            
            //Finds the essential gameObjects from the esentialObjects prefab with the given names
            canvasUI = GameObject.Find("UI Canvas");
            audioManager = GameObject.Find("AudioManager");
            eventSystem = GameObject.Find("EventSystemEssential");
            player = GameObject.Find("Player");
            rpgCamera = GameObject.Find("RPG Main Camera");
            
            //Disables the objects so the other game is playable
            canvasUI.SetActive(false);
            audioManager.SetActive(false);
            eventSystem.SetActive(false);
            rpgCamera.SetActive(false);
            player.GetComponent<Character>().moveSpeed = 0f; //Disables player movement during the minigame
        }
    }

    private void OnSceneUnloaded(Scene current){
        //Debug.Log("OnSceneUnloaded " + current.name);
        
        //If the unloaded scene is the minigame that was loaded
        if (current.name == minigameToLoad && SceneManager.sceneCount <= 4){
            Debug.Log("Essentials Reloaded");
            //Reenables all the disabled objects from the essentialObjects prefab
            canvasUI.SetActive(true);
            audioManager.SetActive(true);
            eventSystem.SetActive(true);
            rpgCamera.SetActive(true);
            player.GetComponent<Character>().moveSpeed = 5f; //Reenables player movement
        }
    }

    //Used to check if a minigame can be started from this object
    public bool HasMinigameToStart(){
        if (minigameToLoad == ""){
            return false;
        }

        return true;
    }
}
