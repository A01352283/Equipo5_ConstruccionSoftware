using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlotUI : MonoBehaviour
{
    [SerializeField] Text nameText;
    [SerializeField] Text countText;

    RectTransform rectTransform;

    private void Awake() {
        rectTransform = GetComponent<RectTransform>();
    }

    //Properties
    public Text NameText => nameText;
    public Text CountText => countText;
    public float Height => rectTransform.rect.height; //Used in the invetoryUI script to scroll the item selection

    public void SetData(ItemSlot itemSlot){
        nameText.text = itemSlot.Item.name;
        countText.text = $"X {itemSlot.Count}";
    }
}
