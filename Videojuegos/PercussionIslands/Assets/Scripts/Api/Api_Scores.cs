/*
Test for the connection to an API
Able to use the Get method to read data and "Post" to send data
NOTE: Using Put instead of Post. See the links around line 86
Gilberto Echeverria
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
// Allow the class to be extracted from Unity
// https://stackoverflow.com/questions/40633388/show-members-of-a-class-in-unity3d-inspector


// Allow the class to be extracted from Unity

[System.Serializable]
public class Trivia_Score
{
    public string user_name;
    public int user_id;
    public int trivia_last_score;
}

[System.Serializable]
public class Memory_Score
{
    public string user_name;
    public int user_id;
    public int memory_last_score;
}

[System.Serializable]
public class MemorySounds_Score
{
    public string user_name;
    public int user_id;
    public int memorysounds_last_score;
}

[System.Serializable]
public class Rhythm_Score
{
    public string user_name;
    public int user_id;
    public int rhythm_last_score;
}


public class Api_Scores : MonoBehaviour
{
    [SerializeField] string url;
    [SerializeField] string getEP;

    [SerializeField] string mg_type;

    string _id;
    string data;

    // This is where the information from the api will be extracted
    public Trivia_Score trivia_score;
    public Memory_Score memory_score;
    public MemorySounds_Score memorysounds_score;
    public Rhythm_Score rhythm_score;
    // Update is called once per frame
    public void UpdateScore(int _score)
    {
    //when cliked button login loop hasta que haga match
       StartCoroutine(UpScore(mg_type, _score));
    }

    public void RegsiterPage(){
        SceneManager.LoadScene(5);
    }

    IEnumerator UpScore(string m_game,int _score)
    {   
        if(m_game=="trivia"){
            trivia_score= new Trivia_Score();
            trivia_score.user_name=PlayerPrefs.GetString("user_name");
            trivia_score.trivia_last_score=_score;
            data=JsonUtility.ToJson(trivia_score);
        }
        else if(m_game=="memory"){
            memory_score= new Memory_Score();
            memory_score.user_name=PlayerPrefs.GetString("user_name");
            memory_score.memory_last_score=_score;
            data=JsonUtility.ToJson(memory_score);
        }
        else if(m_game=="memorysounds"){
            memorysounds_score= new MemorySounds_Score();
            memorysounds_score.user_name=PlayerPrefs.GetString("user_name");
            memorysounds_score.memorysounds_last_score=_score;
            data=JsonUtility.ToJson(memorysounds_score);
        }
        else if(m_game=="rhythm"){
            rhythm_score= new Rhythm_Score();
            rhythm_score.user_name=PlayerPrefs.GetString("user_name");
            rhythm_score.rhythm_last_score=_score;
            data=JsonUtility.ToJson(rhythm_score);
        }
        using(UnityWebRequest www= UnityWebRequest.Put(url + "/api/game_user/id",data)){
        //using
        www.method="POST";
        www.SetRequestHeader("Content-Type", "Application/json");
        yield return www.SendWebRequest();

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
