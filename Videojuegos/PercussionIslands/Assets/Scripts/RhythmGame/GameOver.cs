using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        Invoke("FinishGame", 70f);
    }

    void FinishGame()
    {
        gameObject.SetActive(true);
    }

    public void ExitButton(){
        StartCoroutine(UnloadThisScene());
    }

    IEnumerator UnloadThisScene(){
        yield return SceneManager.UnloadSceneAsync("RhythmGameScene");
    }
/*
    public static SongManager Instance;
    public void PlayAgainButton()
    {
        Start();
    }
    */
}