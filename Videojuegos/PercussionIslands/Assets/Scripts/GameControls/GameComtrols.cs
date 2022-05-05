using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameComtrols : MonoBehaviour
{
public void BeginQuest()
    {
        SceneManager.LoadScene(2);
    }
}
