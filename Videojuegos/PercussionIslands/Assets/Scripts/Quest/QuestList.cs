using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class QuestList : MonoBehaviour, ISavable
{
    List<Quest> quests = new List<Quest>();

    public event Action OnUpdated; //We should invoke this when something changes in the list

    public void AddQuest(Quest quest){
        if (!quests.Contains(quest)){
            quests.Add(quest);
        }

        OnUpdated?.Invoke();

    }

    //Checks if the quest is started
    public bool IsStarted(string questName){
        var questStatus = quests.FirstOrDefault(q => q.Base.Name == questName)?.Status; //Gives us the quest with the given name and gets its status
        return questStatus == QuestStatus.Started || questStatus == QuestStatus.Completed;
    }
    
    //Checks if the quest is completed
    public bool IsCompleted(string questName){
        var questStatus = quests.FirstOrDefault(q => q.Base.Name == questName)?.Status; //Gives us the quest with the given name and gets its status
        return questStatus == QuestStatus.Completed;
    }

    public static QuestList GetQuestList(){
        return FindObjectOfType<PlayerController>().GetComponent<QuestList>();
    }

    public object CaptureState()
    {
        //Converts to questsavedata
        return quests.Select(q => q.GetSaveData()).ToList();
    }

    public void RestoreState(object state)
    {
        var saveData = state as List<QuestSaveData>;
        if (saveData != null){
            quests = saveData.Select(q => new Quest(q)).ToList(); //Convert the list questsavedata to a list of quests
            OnUpdated?.Invoke(); //Updates the quest states
        }
    }
}
