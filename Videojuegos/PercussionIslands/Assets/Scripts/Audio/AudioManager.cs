using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] List<AudioData> sfxList;
    [SerializeField] AudioSource musicPlayer;
    [SerializeField] AudioSource sfxPlayer;

    [SerializeField] float fadeDuration = 0.75f;

    AudioClip currentMusic;
    float originalMusicVolume;
    Dictionary<AudioID, AudioData> sfxLookup;

    public static AudioManager i { get; private set; } //Audio manager simpleton


    private void Awake() {
        i = this; //Initializes the audio manager
    }

    private void Start() {
        originalMusicVolume = musicPlayer.volume;

        sfxLookup = sfxList.ToDictionary(x => x.id);
    }

    //Plays sfx using a clip
    public void PlaySFX(AudioClip clip){
        if (clip == null) return;

        sfxPlayer.PlayOneShot(clip); //Plays the sound without cancelling the other music playing
    }

    //Plays sfx using the clip id
    public void PlaySFX(AudioID audioID){
        if (!sfxLookup.ContainsKey(audioID)) return;

        var audioData = sfxLookup[audioID];
        PlaySFX(audioData.clip);
    }

    //Plays the given music audio clip and decides if it will be looped
    public void PlayMusic(AudioClip clip, bool loop=true, bool fade=false){
        
        if (clip == null || clip == currentMusic){ //This also prevents the music from resetting if the two scenes have the same music
            return;
        }

        currentMusic = clip;
        StartCoroutine(PlayMusicAsync(clip, loop, fade));
        
    }

    //Fades the music transitions
    IEnumerator PlayMusicAsync(AudioClip clip, bool loop, bool fade){
        if (fade){
            yield return musicPlayer.DOFade(0, fadeDuration).WaitForCompletion();
        }

        musicPlayer.clip = clip;
        musicPlayer.loop = loop;
        musicPlayer.Play();

        if (fade){
            yield return musicPlayer.DOFade(originalMusicVolume, fadeDuration).WaitForCompletion();
        }
    }
    
}

public enum AudioID { UISelect, UIConfirm, UICancel, UICloseMenu, UIEquip, UIExit, UIOpenMenu, UIPause, UIResume, UISaved, UIShop, UIUnequip}

[Serializable]
public class AudioData{
    public AudioID id;
    public AudioClip clip;
}