using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    public static ScoreManager Instance;
    public AudioSource hitSFX;
    public AudioSource missSFX;
    public TMPro.TextMeshPro scoreText;
    static int comboScore;
    static int TotalScore;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;   
    }

    public static void Hit(){
        comboScore += 1;
        TotalScore += 1;
        Instance.hitSFX.Play();
    }

    public static void Miss(){
        comboScore = 0;
        Instance.missSFX.Play();
    }
    
    private void Update()
    {
        scoreText.text = comboScore.ToString();
    }
}
