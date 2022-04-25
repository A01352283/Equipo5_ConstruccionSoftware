using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGiver : MonoBehaviour
{
    [SerializeField] ItemBase item;
    [SerializeField] Dialogue dialogue;

    public IEnumerator GiveItem(PlayerController player){
        player.GetComponent<NonKeyInventory>().AddItem(item);
    }
}
