using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemoryGameController : MonoBehaviour
{
    [SerializeField]
    private Sprite bgImage;
    private AudioSource audio_s;
    public AudioClip corr;
    public AudioClip incorr;

    [SerializeField] Image correct;
    [SerializeField] Image incorrect;
    public Sprite image_d;
    public Sprite[] puzzles;
    public AudioClip[] sounds;

    private string[] instrumnent_name={"Agogo Bells","Banana Shaker", "Bass Drum", "Bell Tree", "Cabasa", "Castanets", "Chinese Cymbal", "Chinese Hand Cymbals","Clash Cymbals","Agogo Bells","Banana Shaker", "Bass Drum", "Bell Tree", "Cabasa", "Castanets", "Chinese Cymbal", "Chinese Hand Cymbals","Clash Cymbals"};

    public List<Card> cards = new List<Card>();
    public List<Sprite> gamePuzzles = new List<Sprite>();
    public List<AudioClip> gameSounds= new List<AudioClip>();
    public List<Button> btns = new List<Button>();

    public bool firstGuess, secondGuess; 

    private int countGuesses;
    int mult= 10;
    int score= 0;
    private int countCorrectGuesses;
    private int gameGuesses;
    private int firstGuessIndex, secondGuessIndex;
    private int firstGuessPuzzle, secondGuessPuzzle;
    public Text count_guess;
    public Text inst_name;

    public MemoryGameOverScreen MemoryGameOverScreen;
    public void GameOver(){
        MemoryGameOverScreen.Setup(score);
    }


    void Awake(){
        puzzles= Resources.LoadAll<Sprite>("Instrument_Sprites");
        sounds=Resources.LoadAll<AudioClip>("Sounds/Game1");
    }
    void Start(){
        GetButtons();
        AddListeners();
        AddGamePuzzles();
        Shuffle(cards);
        gameGuesses= cards.Count/2;
        audio_s=GetComponent<AudioSource>();
        inst_name.text="Select Card";
    }
    void GetButtons(){
        GameObject[] objects = GameObject.FindGameObjectsWithTag("PuzzleButton");

        for(int i=0; i< objects.Length;i++){
            btns.Add(objects[i].GetComponent<Button>());
            btns[i].image.sprite =bgImage;
        }
    }

    void AddGamePuzzles(){
        int looper = btns.Count;
        for(int i=0; i<looper/2; i++){
            
            cards.Add(new Card(i,puzzles[i]));
            cards.Add(new Card(i,sounds[i]));
        }
    }

    void AddListeners(){
        foreach (Button btn in btns){
            btn.onClick.AddListener(() => PickAPuzzle());
        }
    }

    public void PickAPuzzle(){
        if(!firstGuess){
            firstGuess = true;
            firstGuessIndex= int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
            firstGuessPuzzle= cards[firstGuessIndex].id;
            if (cards[firstGuessIndex].isImage){   
                btns[firstGuessIndex].image.sprite= cards[firstGuessIndex].img;
                inst_name.text=instrumnent_name[firstGuessPuzzle];
            }
            else{
                btns[firstGuessIndex].image.sprite= image_d;
                inst_name.text="Sound Card";
                audio_s.clip= cards[firstGuessIndex].snd;
                audio_s.Play();
            }
            //ojo
             btns[firstGuessIndex].enabled = false;
        } else if(!secondGuess){
            secondGuess = true;
            secondGuessIndex= int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
            secondGuessPuzzle= cards[secondGuessIndex].id;
            btns[secondGuessIndex].image.sprite= cards[secondGuessIndex].img;
            if (cards[secondGuessIndex].isImage){   
                btns[secondGuessIndex].image.sprite= cards[secondGuessIndex].img;
                inst_name.text=instrumnent_name[secondGuessPuzzle];
            }
            else{
                btns[secondGuessIndex].image.sprite= image_d;
                audio_s.clip= cards[secondGuessIndex].snd;
                inst_name.text="Sound Card";
                audio_s.Play();
            //ojo
             btns[secondGuessIndex].enabled = false;
            }
            countGuesses++;
            StartCoroutine(CheckIfThePuzzleMatch());
        }
    }

    IEnumerator CheckIfThePuzzleMatch(){
        yield return new WaitForSeconds(1.3f);
        if(firstGuessPuzzle==secondGuessPuzzle){
            audio_s.clip=corr;
            audio_s.Play();
            yield return new WaitForSeconds(.8f);
            btns[firstGuessIndex].interactable = false;
            btns[secondGuessIndex].interactable = false;
            btns[firstGuessIndex].image.color = new Color(0,0,0,0);
            btns[secondGuessIndex].image.color = new Color(0,0,0,0);

            //SUM Score
            score+=mult;
            mult = mult+(mult*1);
            count_guess.text=(score).ToString();
            inst_name.text="Select Card";
            CheckIfTheGameIsFinished();
        }else{
            mult=10;
            yield return new WaitForSeconds(.6f);
            audio_s.clip=incorr;
            audio_s.Play();
            btns[firstGuessIndex].enabled = true;
            btns[secondGuessIndex].enabled = true;
            btns[firstGuessIndex].image.sprite = bgImage;
            btns[secondGuessIndex].image.sprite = bgImage;
            inst_name.text="Select Card";
        }
        //Reset guesses
         yield return new WaitForSeconds(.4f);
         firstGuess = secondGuess = false;
    }

    void CheckIfTheGameIsFinished(){
        countCorrectGuesses++;
        if(countCorrectGuesses == gameGuesses){
            GameOver();
            Debug.Log("Game Finished");
            Debug.Log("It took you" + countGuesses + " many guesses to finish the game");
        }
    }

    void Shuffle(List<Card> list){
        for (int i = 0; i < list.Count; i++){
            Card temp = list[i];
            int randomIndex= Random.Range(i, list.Count);
            list[i]=list[randomIndex];   
            list[randomIndex]= temp;     
        }
    }
}