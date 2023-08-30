using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backpack : MonoBehaviour
{
    private PlayerInfoManager playerInfoManager;

    public List<Item> items = new List<Item>();

    private InGameInv inGamebp;

    public int cap = 20;

    private void Start()
    {
        playerInfoManager = PlayerInfoManager.Instance;
        inGamebp = GameObject.FindGameObjectWithTag("inGameInv").GetComponent<InGameInv>();
        playerInfoManager.MoveToInGameBackPack(items);
        inGamebp.UpdateINV();
    }
    public void AddItem(Item item)
    {
        if (items.Count != 20)
        {
            items.Add(item);
            inGamebp.UpdateINV();
        }
    }

    public bool CheckForItem(Item item)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i] == item)
            {
                items.RemoveAt(i);
                Debug.Log(i);
                return true;
            }
        }
        return false;
    }
}
