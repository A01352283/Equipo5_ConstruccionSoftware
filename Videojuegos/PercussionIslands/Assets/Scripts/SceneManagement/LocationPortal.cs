using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


//Teleports the player to a different position without changing scenes
public class LocationPortal : MonoBehaviour, IPlayerTriggerable
{
    [SerializeField] DestinationIdentifier destinationPortal;
    [SerializeField] Transform spawnPoint; //To set this, you have to first open the prefab and then set it. This prevents all instances of the prefab to be changed

    PlayerController player;

    public void OnPlayerTriggered(PlayerController player)
    {
        this.player = player;
        StartCoroutine(Teleport());
    }
    
    public bool TriggerRepeatedly => false;

    Fader fader;
    private void Start() {
        fader = FindObjectOfType<Fader>();
    }

    IEnumerator Teleport(){

        GameController.Instance.PauseGame(true); //This prevents the game from carrying on  the target position from the previous scene
        yield return fader.FadeIn(0.5f); //Fades the screen to black 

        var destPortal = FindObjectsOfType<LocationPortal>().First(x => x != this && x.destinationPortal == this.destinationPortal); //This function will return the first portal in the scene which is not the one we used to transfer
                                                                                                                             //it also connects portals to their destination portals
        player.Character.SetPositionAndSnapToTile(destPortal.spawnPoint.position);

        yield return fader.FadeOut(0.5f);
        GameController.Instance.PauseGame(false);
    }

    //Property to expose the spawn point
    public Transform SpawnPoint => spawnPoint;

}