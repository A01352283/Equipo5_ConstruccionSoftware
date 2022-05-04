using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneDetails : MonoBehaviour
{
    [SerializeField] List<SceneDetails> connectedScenes;
    [SerializeField] AudioClip sceneMusic;

    public bool IsLoaded {get; private set;}

    List<SavableEntity> savableEntities;

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
            var prevScene = GameController.Instance.PrevScene;

            if (prevScene != null){
                var previouslyLoadesScenes = prevScene.connectedScenes;
                
                foreach (var scene in previouslyLoadesScenes){
                    if (!connectedScenes.Contains(scene) && scene != this){
                        scene.UnloadScene();
                    }
                }   
                
                //Unloads the previous scene if it's not connected to the previous scene. This unloads scenes when using the load game button.
                if (!connectedScenes.Contains(prevScene))
                    prevScene.UnloadScene();
            }
        }
    }

    public void LoadScene(){
        if (!IsLoaded)
            {
                var operation = SceneManager.LoadSceneAsync(gameObject.name, LoadSceneMode.Additive); //Loads the scenes additively without destroying the currently open scenes
                IsLoaded = true;

                //This lambda is called once the scene loading is complete. Loads the savableentities sates when scene is loaded
                operation.completed += (AsyncOperation op) =>{
                    savableEntities = GetSavableEntitiesInScene();
                    SavingSystem.i.RestoreEntityStates(savableEntities);
                };

            }
    }

    public void UnloadScene(){
    if (IsLoaded){
            //Saves the scene state when the scene is unloaded
            SavingSystem.i.CaptureEntityStates(savableEntities);

            SceneManager.UnloadSceneAsync(gameObject.name);
            IsLoaded = false;
        }
    }

    List<SavableEntity> GetSavableEntitiesInScene(){
        var currScene = SceneManager.GetSceneByName(gameObject.name);
        var saveableEntities = FindObjectsOfType<SavableEntity>().Where(x => x.gameObject.scene == currScene).ToList(); //Find the saveable entities in the current scene

        return saveableEntities;
    }
}
