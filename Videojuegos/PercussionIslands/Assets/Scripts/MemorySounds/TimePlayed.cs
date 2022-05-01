using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimePlayed : MonoBehaviour
{
    public int playTime = 0; // time played - to manipulate played / used in playerprefs 
    public Text Time_text; 
    private int seconds = 0; 
    private int minutes = 0;
    private int hours = 0;
    //private bool timeVisible = true; 
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine ("PlayTimer");
    }

    private IEnumerator PlayTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            playTime +=1;
            seconds =(playTime % 60);
            minutes = (playTime / 60) % 60; 
            hours = (playTime /3600) % 24;
        }
    }

    void OnGUI()
    {
        /*
        if (GUI.Button(new Rect(100,100,40,40), "ShowTime"))
        if (timeVisible)
        timeVisible = false;
        else
        timeVisible = true; 

        if (timeVisible)
        GUI.Label(new Rect(50,50,400,50), "Playtime = " + hours.ToString() + " Hours " + minutes.ToString() + " Minutes " + seconds.ToString() + " Seconds ");*/
        Time_text.text = "Time: "  + minutes.ToString() + ":" + seconds.ToString() + " Min ";
    }
}
