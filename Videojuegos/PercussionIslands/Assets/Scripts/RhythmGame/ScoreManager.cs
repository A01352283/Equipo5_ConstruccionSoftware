using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    //Score manager scripts, sums to score and combo, also resets combo when missed.
    public static ScoreManager Instance;
    public AudioSource hitSFX;
    public AudioSource missSFX;
    public TMPro.TextMeshPro scoreText;
    public TMPro.TextMeshPro totalScoreText;
    public static int comboScore;
    public static int TotalScore;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;   
    }

    public static void Hit(){
        comboScore += 10;
        TotalScore += 10;
        Instance.hitSFX.Play();
    }

    public static void Miss(){
        comboScore = 0;
        Instance.missSFX.Play();
    }
    
    private void Update()
    {
        scoreText.text = "Combo: " + comboScore.ToString();
        totalScoreText.text = "Score: " + TotalScore.ToString();
    }
}
