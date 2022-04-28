using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGiver : MonoBehaviour
{
    [SerializeField] ItemBase item;
    [SerializeField] Dialogue dialogue;

    bool used = false;

    public IEnumerator GiveItem(PlayerController player){

        yield return DialogueManager.Instance.ShowDialogue(dialogue);

        player.GetComponent<NonKeyInventory>().AddItem(item);

        used = true;

        yield return DialogueManager.Instance.ShowDialogueText($"You received {item.name}!");
    }

    public bool CanBeGiven(){
        return item != null && !used; //If there's an item to be given and it is not yet used
    }
}
