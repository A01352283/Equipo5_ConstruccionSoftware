using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestObject : MonoBehaviour
{
    [SerializeField] QuestBase questToCheck;
    [SerializeField] ObjectActions onStart;
    [SerializeField] ObjectActions onComplete; 

    QuestList questList;

    private void Start() {
        questList = QuestList.GetQuestList();
        questList.OnUpdated += UpdateObjectStatus; //Subscribes to the event

        UpdateObjectStatus();
    }

    private void OnDestroy() {
        questList.OnUpdated -= UpdateObjectStatus; //Unsubscribes to the event
    }

    public void UpdateObjectStatus (){
        if (onStart != ObjectActions.DoNothing && questList.IsStarted(questToCheck.Name)){ //We have an onStart action
            foreach (Transform child in transform){
                if (onStart == ObjectActions.Enable){ //Activates the quest items
                    child.gameObject.SetActive(true);
                }
                else if (onStart == ObjectActions.Disable){ //Deactivates the quest items
                    child.gameObject.SetActive(false);
                }
            }
        }

        if (onComplete != ObjectActions.DoNothing && questList.IsCompleted(questToCheck.Name)){ //We have an onComplete action
            foreach (Transform child in transform){
                if (onComplete == ObjectActions.Enable){ //Activates the quest items
                    child.gameObject.SetActive(true);

                    var savable = child.GetComponent<SavableEntity>();
                    
                    if (savable != null)
                        SavingSystem.i.RestoreEntity(savable);
                }
                else if (onComplete == ObjectActions.Disable){ //Deactivates the quest items
                    child.gameObject.SetActive(false);
                }
            }
        }
    }

}

public enum ObjectActions { DoNothing, Enable, Disable}