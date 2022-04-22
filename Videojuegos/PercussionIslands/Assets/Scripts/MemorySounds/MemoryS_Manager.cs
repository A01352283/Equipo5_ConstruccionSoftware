using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemoryS_Manager : MonoBehaviour
{
    public Image PreviewImage; //VorschauImage -- instrument display (top of the board or "insrument view") 
    public GameObject DontTouch; // gameobject that defines when an instrument square should be touched or not.
    // dont touch image (block instruments or "unTouch") -- Nichtdrüken imagen
    public List<Color> InstrumentColor; //Farben
    public int AllColors; //varios colores -AnzahlFaber -- 
    public int ColorMix;// espectaculo de colores - FarbenZeigen 
    public int Nochfehlend; //no falta? 
    public Text NochfelendText; // sigue esperando
    public List<int> Reihenfolge;
    public Text ScoreText; //LevelText
    public GameObject Game_over;  //EndScene 
    public int HigthScore;
    public Text HigthScore_text;
    
    void Start()
    {
       Reihenfolge = new List<int>();
       StartCoroutine(Starten()); 
    }

    public void Generator()
    {
        AllColors++;
        ScoreText.text = "Score:  " + AllColors;
        Reihenfolge.Add(Random.Range(0, 4)); 

        ShowValues();
    }

    public void ShowValues() //mostrar valores - Vorschau Zeigen 
    {
        if(Reihenfolge.Count <= ColorMix)
        {
            PreviewImage.color = Color.white; 
            ColorMix = 0; 
            Nochfehlend= Reihenfolge.Count;
            NochfelendText.text = NochfelendText.ToString();
            DontTouch.SetActive(false);
        }
        else
        {
            PreviewImage.color = InstrumentColor[Reihenfolge[ColorMix]];
            StartCoroutine(NachsteZeigen()); //nachste Zeigen 
        }
    }

//FarbenButton -- Instrument button (farben - color) -- to reference 
    public void FarbenButton(int ID)
    {
        if(ID == Reihenfolge[ColorMix])
        {
            ColorMix++;
            Nochfehlend--;
            NochfelendText.text = Nochfehlend.ToString();

            if(ColorMix == Reihenfolge.Count)
            {
                DontTouch.SetActive(true);
                NochfelendText.text = "";
                Nochfehlend = 0;
                ColorMix = 0;
                StartCoroutine(Starten());
            }
        }
        else 
        {
            Game_over.SetActive(true);
            DontTouch.SetActive(true);
            HigthScore = PlayerPrefs.GetInt("Higthscore");

            if(AllColors > HigthScore)
            {
                HigthScore = AllColors;
                PlayerPrefs.SetInt("HigthScore", HigthScore);
            }

            HigthScore_text.text = "HigthScore" + HigthScore; 
            NochfelendText.text = " "; 
            Nochfehlend = 0;
            ColorMix = 0;
        }
    }

    public void Nochmal()
    {
        Reihenfolge = new List<int>();
        AllColors = 0;
        ScoreText.text ="Score: " + AllColors;
        Game_over.SetActive(false);
        StartCoroutine(Starten());
    }

    IEnumerator Starten()
    {
        yield return new WaitForSeconds(0.5f);
        Generator();
    }

    IEnumerator NachsteZeigen()
    {
        yield return new WaitForSeconds(0.3f);
        PreviewImage.color = Color.white;
        yield return new WaitForSeconds(0.7f);
        ColorMix++;
        ShowValues();
    }
}
