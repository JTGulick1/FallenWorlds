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

    public Item slot1;
    public Item slot2;
    public Item slot3;

    public GameObject smeltable1;
    public GameObject smeltable2;
    public GameObject smeltable3;

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
            GameObject currentItem;
            currentItem = Instantiate(smeltable, smeltable.transform.position, smeltable.transform.rotation, smeltable1.transform);
            currentItem.GetComponent<SmeltBar>().GetItemDetails(item);
        }
        if (tick == 2)
        {
            GameObject currentItem;
            currentItem = Instantiate(smeltable, smeltable.transform.position, smeltable.transform.rotation, smeltable2.transform);
            currentItem.GetComponent<SmeltBar>().GetItemDetails(item);
        }
        if (tick == 3)
        {
            GameObject currentItem;
            currentItem = Instantiate(smeltable, smeltable.transform.position, smeltable.transform.rotation, smeltable3.transform);
            currentItem.GetComponent<SmeltBar>().GetItemDetails(item);
        }
    }
}
