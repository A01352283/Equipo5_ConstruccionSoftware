using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] GameObject dialogueBox;
    [SerializeField] Text dialogueText;
    [SerializeField] int lettersPerSecond;

    public event Action OnShowDialogue;
    public event Action OnCloseDialogue;

    public static DialogueManager Instance{get; private set;} //Since this is static, it will be able to be referenced from any class

    private void Awake() {
        Instance = this;
    }

    Dialogue dialogue;
    Action onDialogueFinished; //To help NPC movement stop when talking to one of them

    int currentLine = 0; 
    bool isTyping;


    public bool IsShowing{ get; private set;} //Property to allow or prevent NPC from moving during dialogue

    //This is called when near the NPC and the interact button is pressed
    public IEnumerator ShowDialogue(Dialogue dialogue, Action onFinished = null){
        yield return new WaitForEndOfFrame(); //Waits in order to not have the interact button pressed during the same frame and advance when not needed

        OnShowDialogue?.Invoke();

        IsShowing = true; //Prevents the NPC from moving
        this.dialogue = dialogue;
        onDialogueFinished = onFinished; //This prevents the other NPC to stop moving when talking to one of them

        dialogueBox.SetActive(true);
        StartCoroutine(TypeDialogue(dialogue.Lines[0])); //Shows the first line
    }

    //Shows the dialogue letter by letter
    public IEnumerator TypeDialogue(string line){
        isTyping = true;

        dialogueText.text = "";
        foreach (var letter in line.ToCharArray()){
            dialogueText.text += letter;
            yield return new WaitForSeconds(1f / lettersPerSecond);
        }

        isTyping = false;
    }

    public void HandleUpdate(){
        if ((Input.GetKeyDown(KeyCode.Z) | Input.GetKeyDown(KeyCode.I)) && !isTyping){ //Goes to the next line of each dialogue if there is one
            ++currentLine;
            if (currentLine < dialogue.Lines.Count){
                StartCoroutine(TypeDialogue(dialogue.Lines[currentLine]));
            }
            else{
                //Closes the dialogue when there are no lines left
                currentLine = 0;
                IsShowing = false; //Allows the NPC to start moving again
                dialogueBox.SetActive(false); 
                onDialogueFinished.Invoke();
                OnCloseDialogue?.Invoke();
            }
        }
    }
}
