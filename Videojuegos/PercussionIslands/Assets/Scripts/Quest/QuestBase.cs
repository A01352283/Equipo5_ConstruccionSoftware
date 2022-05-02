using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Quests/Create a new quest")]
public class QuestBase : ScriptableObject
{
    [SerializeField] string name;
    [SerializeField] string description;

    [SerializeField] Dialogue startDialogue;
    [SerializeField] Dialogue inProgressDialogue;
    [SerializeField] Dialogue completeDialogue;

    [SerializeField] ItemBase requiredItem; //If you need to give an item to the NPC
    [SerializeField] ItemBase rewardItem;

    //Properties
    public string Name => name;
    public string Description => description;
    
    public Dialogue StartDialogue => startDialogue;
    public Dialogue InProgressDialogue => inProgressDialogue?.Lines.Count > 0 ? inProgressDialogue : startDialogue; //This makes the inProgressDialogue optional. It gives the start dialogue if none is given.
    public Dialogue CompleteDialogue => completeDialogue;

    public ItemBase RequiredItem => requiredItem;
    public ItemBase RewardItem => rewardItem;
}
