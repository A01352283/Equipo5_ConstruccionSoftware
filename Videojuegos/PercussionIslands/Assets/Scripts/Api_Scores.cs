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

public class Api_Scores : MonoBehaviour
{
    [SerializeField] string url;
    [SerializeField] string getEP;

    string _id;

    // This is where the information from the api will be extracted
    public Trivia_Score trivia_score;

    // Update is called once per frame
    public void UpdateScore(int _score)
    {
    //when cliked button login loop hasta que haga match
       StartCoroutine(UpScore(_score));
    }

    public void RegsiterPage(){
        SceneManager.LoadScene(5);
    }

    IEnumerator UpScore(int _score)
    {   
        trivia_score= new Trivia_Score();
        trivia_score.user_name=PlayerPrefs.GetString("user_name");
        trivia_score.trivia_last_score=_score;
        string data=JsonUtility.ToJson(trivia_score);
        Debug.Log(data);
        using(UnityWebRequest www= UnityWebRequest.Put(url + "/api/game_user/id",data)){
        //using
        www.method="POST";
        www.SetRequestHeader("Content-Type", "Application/json");
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success) {
            Debug.Log("ID founded");
            trivia_score.user_id= int.Parse(www.downloadHandler.text);
            data=JsonUtility.ToJson(trivia_score);
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
