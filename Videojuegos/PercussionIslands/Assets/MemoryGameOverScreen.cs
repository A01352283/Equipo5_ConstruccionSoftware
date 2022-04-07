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
    public void RestartButton(){
        SceneManager.LoadScene("Memory");
    }

    public void ExitButton(){

    }
}
