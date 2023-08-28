using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenuAttribute(fileName = "New Item", menuName = "Item Creation/Items")]
public class Item : ScriptableObject
{
    public enum ItemType
    {
        Consumable,
        Craftable,
        Key,
    }
    public ItemType itemType;

    public enum ItemRarity
    {
        Common,
        Rare,
        Epic,
        Legendary
    }
    public ItemRarity rarity;

    public int hydration;
    public int hunger;
    public int energy;
}