using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvCanvas : MonoBehaviour
{
    private PlayerInfoManager playerInfoManager;

    public GameObject itemBar;
    public GameObject itemBarBp;

    public GameObject inv;
    public GameObject bp;

    public List<GameObject> inventoryGos = new List<GameObject>();
    public List<GameObject> backpackGos = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        playerInfoManager = PlayerInfoManager.Instance;
        foreach (Item item in playerInfoManager.inverntory)
        {
            GameObject currentItem;
            currentItem = Instantiate(itemBar, itemBar.transform.position, itemBar.transform.rotation, inv.transform);
            inventoryGos.Add(currentItem);
            currentItem.GetComponent<Itembar>().GetItemDetails(item);
        }
    }

    public void UpdateINV()
    {
        foreach (GameObject game in inventoryGos)
        {
            Destroy(game);
        }
        foreach (GameObject game in backpackGos)
        {
            Destroy(game);
        }

        foreach (Item item1 in playerInfoManager.inverntory)
        {
            GameObject currentItem;
            currentItem = Instantiate(itemBar, itemBar.transform.position, itemBar.transform.rotation, inv.transform);
            inventoryGos.Add(currentItem);
            currentItem.GetComponent<Itembar>().GetItemDetails(item1);
        }
        foreach (Item item1 in playerInfoManager.backpack)
        {
            GameObject currentItem;
            currentItem = Instantiate(itemBarBp, itemBarBp.transform.position, itemBarBp.transform.rotation, bp.transform);
            backpackGos.Add(currentItem);
            currentItem.GetComponent<Itembar>().GetItemDetails(item1);
        }
    }
}
