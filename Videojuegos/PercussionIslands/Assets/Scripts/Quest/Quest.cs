using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable] //So we can see this in our quest list
public class Quest
{   
    //Properties
    public QuestBase Base { get; private set; }
    public QuestStatus Status { get; private set; }

    //Constructor
    public Quest(QuestBase _base){
        Base = _base;
    }

    //Starts the quest
    public IEnumerator StartQuest(){
        Status = QuestStatus.Started;

        yield return DialogueManager.Instance.ShowDialogue(Base.StartDialogue);

        //Adds the quest to the quest tracking
        var questList = QuestList.GetQuestList();
        questList.AddQuest(this);
    }

    //Ends the quest
    public IEnumerator CompleteQuest(){
        Status = QuestStatus.Completed;

        yield return DialogueManager.Instance.ShowDialogue(Base.CompleteDialogue);

        var inventory = NonKeyInventory.GetNonKeyInventory();
        //Removes the required item from the player's inventory
        if (Base.RequiredItem != null){
            inventory.RemoveItem(Base.RequiredItem);
        }

        //Give reward item(s) to the player
        if (Base.RewardItem != null){
            inventory.AddItem(Base.RewardItem);

            yield return DialogueManager.Instance.ShowDialogueText($"You pick up the {Base.RewardItem.Name}");
        }

        //Adds the quest to the quest tracking
        var questList = QuestList.GetQuestList();
        questList.AddQuest(this);

    }

    //Checks if the quest can be finished by checking if the player has the required item
    public bool CanBeCompleted (){
        
        var inventory = NonKeyInventory.GetNonKeyInventory();
        
        //If the quest has a required item
        if (Base.RequiredItem != null){
            if (!inventory.HasItem(Base.RequiredItem)){ //If the player doesn't have the required item
                return false;
            }
        }

        return true;
    }

}

public enum QuestStatus { None, Started, Completed }
