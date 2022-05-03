using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest
{   
    //Properties
    public QuestBase Base { get; private set; }
    public QuestStatus Status { get; private set; }

    //Constructor
    public Quest(QuestBase _base){
        Base = _base;
    }

    //Constructor to restore the quest from the questSaveData
    public Quest(QuestSaveData saveData){
        Base = QuestDB.GetObjectByName(saveData.name);
        Status = saveData.status;
    }

    //Converts the quest class into a savedata class
    public QuestSaveData GetSaveData(){
        var saveData = new QuestSaveData(){
            name = Base.name, 
            status = Status
        };

        return saveData;
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

[System.Serializable]
public class QuestSaveData
{
    public string name;
    public QuestStatus status;
}

public enum QuestStatus { None, Started, Completed }
