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

    private void Start()
    {
        inv = GameObject.FindGameObjectWithTag("InvCanvas").GetComponent<InvCanvas>();
        playerInfoManager = PlayerInfoManager.Instance;
    }

    public void GetItemDetails(Item item)
    {
        currentItem = item;
        itemName.text = item.name;
        hydration = item.hydration;
        hunger = item.hunger;
        energy = item.energy;
        if (hydration != 0 || hunger != 0 || energy != 0)
        {
            consumeIMG.SetActive(true);
        }
    }

    public void Consume(int tick)
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

    public void MoveToBag()
    {
        if (playerInfoManager.backpack.Count < 20)
        {
            if (playerInfoManager.inverntory.Contains(currentItem))
            {
                playerInfoManager.inverntory.Remove(currentItem);
                playerInfoManager.backpack.Add(currentItem);
                inv.UpdateINV();
            }
        }
    }

    public void MoveToInv()
    {
        if (playerInfoManager.backpack.Contains(currentItem))
        {
            playerInfoManager.inverntory.Add(currentItem);
            playerInfoManager.backpack.Remove(currentItem);
        }
        inv.UpdateINV();
    }

    public void DestroyObject(int tick)
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

}
