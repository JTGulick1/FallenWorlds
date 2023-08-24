using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingCanvas : MonoBehaviour
{
    private PlayerInfoManager playerInfoManager;

    public GameObject craftable;
    public GameObject inv;

    public List<GameObject> inventoryGos = new List<GameObject>();

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
                currentItem.GetComponent<Itembar>().GetItemDetails(item);
            }            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
