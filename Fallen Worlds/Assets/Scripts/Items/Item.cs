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
        Basic,
        Common,
        Uncommon,
        Rare,
        Epic,
        Legendary
    }
    public ItemRarity rarity;

    public int hydration;
    public int hunger;
    public int energy;
    public int shards;
}