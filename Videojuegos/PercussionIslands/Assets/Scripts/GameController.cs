using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private Sprite bgImage;

    public Sprite[] puzzles;
    public AudioClip[] sounds;

    public List<Sprite> gamePuzzles = new List<Sprite>();
    public List<AudioClip> gameSounds= new List<AudioClip>();
    public List<Button> btns = new List<Button>(); 

    void Awake(){
        puzzles= Resources.LoadAll<Sprite>("Instrument_Sprites");
        sounds=Resources.LoadAll<AudioClip>("Sounds/Game1");
    }
    void Start(){
        GetButtons();
        AddListeners();
        AddGamePuzzles();
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
        int ind = 0;
        for(int i=0; i<looper; i++){
            if(ind==looper/2){
                ind=0;
            }
            gamePuzzles.Add(puzzles[ind]);
            ind++;
        }
    }
    void AddPuzzleTags(){
        int j;
        for(int i=0; i<(gamePuzzles.Count/2);i++){
            j=gamePuzzles.Count/2 + i;

        }
    }


    void AddListeners(){
        foreach (Button btn in btns){
            btn.onClick.AddListener(() => PickAPuzzle());
        }
    }

    public void PickAPuzzle(){
        string name=UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
        Debug.Log("You are clicking a Button named "+ name);
    }
}
