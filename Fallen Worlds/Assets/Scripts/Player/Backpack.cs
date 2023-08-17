using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backpack : MonoBehaviour
{
    private PlayerInfoManager playerInfoManager;

    public List<Item> items = new List<Item>();

    public int cap = 20;

    private void Start()
    {
        playerInfoManager = PlayerInfoManager.Instance;
        playerInfoManager.MoveToInGameBackPack(items);
    }
    public void AddItem(Item item)
    {
        if (items.Count != 20)
        {
            items.Add(item);
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
