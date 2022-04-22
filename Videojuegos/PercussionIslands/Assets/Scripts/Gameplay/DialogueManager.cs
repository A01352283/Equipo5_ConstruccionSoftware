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


    public bool IsShowing{ get; private set;} //Property to allow or prevent NPC from moving during dialogue

    //This is called when near the NPC and the interact button is pressed
    public IEnumerator ShowDialogue(Dialogue dialogue){
        yield return new WaitForEndOfFrame(); //Waits in order to not have the interact button pressed during the same frame and advance when not needed

        OnShowDialogue?.Invoke();
        IsShowing = true; //Prevents the NPC from moving
        dialogueBox.SetActive(true);

        foreach (var line in dialogue.Lines){
            yield return(TypeDialogue(line));
            yield return new WaitUntil( () => Input.GetKeyDown(KeyCode.Z) | Input.GetKeyDown(KeyCode.I));
        }

        dialogueBox.SetActive(false);
        IsShowing = false;
        OnCloseDialogue?.Invoke();
    }

    //Shows the dialogue letter by letter
    public IEnumerator TypeDialogue(string line){

        dialogueText.text = "";
        foreach (var letter in line.ToCharArray()){
            dialogueText.text += letter;
            yield return new WaitForSeconds(1f / lettersPerSecond);
        }

    }

    public void HandleUpdate(){
        
    }
}
