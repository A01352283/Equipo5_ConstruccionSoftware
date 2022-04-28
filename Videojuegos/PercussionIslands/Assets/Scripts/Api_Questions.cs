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

// Allow the class to be extracted from Unity
// https://stackoverflow.com/questions/40633388/show-members-of-a-class-in-unity3d-inspector


// Allow the class to be extracted from Unity
[System.Serializable]
public class QuestionsList
{
    public List<QuestionAnswers> questions;
}

[System.Serializable]
public class UserScore
{
    public int usedID;
    public int score;
}

public class Api_Questions : MonoBehaviour
{
    [SerializeField] string url;
    [SerializeField] string getEP;
    [SerializeField] GameObject controller;

    // This is where the information from the api will be extracted
    public QuestionsList allQuestions;

    // Update is called once per frame
    void Start()
    {
       StartCoroutine(GetQuestions());
    }

    IEnumerator GetQuestions()
    {
        UnityWebRequest www= UnityWebRequest.Get(url + getEP);
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success) {
            //Debug.Log("Response: " + www.downloadHandler.text);
            // Compose the response to look like the object we want to extract
            // https://answers.unity.com/questions/1503047/json-must-represent-an-object-type.html
            string jsonString = "{\"questions\":" + www.downloadHandler.text + "}";
            allQuestions = JsonUtility.FromJson<QuestionsList>(jsonString);

        } else {
            Debug.Log("Error: " + www.error);
        }
    }
    /*
    IEnumerator SetScore() {
        MemoryGameController mgc = controller.GetComponent<MemoryGameController>();
        UserScore userScore = new UserScore();
        userScore.score = mgc.score;
        userScore.usedID = PlayerPrefs.GetInt("userID");

        PlayerPrefs.SetInt("userID", 6);

    }
    */
}
