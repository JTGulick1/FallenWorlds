using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmeltBar : MonoBehaviour
{
    private PlayerInfoManager playerInfoManager;

    public TMPro.TMP_Text itemName;

    public Item currentItem;
    private CraftingCanvas craft;

    private void Start()
    {
        craft = GameObject.FindGameObjectWithTag("CraftingCanvas").GetComponent<CraftingCanvas>();
        playerInfoManager = PlayerInfoManager.Instance;
    }

    public void GetItemDetails(Item item) // Item info
    {
        currentItem = item;
        itemName.text = item.name + " (Rarity: " + item.rarity + ")";
    }

    public void MoveToInv() //when the game ends
    {
        if (playerInfoManager.backpack.Contains(currentItem))
        {
            playerInfoManager.inverntory.Add(currentItem);
            playerInfoManager.backpack.Remove(currentItem);
        }
        craft.UpdateCraftINV();
    }

    public void DestroyObject(int tick) // Player removed the item from inv
    {
        if (playerInfoManager.inverntory.Contains(currentItem))
        {
            playerInfoManager.inverntory.Remove(currentItem);
            craft.UpdateCraftINV();
            return;
        }
        if (playerInfoManager.backpack.Contains(currentItem))
        {
            playerInfoManager.backpack.Remove(currentItem);
            craft.UpdateCraftINV();
            return;
        }
    }

    public void MoveToSlot()
    {
        if (craft.slot1 == null)
        {
            if (playerInfoManager.inverntory.Contains(currentItem))
            {
                craft.SpawnSmelter(1 , currentItem);
                craft.slot1 = currentItem;
                playerInfoManager.inverntory.Remove(currentItem);
            }
            return;
        }
        if (craft.slot2 == null)
        {
            if (playerInfoManager.inverntory.Contains(currentItem))
            {
                craft.SpawnSmelter(2, currentItem);
                craft.slot1 = currentItem;
                playerInfoManager.inverntory.Remove(currentItem);
            }
            return;
        }
        if (craft.slot3 == null)
        {
            if (playerInfoManager.inverntory.Contains(currentItem))
            {
                craft.SpawnSmelter(3, currentItem);
                craft.slot1 = currentItem;
                playerInfoManager.inverntory.Remove(currentItem);
            }
            return;
        }
    }

}
