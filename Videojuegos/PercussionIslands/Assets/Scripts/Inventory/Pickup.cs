using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour, Interactable, ISavable
{
    [SerializeField] ItemBase item;
    public bool Used { get; set; } = false;


    public IEnumerator Interact(Transform initiator)
    {
        if (!Used){ //To prevent the item from being used multiple times
            initiator.GetComponent<NonKeyInventory>().AddItem(item);

            Used = true;
            
            //Hides the pickup once it's used
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;

            yield return DialogueManager.Instance.ShowDialogueText($"You picked up {item.name}!");

        }
    }
    public object CaptureState()
    {
        return Used;
    }

    public void RestoreState(object state)
    {
        Used = (bool)state;

        if (Used){
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
