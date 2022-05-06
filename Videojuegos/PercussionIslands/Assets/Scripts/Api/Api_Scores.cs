/*
Script that allows the connection of Unity with the API in orde to store the last score and time played of a minigame
Salvador Salgado Normanida
*/

using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
// Allow the class to be extracted from Unity
// https://stackoverflow.com/questions/40633388/show-members-of-a-class-in-unity3d-inspector


// Allow the class to be extracted from Unity
//Class Trivia_Score will contain the information that will be send in the api call for updating the score and play time from the Trivia Minigame
[System.Serializable]
public class Trivia_Score
{
    public string user_name;
    public int user_id;
    public int trivia_last_score;
    public string trivia_play_time;
}

//Class Trivia_Score will contain the information that will be send in the api call for updating the score and play time from the Mmeory Minigame
[System.Serializable]
public class Memory_Score
{
    public string user_name;
    public int user_id;
    public int memory_last_score;
    public string memory_play_time;
}

//Class Trivia_Score will contain the information that will be send in the api call for updating the score and play time from the MemorySounds Minigame
[System.Serializable]
public class MemorySounds_Score
{
    public string user_name;
    public int user_id;
    public int memorysounds_last_score;
    public string memorysounds_play_time;
}

//Class Trivia_Score will contain the information that will be send in the api call for updating the score and play time from the Rhythm Minigame
[System.Serializable]
public class Rhythm_Score
{
    public string user_name;
    public int user_id;
    public int rhythm_last_score;
    public string rhythm_play_time;
}


public class Api_Scores : MonoBehaviour
{   
    //This string are required to establish the connection with the correct API call
    [SerializeField] string url;
    [SerializeField] string getEP;
    //This string defines which minigame will be updated
    [SerializeField] string mg_type;

    string _id;
    string data;

    // This is where the information from the api will be extracted
    public Trivia_Score trivia_score;
    public Memory_Score memory_score;
    public MemorySounds_Score memorysounds_score;
    public Rhythm_Score rhythm_score;
    // Update is called once per frame

    //This functions begins the update score. It recieves the score from the minigame as well as the time played
    public void UpdateScore(int _score,string time)
    {
    //when cliked button login loop hasta que haga match
        //We begin the coroutin by also including mg_type that specifies the minigame that was played
       StartCoroutine(UpScore(mg_type, _score, time));
    }

    public void RegsiterPage(){
        SceneManager.LoadScene(5);
    }

    IEnumerator UpScore(string m_game,int _score, string _time)
    {   
        //Depending on the m_game we build the object that will be send in the API call
        if(m_game=="trivia"){
            trivia_score= new Trivia_Score();
            trivia_score.user_name=PlayerPrefs.GetString("user_name");
            trivia_score.trivia_last_score=_score;
            trivia_score.trivia_play_time=_time;
            data=JsonUtility.ToJson(trivia_score);
        }
        else if(m_game=="memory"){
            memory_score= new Memory_Score();
            memory_score.user_name=PlayerPrefs.GetString("user_name");
            memory_score.memory_last_score=_score;
            memory_score.memory_play_time=_time;
            data=JsonUtility.ToJson(memory_score);
        }
        else if(m_game=="memorysounds"){
            memorysounds_score= new MemorySounds_Score();
            memorysounds_score.user_name=PlayerPrefs.GetString("user_name");
            memorysounds_score.memorysounds_last_score=_score;
            memorysounds_score.memorysounds_play_time=_time;
            data=JsonUtility.ToJson(memorysounds_score);
        }
        else if(m_game=="rhythm"){
            rhythm_score= new Rhythm_Score();
            rhythm_score.user_name=PlayerPrefs.GetString("user_name");
            rhythm_score.rhythm_last_score=_score;
            rhythm_score.rhythm_play_time=_time;
            data=JsonUtility.ToJson(rhythm_score);
        }
        //API CALL THAT returns the id of the user that will be updated its score
        using(UnityWebRequest www= UnityWebRequest.Put(url + "/api/game_user/id",data)){
        //using
        www.method="POST";
        www.SetRequestHeader("Content-Type", "Application/json");
        yield return www.SendWebRequest();
        //insert the id in the object
        if (www.result == UnityWebRequest.Result.Success) {
            Debug.Log("ID founded");
            if(m_game=="trivia"){
            trivia_score.user_id= int.Parse(www.downloadHandler.text);
            data=JsonUtility.ToJson(trivia_score);
            }
            else if(m_game=="memory"){
            memory_score.user_id= int.Parse(www.downloadHandler.text);
            data=JsonUtility.ToJson(memory_score);
            }
            else if(m_game=="memorysounds"){
            memorysounds_score.user_id= int.Parse(www.downloadHandler.text);
            data=JsonUtility.ToJson(memorysounds_score);
            }
            else if(m_game=="rhythm"){
            rhythm_score.user_id= int.Parse(www.downloadHandler.text);
            data=JsonUtility.ToJson(rhythm_score);
            }
        } else {
            Debug.Log("Error: " + www.error);
        }
        }
        //Make the API call to update the user
        using(UnityWebRequest www= UnityWebRequest.Put(url + getEP,data)){
        //using
        www.method="PUT";
        www.SetRequestHeader("Content-Type", "Application/json");
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success) {
            Debug.Log("Score Updated");
            Debug.Log(www.downloadHandler.text);
        } else {
            Debug.Log("Error: " + www.error);
        }
        }

    }
    
}
