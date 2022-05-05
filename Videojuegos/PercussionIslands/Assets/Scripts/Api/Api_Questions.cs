/*
This scripts allows the connection of Unity with the API in order to obtain data of the tabe questions
Salvador Salgado Normnandia
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

// Allow the class to be extracted from Unity
// https://stackoverflow.com/questions/40633388/show-members-of-a-class-in-unity3d-inspector


// Class QuestionsList will store the questions that the Script recieves from the api
[System.Serializable]
public class QuestionsList
{
    public List<QuestionAnswers> questions;
    public void ShuffleQuestions(){
        for(int i=0;i<questions.Count;i++){
            QuestionAnswers temp = questions[i];
            int randomIndex= Random.Range(i, questions.Count);
            questions[i]=questions[randomIndex];   
            questions[randomIndex]= temp;   
        }
    }
}

//In order to update the score of the minigame we need to send the new score as well as the user_id of the user we want to update. This is why we need to create a class  UserScore that stores those values (atributes)
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
    //API CALL THAT RETRIEVES THE QUESTION IN JSON TO THEN TURN IT TO QUESTIONS CLASS AND STORE THEM IN OUR QUESTIONLIST
    IEnumerator GetQuestions()
    {
        using(UnityWebRequest www= UnityWebRequest.Get(url + getEP)){;
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
    }
}
