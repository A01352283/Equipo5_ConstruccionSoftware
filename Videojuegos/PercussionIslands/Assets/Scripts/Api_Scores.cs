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
public class Memory_Score
{
    public string user_name;
    public int memory_last_score;
}

public class Api_Scores : MonoBehaviour
{
    [SerializeField] string url;
    [SerializeField] string getEP;

    // This is where the information from the api will be extracted
    public Memory_Score memory_score;

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
        memory_score= new Memory_Score();
        memory_score.user_name=PlayerPrefs.GetString("user_name");
        memory_score.memory_last_score=_score;
        string data=JsonUtility.ToJson(memory_score);
        UnityWebRequest www= UnityWebRequest.Put(url + getEP,data);
        //using
        www.method="PUT";
        www.SetRequestHeader("Content-Type", "Application/json");
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success) {
            Debug.Log(www.downloadHandler);
            yield return new WaitForSeconds(.8f);
            SceneManager.LoadScene(4);
            // Compose the response to look like the object we want to extract
            // https://answers.unity.com/questions/1503047/json-must-represent-an-object-type.html
            //string jsonString = "{\"questions\":" + www.downloadHandler.text + "}";
            //allQuestions = JsonUtility.FromJson<QuestionsList>(jsonString);

        } else {
            Debug.Log("Error: " + www.error);
        }
    }
    
}
