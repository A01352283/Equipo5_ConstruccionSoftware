using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Interaction;
using System.IO;
using UnityEngine.Networking;

public class SongManager : MonoBehaviour
{
    //Song manager script.
    public static SongManager Instance;
    public AudioSource audioSource;
    public Lane[] lanes;
    public float songDelayInSeconds;
    public double marginOfError; //In seconds
    public int inputDelayInMilliseconds;
    public float timeRemaining = 64;
    public bool timerIsRunning = false;
    //public bool ToggleChange;


    public string fileLocation;
    public float noteTime;
    public float noteSpawnX;
    public float noteTapX;
    public float noteDespawnX
    {
        get
        {
            return noteTapX - (noteSpawnX - noteTapX);
        }
    } 


    public static MidiFile midiFile;

    // Start is called before the first frame update
    //Starta coroutine read from website.
    void Start()
    {
        timerIsRunning = true;
        Instance = this;
        if (Application.streamingAssetsPath.StartsWith("http://") || Application.streamingAssetsPath.StartsWith("https://"))
        {
            StartCoroutine(ReadFromWebsite());
        }
        else{
            ReadFromFile();
        }
    }
    private IEnumerator ReadFromWebsite(){
        using (UnityWebRequest www = UnityWebRequest.Get(Application.streamingAssetsPath + "/" + fileLocation)){
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
                {
                    Debug.LogError(www.error);
                }
                else
                {
                    byte[] results = www.downloadHandler.data;
                    using (var stream = new MemoryStream(results))
                    {
                        midiFile = MidiFile.Read(stream);
                        GetDataFromMidi();
                    }
                }
        }
    }

    private void ReadFromFile(){
        midiFile = MidiFile.Read(Application.streamingAssetsPath + "/" + fileLocation);
        GetDataFromMidi();
    }

    public void GetDataFromMidi(){
        var notes = midiFile.GetNotes();
        var array = new Melanchall.DryWetMidi.Interaction.Note[notes.Count];
        notes.CopyTo(array, 0);
        
        foreach (var lane in lanes) lane.SetTimeStamps(array);
        
        Invoke(nameof(StartSong), songDelayInSeconds);


    }

    public void StartSong(){
        //ToggleChange = true;
        audioSource.Play();
    }

    public static double GetAudioSourceTime(){
        return (double)Instance.audioSource.timeSamples / Instance.audioSource.clip.frequency;
    }

    /*public void Timer{
        float timer = 61.5f
        
        StartCoroutine(FadeOut(audioSource, 10f));
    }*/
    //Fadeout function
    public static IEnumerator FadeOut (AudioSource audioSource, float FadeTime) {
        float startVolume = audioSource.volume;
 
        while (audioSource.volume > 0) {
            audioSource.volume -= startVolume * Time.deltaTime / FadeTime;
 
            yield return null;
        }
 
        audioSource.Stop ();
        audioSource.volume = startVolume;
        //GameOver.setActive(true);
    }
    //Timer that displays fadeout
    // Update is called once per frame
    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
                StartCoroutine(FadeOut(audioSource, 8f));
            }
        }
    }
}
