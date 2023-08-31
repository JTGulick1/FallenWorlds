using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBarIG : MonoBehaviour
{
    private PlayerInfoManager playerInfoManager;
    private Backpack bp;

    public TMPro.TMP_Text itemName;

    public GameObject consumeIMG;

    public int hydration;
    public int hunger;
    public int energy;

    public Item currentItem;
    private InGameInv inv;
    private void Awake()
    {
        inv = GameObject.FindGameObjectWithTag("inGameInv").GetComponentInChildren<InGameInv>();
        bp = GameObject.FindGameObjectWithTag("Player").GetComponent<Backpack>();
    }

    private void Start()
    {
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

    public void Consume() // Use Item
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
        if (bp.items.Contains(currentItem))
        {
            bp.items.Remove(currentItem);
            inv.UpdateINV();
            return;
        }
    }

    public void DestroyObject() // Player removed the item from inv
    {
        if (bp.items.Contains(currentItem))
        {
            bp.items.Remove(currentItem);
            inv.UpdateINV();
            return;
        }
    }

}
