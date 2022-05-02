using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//[RequireComponent(typeof(AudioSource))]

public class MemoryS_Manager : MonoBehaviour
{
    private AudioSource musicBackground;
    public Image PreviewImage; // Display in the top of board (instrument color previw) 
    public GameObject DontTouch; // gameobject that defines when an instrument square should be touched or not (touch lock)
    public List<Color> InstrumentColor; //List of colors that individually represent each instrument
    public int AllColors; //Specifies the number of colors that should be displayed in the Preview image (Increase the amount)
    public int ColorMix;//Start mixing colors from the amount designated by "AllColors"
    public int InstrumentCount; //Number of instruments that are still missing to finish the rhythm (Inverted count)
    public Text InstrumentCount_Text; // Shows in the "preview Image" how many clicks the player needs to complete the round
    public List<int> ColorOrdenInPreview; // Color order shown in "Preview image"
    public Text ScoreText;  
    public GameObject Game_over;  //When losing in the game a Game Over screen is shown
    public int HighScore; // Stores the highest score in the game
    public Text HighScore_text; // Show the highest score
    public Text LastScore_text; //The same of ScoreText
   // public AudioSource sound; // change to instrumentsound   sound.Play();    sound = GetComponent<AudioSource>();
    

    //When you start a game, the color list is reset and the color count begins
    void Start()
    {
       ColorOrdenInPreview = new List<int>();
       StartCoroutine(Starten()); 
       Debug.Log(PlayerPrefs.GetString("user_name"));
    }


    // Generate the colors and save the score list
    public void Generator()
    {
        AllColors++; // Round counter  
        ScoreText.text = "Score:  " + AllColors; // Show the score on the screen 
        LastScore_text.text = "Your Score: " + AllColors; // On the game over screen, it shows the score you had while playing
        ColorOrdenInPreview.Add(Random.Range(0, 4)); // Generates the order of the colors randomly, in a range of 4 (4 instruments)

        ShowValues();
    }

    public void ShowValues() 
    {
        if(ColorOrdenInPreview.Count <= ColorMix) //
        {
            PreviewImage.color = Color.white; //when no color is displayed, the screen is blank 
            ColorMix = 0; // start in 0 
            InstrumentCount= ColorOrdenInPreview.Count; //Count stabilization
            InstrumentCount_Text.text = InstrumentCount_Text.ToString();
            DontTouch.SetActive(false); // block touch 
        }
        else
        {
            PreviewImage.color = InstrumentColor[ColorOrdenInPreview[ColorMix]];
            StartCoroutine(ShowNext()); 
        }
    }



    public void FarbenButton(int ID)
    {
        if(ID == ColorOrdenInPreview[ColorMix]) 
        {
            ColorMix++;
            InstrumentCount--;
            InstrumentCount_Text.text = InstrumentCount.ToString();

            if(ColorMix == ColorOrdenInPreview.Count) //As long as the game is not lost, the counters will increase
            {
                
                DontTouch.SetActive(true);
                InstrumentCount_Text.text = " ";
                InstrumentCount = 0;
                ColorMix = 0;
                StartCoroutine(Starten());
            }
        }
        else // Upon losing, the game over screen will be displayed along with the other data and buttons.
        {
            Game_over.SetActive(true);
            DontTouch.SetActive(true); // Screen lock 
            HighScore = PlayerPrefs.GetInt("High Score");  //shows the stored score
            GetComponent<Api_Scores>().UpdateScore(HighScore); 
            Debug.Log("Score Upated"); 

            if(AllColors > HighScore)
            {
                HighScore = AllColors;
                PlayerPrefs.SetInt("High Score", HighScore);
            }

            HighScore_text.text = "High Score: " + HighScore; 
            InstrumentCount_Text.text = " "; 
            InstrumentCount = 0;
            ColorMix = 0;
        }
    }

    public void Nochmal() // Game restart after a game over (play again)
    {
        ColorOrdenInPreview = new List<int>(); // restart color orden in preview 
        AllColors = 0; // start in 0 
        ScoreText.text ="Score: " + AllColors;
        Game_over.SetActive(false);
        StartCoroutine(Starten());
    }

    IEnumerator Starten()
    {
        yield return new WaitForSeconds(0.5f); // Time before starting the game
        musicBackground=GetComponent<AudioSource>();
        Generator(); // Call the generator to start the game 
    }

    IEnumerator ShowNext()
    {
        yield return new WaitForSeconds(0.3f);  //Time between each color displayed
        PreviewImage.color = Color.white;
        yield return new WaitForSeconds(0.7f);
        ColorMix++;
        ShowValues();
    }
}
