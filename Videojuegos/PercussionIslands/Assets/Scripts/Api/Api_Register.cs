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


public class Api_Register : MonoBehaviour
{
    [SerializeField] string url;
    [SerializeField] string getEP;
    [SerializeField] Text user_text;
    [SerializeField] Text pwd_text;

    [SerializeField] Text status;

    // This is where the information from the api will be extracted
    public UserInfo user;

    // Update is called once per frame
    public void Register_User()
    {
    //when cliked button login loop hasta que haga match
        if(user_text.text=="" || pwd_text.text==""){
            status.text="You need to fill both inputs.....";
        }
        else{
            StartCoroutine(New_User());
        }
    }

    public void BackLogin(){
        SceneManager.LoadScene(0);
    }

    public class Message{
        public string message;
    }

    Message msg;

    IEnumerator New_User()
    {   
        user= new UserInfo();
        user.user_name=user_text.text;
        user.pwd=pwd_text.text;
        string data=JsonUtility.ToJson(user);
        using(UnityWebRequest www= UnityWebRequest.Put(url + getEP,data))
        //UnityWebRequest www= UnityWebRequest.Post(url + getEP,data);
        //using
        {
            www.method="POST";
            www.SetRequestHeader("Content-Type", "Application/json");
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success) {
                msg= new Message();
                msg= JsonUtility.FromJson<Message>(www.downloadHandler.text);
                if (msg.message=="User Created Succesfully!"){
                    status.text=msg.message + " Returning to Login Screen";
                    yield return new WaitForSeconds(1.5f);
                    BackLogin();
                }
                else{
                    status.text=msg.message;
                }
            // Compose the response to look like the object we want to extract
            // https://answers.unity.com/questions/1503047/json-must-represent-an-object-type.html
            //string jsonString = "{\"questions\":" + www.downloadHandler.text + "}";
            //allQuestions = JsonUtility.FromJson<QuestionsList>(jsonString);
            } 
            else {
                status.text="Error: " + www.error;
            }
        }
    }
    
}
