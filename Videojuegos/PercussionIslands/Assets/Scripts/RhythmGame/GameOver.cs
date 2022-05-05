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
    
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        Invoke("FinishGame", 70f);
    }

    void FinishGame()
    {
        gameObject.SetActive(true);
        RestartGame.gameObject.SetActive(true);
    }

    public void ExitButton(){
        StartCoroutine(UnloadThisScene());
    }

    IEnumerator UnloadThisScene(){
        yield return SceneManager.UnloadSceneAsync("RhythmGameScene");
    }

    public void PlayAgainButton()
    {
        //SceneManager.LoadScene("RhythmGameScene");
        Start();
        comboScore = 0;
        TotalScore = 0;
        //SongManager.GetComponent<SongManager>();
        //startGame = GameObject.FindGameObjectsWithTag("Start").GetComponent<SongManager>(startGame);
    }

}