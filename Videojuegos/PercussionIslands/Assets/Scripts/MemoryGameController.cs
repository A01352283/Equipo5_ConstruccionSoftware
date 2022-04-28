//This script works as the main memory mini game controller, detecting whenever the pair of cards the user select are mathc or not, as well as keeping the score of the user. 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemoryGameController : MonoBehaviour
{
    [SerializeField]

    //This Sprite works as the back of the cards
    private Sprite bgImage;
    //AudioSource that reproduces a correct or incorrect clip depending on the pair of card selected
    private AudioSource audio_s;
    //Correct guess Ausdio
    public AudioClip corr;
    //Incorrect guess Audio
    public AudioClip incorr;
    //This sprite works as the image of the cards that dont have the instrument image but its sound
    public Sprite image_d;
    //This Sprite array contains the images of the instruments in the game
    public Sprite[] puzzles;
    //This AudioClip array contains the sounds of the instruments
    public AudioClip[] sounds;
    //String that contains the name of the instruments depending on the index
    private string[] instrumnent_name={"Agogo Bells","Banana Shaker", "Bass Drum", "Bell Tree", "Cabasa", "Castanets", "Chinese Cymbal", "Chinese Hand Cymbals","Clash Cymbals"};
    //List of Cards used in the game
    public List<Card> cards = new List<Card>();
    //List of the gamePuzzle imgages
    public List<Sprite> gamePuzzles = new List<Sprite>();
    //List of insturment sounds used in the game
    public List<AudioClip> gameSounds= new List<AudioClip>();
    //List of Buttons that will have each card
    public List<Button> btns = new List<Button>();
    //Booleans that will be used when selecting the card pairs
    public bool firstGuess, secondGuess; 
    //Value that will keep count of the number of guesses (both correct and incorrect)
    private int countGuesses;
    //Mult is the score multiplyer that will grow if the user keeps guessing correct continuously
    int mult= 10;
    //This value will keep store the score of the player during the game, being affected by mult
    public int score= 0;
    //Value that will keep count of the number of correct guesses
    private int countCorrectGuesses;
    private int gameGuesses;
    private int firstGuessIndex, secondGuessIndex;
    private int firstGuessPuzzle, secondGuessPuzzle;
    public Text count_guess;
    public Text inst_name;

    public MemoryGameOverScreen MemoryGameOverScreen;

    public GameObject corr_screen;
    public GameObject incorr_screen;
    public void GameOver(){
        MemoryGameOverScreen.Setup(score);
    }

    //Load Sprites and Sound for the memory cards
    void Awake(){
        puzzles= Resources.LoadAll<Sprite>("Instrument_Sprites");
        sounds=Resources.LoadAll<AudioClip>("Sounds/Game1");
    }

    //Begin script
    void Start(){
        GetButtons();
        AddListeners();
        AddGamePuzzles();
        Shuffle(cards);
        gameGuesses= cards.Count/2;
        audio_s=GetComponent<AudioSource>();
        inst_name.text="Select Card";
    }
    //Activate buttons for memory cards
    void GetButtons(){
        GameObject[] objects = GameObject.FindGameObjectsWithTag("PuzzleButton");

        for(int i=0; i< objects.Length;i++){
            btns.Add(objects[i].GetComponent<Button>());
            btns[i].image.sprite =bgImage;
        }
    }
    // Generate Cards with the sprites and sounds
    void AddGamePuzzles(){
        int looper = btns.Count;
        for(int i=0; i<looper/2; i++){
            
            cards.Add(new Card(i,puzzles[i]));
            cards.Add(new Card(i,sounds[i]));
        }
    }
    //Allows to listen sound of a clicked Memory Card
    void AddListeners(){
        foreach (Button btn in btns){
            btn.onClick.AddListener(() => PickAPuzzle());
        }
    }
    //Select specific memory card, once clicked it checks the type of Card class and displays the content
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
            corr_screen.SetActive(true);
            audio_s.Play();
            yield return new WaitForSeconds(.8f);
            corr_screen.SetActive(false);
            btns[firstGuessIndex].interactable = false;
            btns[secondGuessIndex].interactable = false;
            //Erase btn (Card) from the game
            btns[firstGuessIndex].image.color = new Color(0,0,0,0);
            btns[secondGuessIndex].image.color = new Color(0,0,0,0);

            //SUM Score
            score+=mult;
            mult = mult+(mult*1);
            if(mult>100){
                mult=100;
            }
            count_guess.text=(score).ToString();
            inst_name.text="Select Card";
            CheckIfTheGameIsFinished();
        }else{
            //RESET MULTIPLYER
            mult=10;
            yield return new WaitForSeconds(.6f);
            incorr_screen.SetActive(true);
            audio_s.clip=incorr;
            audio_s.Play();
            yield return new WaitForSeconds(.8f);
            incorr_screen.SetActive(false);
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
    //Shuffle order of memory cards depepnding on the list
    void Shuffle(List<Card> list){
        for (int i = 0; i < list.Count; i++){
            Card temp = list[i];
            int randomIndex= Random.Range(i, list.Count);
            list[i]=list[randomIndex];   
            list[randomIndex]= temp;     
        }
    }
}