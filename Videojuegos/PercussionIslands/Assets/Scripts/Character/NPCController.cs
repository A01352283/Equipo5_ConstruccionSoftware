 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour, Interactable, ISavable
{

    [SerializeField] Dialogue dialogue; //Stores all the lines of dialogue for the NPC

    [Header("Quests")]
    [SerializeField] QuestBase questToStart; //The quest that the NPC will give (optional)
    [SerializeField] QuestBase questToComplete; //Used to deactivate story items

    [Header("Movement")]
    [SerializeField] List<Vector2> movementPattern; //Stores the pattern in which the NPC will move
    [SerializeField] float timeBetweenPattern; //Delay of pattern repetitions

    Character character;
    ItemGiver itemGiver;
    MinigameStarter minigameStarter;
    
    NPCState state;
    float IdleTimer = 0f; //Time where NPC will stay idle between pattern movements
    int currentMovementPattern = 0; //Current step of the movement pattern
    Quest activeQuest; //Reference to the active quest of the NPC (if it has one)

    private void Awake() {
        character = GetComponent<Character>();
        itemGiver = GetComponent<ItemGiver>();
        minigameStarter = GetComponent<MinigameStarter>();
    }

    public IEnumerator Interact(Transform initiator){ //Initiator is the transform of the player that started the interaction
        //To have and instance of the dialogue manager and be able to call all the functions inside it
        if (state == NPCState.Idle){
            state = NPCState.Dialogue;
            character.LookToward(initiator.position);

            if (questToComplete != null){
                var quest = new Quest(questToComplete);

                yield return quest.CompleteQuest();
                questToComplete = null;

                Debug.Log($"{quest.Base.Name} completed");
            }

            //Checks the item giving and the quest starting
            if (itemGiver != null && itemGiver.CanBeGiven()){
                yield return itemGiver.GiveItem(initiator.GetComponent<PlayerController>());
            }
            else if (questToStart != null){
                activeQuest = new Quest(questToStart);
                yield return activeQuest.StartQuest();
                
                questToStart = null; //Since we don't want to restart the quest

                if (activeQuest.CanBeCompleted()){ //Complete the quest
                    yield return activeQuest.CompleteQuest();
                    activeQuest = null;
                }
            }
            else if (activeQuest != null){ //If there is an active quest
                if (activeQuest.CanBeCompleted()){ //Complete the quest
                    yield return activeQuest.CompleteQuest();
                    activeQuest = null;
                }
                else{   //If the quest can't be completed yet
                    yield return DialogueManager.Instance.ShowDialogue(activeQuest.Base.InProgressDialogue);
                }
            }
            else if (minigameStarter != null){ //If there is a minigame to load, load it
                yield return minigameStarter.LoadMinigame();
            }
            else{ //Show the normal dialogue
                yield return DialogueManager.Instance.ShowDialogue(dialogue);
            }
            

            IdleTimer = 0f;
            state = NPCState.Idle; //Lambda to change the state to idle, this prevents other NPC's to stop moving when talking to one of them
        }
    } 

    private void Update() {
        //Makes the NPC move in the given pattern with the given idle time between movements
        if(state == NPCState.Idle){
            IdleTimer += Time.deltaTime;
            if (IdleTimer > timeBetweenPattern){
                IdleTimer = 0f;
                if (movementPattern.Count > 0){
                    StartCoroutine(Walk());
                }
            }
        }

        character.HandleUpdate();
    }


    IEnumerator Walk(){
        state = NPCState.Walking;

        var oldPos = transform.position;
        
        yield return character.Move(movementPattern[currentMovementPattern]);

        //To know if the character walked in the previous pattern
        if (transform.position != oldPos){
            currentMovementPattern = (currentMovementPattern + 1) % movementPattern.Count; //So it goes back to the first on the last step
        } 

        state = NPCState.Idle;
    }

    public object CaptureState()
    {
        var saveData = new NPCQuestSaveData();
        saveData.activeQuest = activeQuest?.GetSaveData(); //Converts it to save data

        if (questToStart != null)
            saveData.questToStart = (new Quest(questToStart)).GetSaveData(); //Turns questbase to questsavedata
        
        if (questToComplete != null)
            saveData.questToComplete = (new Quest(questToComplete)).GetSaveData(); //Turns questbase to questsavedata
        
        return saveData;
    }

    public void RestoreState(object state)
    {
        var saveData = state as NPCQuestSaveData;
        if (saveData != null){
            activeQuest = (saveData.activeQuest != null)? new Quest(saveData.activeQuest) : null; //Restores the active quest
            
            questToStart = (saveData.questToStart != null)? new Quest(saveData.questToStart).Base : null; //Restores the active quest
            questToComplete = (saveData.questToComplete != null)? new Quest(saveData.questToComplete).Base : null; //Restores the active quest
        }
    }
}

[System.Serializable]
public class NPCQuestSaveData{
    public QuestSaveData activeQuest;
    public QuestSaveData questToStart;
    public QuestSaveData questToComplete;
}


public enum NPCState{ Idle, Walking, Dialogue }