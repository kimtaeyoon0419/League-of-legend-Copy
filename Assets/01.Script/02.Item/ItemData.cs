using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game Data/Item Data", fileName = "NewItemData")]
public class ItemData : ScriptableObject
{
    public Sprite itemImage;
    public string itemName;
    public string itemExplanation;
    public int cost;
}
