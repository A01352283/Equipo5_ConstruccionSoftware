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
