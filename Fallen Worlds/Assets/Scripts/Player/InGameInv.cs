using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameInv : MonoBehaviour
{
    private Backpack bp;

    public GameObject itemBar;
    public GameObject inv;
    public List<GameObject> backpackGos = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        bp = GameObject.FindGameObjectWithTag("Player").GetComponent<Backpack>();
    }

    // Update is called once per frame
    public void UpdateINV()
    {
        foreach (GameObject game in backpackGos)
        {
            Destroy(game);
        }

        foreach (Item item1 in bp.items)
        {
            GameObject currentItem;
            currentItem = Instantiate(itemBar, itemBar.transform.position, itemBar.transform.rotation, bp.transform);
            backpackGos.Add(currentItem);
            currentItem.GetComponent<Itembar>().GetItemDetails(item1);
        }
    }
}
