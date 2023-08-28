using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Itembar : MonoBehaviour
{
    private PlayerInfoManager playerInfoManager;

    public TMPro.TMP_Text itemName;

    public GameObject consumeIMG;

    public int hydration;
    public int hunger;
    public int energy;

    public Item currentItem;
    private InvCanvas inv;
    private CraftingCanvas craft;

    private void Start()
    {
        inv = GameObject.FindGameObjectWithTag("InvCanvas").GetComponent<InvCanvas>();
        craft = GameObject.FindGameObjectWithTag("CraftingCanvas").GetComponent<CraftingCanvas>();
        playerInfoManager = PlayerInfoManager.Instance;
    }

    public void GetItemDetails(Item item) // Item info
    {
        currentItem = item;
        itemName.text = item.name + " (Rarity: " + item.rarity + ")";
        hydration = item.hydration;
        hunger = item.hunger;
        energy = item.energy;
        if (hydration != 0 || hunger != 0 || energy != 0)
        {
            consumeIMG.SetActive(true);
        }
    }

    public void Consume(int tick) // Use Item
    {
        playerInfoManager.hydration += hydration;
        playerInfoManager.hunger += hunger;
        playerInfoManager.sleep += energy;
        if (playerInfoManager.hydration >= 100)
            playerInfoManager.hydration = 100;
        if (playerInfoManager.hunger >= 100)
            playerInfoManager.hunger = 100;
        if (playerInfoManager.sleep >= 100)
            playerInfoManager.sleep = 100;
        if (playerInfoManager.inverntory.Contains(currentItem) && tick == 0)
        {
            playerInfoManager.inverntory.Remove(currentItem);
            inv.UpdateINV();
            return;
        }
        if (playerInfoManager.backpack.Contains(currentItem) && tick == 1)
        {
            playerInfoManager.backpack.Remove(currentItem);
            inv.UpdateINV();
            return;
        }
    }

    public void MoveToBag() // when the game starts
    {
        if (playerInfoManager.backpack.Count < 20 + (playerInfoManager.backpackLevel - 1))
        {
            if (playerInfoManager.inverntory.Contains(currentItem))
            {
                playerInfoManager.inverntory.Remove(currentItem);
                playerInfoManager.backpack.Add(currentItem);
                inv.UpdateINV();
            }
        }
    }

    public void MoveToInv() //when the game ends
    {
        if (playerInfoManager.backpack.Contains(currentItem))
        {
            playerInfoManager.inverntory.Add(currentItem);
            playerInfoManager.backpack.Remove(currentItem);
        }
        inv.UpdateINV();
    }

    public void DestroyObject(int tick) // Player removed the item from inv
    {
        if (playerInfoManager.inverntory.Contains(currentItem))
        {
            playerInfoManager.inverntory.Remove(currentItem);
            inv.UpdateINV();
            return;
        }
        if (playerInfoManager.backpack.Contains(currentItem))
        {
            playerInfoManager.backpack.Remove(currentItem);
            inv.UpdateINV();
            return;
        }
    }

    public void MoveToSlot()
    {
        if (craft.slot1 != null)
        {
            if (playerInfoManager.backpack.Contains(currentItem))
            {
                craft.SpawnSmelter(1 , currentItem);
                craft.slot1 = currentItem;
                playerInfoManager.inverntory.Remove(currentItem);
            }
        }
        if (craft.slot2 != null)
        {
            if (playerInfoManager.backpack.Contains(currentItem))
            {
                craft.SpawnSmelter(2, currentItem);
                craft.slot1 = currentItem;
                playerInfoManager.inverntory.Remove(currentItem);
            }
        }
        if (craft.slot3 != null)
        {
            if (playerInfoManager.backpack.Contains(currentItem))
            {
                craft.SpawnSmelter(3, currentItem);
                craft.slot1 = currentItem;
                playerInfoManager.inverntory.Remove(currentItem);
            }
        }
    }

}
