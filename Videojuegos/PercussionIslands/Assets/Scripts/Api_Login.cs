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

    // This is where the information from the api will be extracted
    public UserInfo user;

    // Update is called once per frame
    public void CheckUser()
    {
    //when cliked button login loop hasta que haga match
       StartCoroutine(Verify_User());
    }

    IEnumerator Verify_User()
    {   
        user= new UserInfo();
        user.user_name=user_text.text;
        user.pwd=pwd_text.text;
        string data=JsonUtility.ToJson(user);
        UnityWebRequest www= UnityWebRequest.Put(url + getEP,data);
        //using
        www.method="POST";
        www.SetRequestHeader("Content-Type", "Application/json");
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success) {
            if(www.downloadHandler.text=="1"){
                //Couroutine????
                status.text="Correct Credentials!";
                PlayerPrefs.SetString("user_name",user.user_name);
                yield return new WaitForSeconds(.8f);
                SceneManager.LoadScene(4);
            }
            else{
                status.text="Incorrect Credentials...Either the username or password are wrong";
            }
            // Compose the response to look like the object we want to extract
            // https://answers.unity.com/questions/1503047/json-must-represent-an-object-type.html
            //string jsonString = "{\"questions\":" + www.downloadHandler.text + "}";
            //allQuestions = JsonUtility.FromJson<QuestionsList>(jsonString);

        } else {
            Debug.Log("Error: " + www.error);
        }
    }
    
}
