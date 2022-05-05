/*
Scripts that allows the connection of Unity with the API
Salvador Salgado Normanida
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
//Create UserInfo class that will store the input info from the user
[System.Serializable]
public class UserInfo
{
    public string user_name;
    public string pwd;
}

public class Api_Login : MonoBehaviour
{
    [SerializeField] string url;
    [SerializeField] string getEP;
    [SerializeField] Text user_text;
    [SerializeField] Text pwd_text;

    [SerializeField] Text status;

    // This is where the information from the input will be stored to later send to the API
    public UserInfo user;

    //Function that starts the verification of the user info
    public void CheckUser()
    {
    //when cliked button login loop hasta que haga match
       StartCoroutine(Verify_User());
    }
    //RegisterPage Loads the Register Page Scene
    public void RegsiterPage(){
        SceneManager.LoadScene(1);
    }
    //This function sends the object UserInfo with its attributes as json to our API in order to verify that the info match anyone in the database
    IEnumerator Verify_User()
    {   
        //Inserts the attribbutes with the Text Inputs
        user= new UserInfo();
        user.user_name=user_text.text;
        user.pwd=pwd_text.text;
        //Transform to json
        string data=JsonUtility.ToJson(user);
        //Send the API request with the specific direction anda data
        using(UnityWebRequest www= UnityWebRequest.Put(url + getEP,data)){
        //using
        www.method="POST";
        www.SetRequestHeader("Content-Type", "Application/json");
        yield return www.SendWebRequest();
        //In this case the request return a value of 1 meaning that there is a game_user with the exact password and user_name or 0 if it does not exist
        if (www.result == UnityWebRequest.Result.Success) {
            if(www.downloadHandler.text=="1"){
                //Couroutine????
                status.text="Correct Credentials!";
                //In order to keep track of the user_name for further updates in different Scenes we store the value in PlayerPrefs
                PlayerPrefs.SetString("user_name",user.user_name);
                yield return new WaitForSeconds(.8f);
                //Load New Scene
                SceneManager.LoadScene(18);
            }
            else{
                status.text="Incorrect Credentials...Either the username or password are wrong";
            }
            // Compose the response to look like the object we want to extract
            // https://answers.unity.com/questions/1503047/json-must-represent-an-object-type.html
            //string jsonString = "{\"questions\":" + www.downloadHandler.text + "}";
            //allQuestions = JsonUtility.FromJson<QuestionsList>(jsonString);

        } else {
            status.text="Error: " + www.error;
        }
        }
    }
    
}
