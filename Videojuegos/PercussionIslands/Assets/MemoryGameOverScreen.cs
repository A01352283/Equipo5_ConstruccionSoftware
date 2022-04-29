//This script allows to activate the GameOver screen onces the mini games are over, showing the final score and allowing the user to restart the game or exit the game

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MemoryGameOverScreen : MonoBehaviour
{
    public Text pointsText;
    public void Setup(int score){
        gameObject.SetActive(true);
        pointsText.text="SCORE: "+score.ToString();
    }

    public void RestartButton(string scene){
        SceneManager.LoadScene(scene);
    }

    /*
    public void ExitButton(){
        SceneManager.LoadScene("")
    }
    */
}
