using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmeltBar : MonoBehaviour
{
    private PlayerInfoManager playerInfoManager;

    public TMPro.TMP_Text itemName;

    public Item currentItem;
    private CraftingCanvas craft;

    public int slotNumber = 0;

    private AudioSource click;

    private void Start()
    {
        craft = GameObject.FindGameObjectWithTag("CraftingCanvas").GetComponent<CraftingCanvas>();
        click = GameObject.FindGameObjectWithTag("MenuAC").GetComponent<AudioSource>();
        playerInfoManager = PlayerInfoManager.Instance;
    }

    public void GetItemDetails(Item item) // Item info
    {
        currentItem = item;
        itemName.text = item.name + " (Rarity: " + item.rarity + ")";
    }

    public void MoveToInv() //when the game ends
    {
        click.Play();
        if (playerInfoManager.backpack.Contains(currentItem))
        {
            playerInfoManager.inverntory.Add(currentItem);
            playerInfoManager.backpack.Remove(currentItem);
        }
        craft.UpdateCraftINV();
    }

    public void DestroyObject(int tick) // Player removed the item from inv
    {
        click.Play();
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
        click.Play();
        if (craft.slot1 == null)
        {
            if (playerInfoManager.inverntory.Contains(currentItem))
            {
                craft.SpawnSmelter(1 , currentItem);
                playerInfoManager.inverntory.Remove(currentItem);
                craft.UpdateCraftINV();
            }
            return;
        }
        if (craft.slot2 == null)
        {
            if (playerInfoManager.inverntory.Contains(currentItem))
            {
                craft.SpawnSmelter(2, currentItem);
                playerInfoManager.inverntory.Remove(currentItem);
                craft.UpdateCraftINV();
            }
            return;
        }
        if (craft.slot3 == null)
        {
            if (playerInfoManager.inverntory.Contains(currentItem))
            {
                craft.SpawnSmelter(3, currentItem);
                playerInfoManager.inverntory.Remove(currentItem);
                craft.UpdateCraftINV();
            }
            return;
        }
    }

    public void MoveBackToInv()
    {
        click.Play();
        if (slotNumber == 1)
        {
            playerInfoManager.inverntory.Add(currentItem);
            craft.UpdateCraftINV();
            Destroy(craft.slot1);
        }
        if (slotNumber == 2)
        {
            playerInfoManager.inverntory.Add(currentItem);
            craft.UpdateCraftINV();
            Destroy(craft.slot2);
        }
        if (slotNumber == 3)
        {
            playerInfoManager.inverntory.Add(currentItem);
            craft.UpdateCraftINV();
            Destroy(craft.slot3);
        }
        if (slotNumber == 4)
        {
            playerInfoManager.inverntory.Add(currentItem);
            craft.UpdateCraftINV();
            Destroy(craft.craftedSlot);
        }
    }

}
