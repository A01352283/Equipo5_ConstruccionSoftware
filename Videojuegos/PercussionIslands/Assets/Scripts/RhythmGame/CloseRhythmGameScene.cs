/*

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CloseRhythmGameScene : MonoBehaviour
{
    public void ExitButton(){
        StartCoroutine(UnloadThisScene());
    }

    IEnumerator UnloadThisScene(){
        yield return SceneManager.UnloadSceneAsync("RhythmGameScene");
    }
}




 public Text pointsText;

    public void Setup(int score){
        gameObject.SetActive(true);
        pointsText.enabled = true;
        pointsText.text="SCORE: "+ score.ToString();
    }

    public void HideGameOverScreen(){
        gameObject.SetActive(false);
        pointsText.enabled = false;
    }

    public void ExitTriviaButton(){
        StartCoroutine(UnloadThisSceneTrivia());
    }

    IEnumerator UnloadThisSceneTrivia(){
        yield return SceneManager.UnloadSceneAsync("TriviaGame");
    }
    public void ExitMemoryButton(){
        StartCoroutine(UnloadThisSceneTrivia());
    }

    IEnumerator UnloadThisSceneMemory(){
        yield return SceneManager.UnloadSceneAsync("Memory");
    }
   
}
*/