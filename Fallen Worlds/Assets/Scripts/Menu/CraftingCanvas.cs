using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingCanvas : MonoBehaviour
{
    private PlayerInfoManager playerInfoManager;

    public GameObject craftable;
    public GameObject inv;
    public GameObject smeltable;

    public List<GameObject> inventoryGos = new List<GameObject>();

    public GameObject slot1;
    public GameObject slot2;
    public GameObject slot3;
    public GameObject craftedSlot;

    public GameObject smeltable1;
    public GameObject smeltable2;
    public GameObject smeltable3;
    public GameObject smeltableCrafted;

    public Item commonUpgradePart;
    public Item uncommonUpgradePart;
    public Item rareUpgradePart;
    public Item epicUpgradePart;
    public Item legendaryUpgradePart;
    public Item aGift;

    void Start()
    {
        playerInfoManager = PlayerInfoManager.Instance;
        foreach (Item item in playerInfoManager.inverntory)
        {
            if (item.itemType == Item.ItemType.Craftable)
            {
                GameObject currentItem;
                currentItem = Instantiate(craftable, craftable.transform.position, craftable.transform.rotation, inv.transform);
                inventoryGos.Add(currentItem);
                currentItem.GetComponent<SmeltBar>().GetItemDetails(item);
            }            
        }
    }
    public void UpdateCraftINV()
    {
        foreach (GameObject game in inventoryGos)
        {
            Destroy(game);
        }


        foreach (Item item1 in playerInfoManager.inverntory)
        {
            GameObject currentItem;
            currentItem = Instantiate(craftable, craftable.transform.position, craftable.transform.rotation, inv.transform);
            inventoryGos.Add(currentItem);
            currentItem.GetComponent<SmeltBar>().GetItemDetails(item1);
        }

    }

    public void SpawnSmelter(int tick, Item item)
    {
        if (tick == 1)
        {
            slot1 = Instantiate(smeltable, smeltable.transform.position, smeltable.transform.rotation, smeltable1.transform);
            slot1.GetComponent<SmeltBar>().GetItemDetails(item);
            slot1.GetComponent<SmeltBar>().slotNumber = 1;
        }
        if (tick == 2)
        {
            slot2 = Instantiate(smeltable, smeltable.transform.position, smeltable.transform.rotation, smeltable2.transform);
            slot2.GetComponent<SmeltBar>().GetItemDetails(item);
            slot2.GetComponent<SmeltBar>().slotNumber = 2;
        }
        if (tick == 3)
        {
            slot3 = Instantiate(smeltable, smeltable.transform.position, smeltable.transform.rotation, smeltable3.transform);
            slot3.GetComponent<SmeltBar>().GetItemDetails(item);
            slot3.GetComponent<SmeltBar>().slotNumber = 3;
        }
    }

    public void Smelt()
    {
        if (slot1.GetComponent<SmeltBar>().currentItem.rarity == Item.ItemRarity.Basic && slot2.GetComponent<SmeltBar>().currentItem.rarity == Item.ItemRarity.Basic && slot3.GetComponent<SmeltBar>().currentItem.rarity == Item.ItemRarity.Basic)
        {
            Destroy(slot1); Destroy(slot2); Destroy(slot3);
            craftedSlot = Instantiate(smeltable, smeltable.transform.position, smeltable.transform.rotation, smeltableCrafted.transform);
            craftedSlot.GetComponent<SmeltBar>().GetItemDetails(commonUpgradePart);
            craftedSlot.GetComponent<SmeltBar>().slotNumber = 4;
        }
        if (slot1.GetComponent<SmeltBar>().currentItem.rarity == Item.ItemRarity.Common && slot2.GetComponent<SmeltBar>().currentItem.rarity == Item.ItemRarity.Common && slot3.GetComponent<SmeltBar>().currentItem.rarity == Item.ItemRarity.Common)
        {
            Destroy(slot1); Destroy(slot2); Destroy(slot3);
            craftedSlot = Instantiate(smeltable, smeltable.transform.position, smeltable.transform.rotation, smeltableCrafted.transform);
            craftedSlot.GetComponent<SmeltBar>().GetItemDetails(uncommonUpgradePart);
            craftedSlot.GetComponent<SmeltBar>().slotNumber = 4;
        }
        if (slot1.GetComponent<SmeltBar>().currentItem.rarity == Item.ItemRarity.Uncommon && slot2.GetComponent<SmeltBar>().currentItem.rarity == Item.ItemRarity.Uncommon && slot3.GetComponent<SmeltBar>().currentItem.rarity == Item.ItemRarity.Uncommon)
        {
            Destroy(slot1); Destroy(slot2); Destroy(slot3);
            craftedSlot = Instantiate(smeltable, smeltable.transform.position, smeltable.transform.rotation, smeltableCrafted.transform);
            craftedSlot.GetComponent<SmeltBar>().GetItemDetails(rareUpgradePart);
            craftedSlot.GetComponent<SmeltBar>().slotNumber = 4;
        }
        if (slot1.GetComponent<SmeltBar>().currentItem.rarity == Item.ItemRarity.Rare && slot2.GetComponent<SmeltBar>().currentItem.rarity == Item.ItemRarity.Rare && slot3.GetComponent<SmeltBar>().currentItem.rarity == Item.ItemRarity.Rare)
        {
            Destroy(slot1); Destroy(slot2); Destroy(slot3);
            craftedSlot = Instantiate(smeltable, smeltable.transform.position, smeltable.transform.rotation, smeltableCrafted.transform);
            craftedSlot.GetComponent<SmeltBar>().GetItemDetails(epicUpgradePart);
            craftedSlot.GetComponent<SmeltBar>().slotNumber = 4;
        }
        if (slot1.GetComponent<SmeltBar>().currentItem.rarity == Item.ItemRarity.Epic && slot2.GetComponent<SmeltBar>().currentItem.rarity == Item.ItemRarity.Epic && slot3.GetComponent<SmeltBar>().currentItem.rarity == Item.ItemRarity.Epic)
        {
            Destroy(slot1); Destroy(slot2); Destroy(slot3);
            craftedSlot = Instantiate(smeltable, smeltable.transform.position, smeltable.transform.rotation, smeltableCrafted.transform);
            craftedSlot.GetComponent<SmeltBar>().GetItemDetails(legendaryUpgradePart);
            craftedSlot.GetComponent<SmeltBar>().slotNumber = 4;
        }
        if (slot1.GetComponent<SmeltBar>().currentItem.rarity == Item.ItemRarity.Legendary && slot2.GetComponent<SmeltBar>().currentItem.rarity == Item.ItemRarity.Legendary && slot3.GetComponent<SmeltBar>().currentItem.rarity == Item.ItemRarity.Legendary)
        {
            Destroy(slot1); Destroy(slot2); Destroy(slot3);
            craftedSlot = Instantiate(smeltable, smeltable.transform.position, smeltable.transform.rotation, smeltableCrafted.transform);
            craftedSlot.GetComponent<SmeltBar>().GetItemDetails(legendaryUpgradePart);
            craftedSlot.GetComponent<SmeltBar>().slotNumber = 4;
        }
        else
        {
            // Tell Player to try agian
        }
    }
}
