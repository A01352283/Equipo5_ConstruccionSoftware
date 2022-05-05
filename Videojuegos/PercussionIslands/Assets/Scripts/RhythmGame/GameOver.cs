using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using static SongManager;
using static ScoreManager;
public class GameOver : MonoBehaviour
{
    public GameObject RestartGame; 
    public GameObject GameExit;
     private float start_time;
    //Script that finishes the game.

    // Start is called before the first frame update
    void Start()
    {
        start_time= Time.time;
        gameObject.SetActive(false);
        Invoke("FinishGame", 70f);
        Debug.Log(PlayerPrefs.GetString("user_name"));
    }
    //Finishes the game and gets score.
    void FinishGame()
    {
        gameObject.SetActive(true);
        RestartGame.gameObject.SetActive(true);
        
        // Data api 
        TotalScore = PlayerPrefs.GetInt("Total Score");
        string mg_time= Game_Time();
        GetComponent<Api_Scores>().UpdateScore(TotalScore, mg_time);
        Debug.Log("Score Upated");
        //GameOver.Setup(TotalScore);
    }
    //Buttons to restart and exit the game.
    public void ExitButton(){
        StartCoroutine(UnloadThisScene());
    }

    IEnumerator UnloadThisScene(){
        yield return SceneManager.UnloadSceneAsync("RhythmGameScene");
    }

    public void PlayAgainButton()
    {
        SceneManager.LoadScene("RhythmGameScene");
        Start();
        comboScore = 0;
        TotalScore = 0;
        //SongManager.GetComponent<SongManager>();
        //startGame = GameObject.FindGameObjectsWithTag("Start").GetComponent<SongManager>(startGame);
    }
    //Gets the game time
    private string Game_Time(){
        float t= Time.time - start_time;
        string hours = ((int)t / 3600).ToString ("00");
        float m = t % 3600;
        string minutes = ((int)m / 60).ToString("00");
        string seconds = (m % 60).ToString("00");
        string mg_time=hours + ":" + minutes + ":" + seconds;
        return mg_time;
    }


    
}