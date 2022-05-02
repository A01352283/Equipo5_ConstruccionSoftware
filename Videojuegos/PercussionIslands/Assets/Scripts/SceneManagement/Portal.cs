using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour, IPlayerTriggerable
{
    [SerializeField] int sceneToLoad = -1; //-1 is so we get an error if we forget to set this from the editor
    [SerializeField] DestinationIdentifier destinationPortal;
    [SerializeField] Transform spawnPoint; //To set this, you have to first open the prefab and then set it. This prevents all instances of the prefab to be changed

    PlayerController player;

    public void OnPlayerTriggered(PlayerController player)
    {
        this.player = player;
        StartCoroutine(SwitchScene());
    }
    
    public bool TriggerRepeatedly => false;

    Fader fader;
    private void Start() {
        fader = FindObjectOfType<Fader>();
    }

    IEnumerator SwitchScene(){

        DontDestroyOnLoad(gameObject);

        GameController.Instance.PauseGame(true); //This prevents the game from carrying on  the target position from the previous scene
        yield return fader.FadeIn(0.5f); //Fades the screen to black 

        //LoadSceneAsync can wait till the scene is loaded. Works like a corroutine
        yield return SceneManager.LoadSceneAsync(sceneToLoad);

        var destPortal = FindObjectsOfType<Portal>().First(x => x != this && x.destinationPortal == this.destinationPortal); //This function will return the first portal in the scene which is not the one we used to transfer
                                                                                                                             //it also connects portals to their destination portals
        player.Character.SetPositionAndSnapToTile(destPortal.spawnPoint.position);

        yield return fader.FadeOut(0.5f);
        GameController.Instance.PauseGame(false);
        
        Destroy(gameObject);
    }

    //Property to expose the spawn point
    public Transform SpawnPoint => spawnPoint;

}

public enum DestinationIdentifier { A, B, C, D, E, F}