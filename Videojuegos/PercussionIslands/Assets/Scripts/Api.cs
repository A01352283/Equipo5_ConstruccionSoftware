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
[System.Serializable]
public class User
{
    public int user_id;
    public string user_name;
    public string pwd;
    public string date_joined;
}

// Allow the class to be extracted from Unity
[System.Serializable]
public class UserList
{
    public List<User> users;
}

// Allow the class to be extracted from Unity
[System.Serializable]
public class QuestionsList
{
    public List<QuestionAnswers> questions;
}

public class Api : MonoBehaviour
{
    [SerializeField] string url;
    [SerializeField] string getEP;

    // This is where the information from the api will be extracted
    public UserList allUsers;
    public QuestionsList allQuestions;

    // Update is called once per frame
    void Start()
    {
       StartCoroutine(GetQuestions());
    }

    IEnumerator GetUsers()
    {
        UnityWebRequest www = UnityWebRequest.Get(url + getEP);
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success) {
            //Debug.Log("Response: " + www.downloadHandler.text);
            // Compose the response to look like the object we want to extract
            // https://answers.unity.com/questions/1503047/json-must-represent-an-object-type.html
            string jsonString = "{\"users\":" + www.downloadHandler.text + "}";
            allUsers = JsonUtility.FromJson<UserList>(jsonString);
        } else {
            Debug.Log("Error: " + www.error);
        }
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

    IEnumerator AddUser()
    {
        /*
        // This should work with an API that does not expect JSON
        WWWForm form = new WWWForm();
        form.AddField("name", "newGuy" + Random.Range(1000, 9000).ToString());
        form.AddField("surname", "Tester" + Random.Range(1000, 9000).ToString());
        Debug.Log(form);
        */

        // Create the object to be sent as json
        User testUser = new User();
        testUser.user_name = "newGuy" + Random.Range(1000, 9000).ToString();
        //testUser.surname = "Tester" + Random.Range(1000, 9000).ToString();

        //Debug.Log("USER: " + testUser);
        string jsonData = JsonUtility.ToJson(testUser);
        //Debug.Log("BODY: " + jsonData);
        // Send using the Put method:
        // https://stackoverflow.com/questions/68156230/unitywebrequest-post-not-sending-body
        UnityWebRequest www = UnityWebRequest.Put(url + getEP, jsonData);
        //UnityWebRequest www = UnityWebRequest.Post(url + getUsersEP, form);
        // Set the method later, and indicate the encoding is JSON
        www.method = "POST";
        www.SetRequestHeader("Content-Type", "application/json");
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success) {
            Debug.Log("Response: " + www.downloadHandler.text);
        } else {
            Debug.Log("Error: " + www.error);
        }
    }
}
