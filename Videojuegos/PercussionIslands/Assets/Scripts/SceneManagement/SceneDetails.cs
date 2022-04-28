using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneDetails : MonoBehaviour
{
    [SerializeField] List<SceneDetails> connectedScenes;
    [SerializeField] AudioClip sceneMusic;

    public bool IsLoaded {get; private set;}

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "Player"){
            Debug.Log($"Entered {gameObject.name}");
            
            LoadScene();
            GameController.Instance.SetCurrentScene(this);

            if (sceneMusic != null)
                AudioManager.i.PlayMusic(sceneMusic, fade: true); //Plays the music of the scene when it is loaded

            //Load all connected scenes
            foreach (var scene in connectedScenes){
                scene.LoadScene();
            }

            //Unload scenes that are no longer connected
            if (GameController.Instance.PrevScene != null){
                var previouslyLoadesScenes = GameController.Instance.PrevScene.connectedScenes;
                
                foreach (var scene in previouslyLoadesScenes){
                    if (!connectedScenes.Contains(scene) && scene != this){
                        scene.UnloadScene();
                    }
                }
            }
        }
    }

    public void LoadScene(){
        if (!IsLoaded)
            {
                SceneManager.LoadSceneAsync(gameObject.name, LoadSceneMode.Additive); //Loads the scenes additively without destroying the currently open scenes
                IsLoaded = true;
            }
    }

    public void UnloadScene(){
    if (IsLoaded){
            SceneManager.UnloadSceneAsync(gameObject.name);
            IsLoaded = false;
        }
    }
}
