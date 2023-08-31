using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameInv : MonoBehaviour
{
    private Backpack bp;
    private PlayerInfoManager playerInfoManager;

    public GameObject itemBar;
    public GameObject inv;
    public List<GameObject> backpackGos = new List<GameObject>();

    public TMPro.TMP_Text cap;
    public TMPro.TMP_Text hyd;
    public TMPro.TMP_Text food;
    public TMPro.TMP_Text sleep;
    public TMPro.TMP_Text shards;

    // Start is called before the first frame update
    void Start()
    {
        playerInfoManager = PlayerInfoManager.Instance;
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
            currentItem = Instantiate(itemBar, itemBar.transform.position, itemBar.transform.rotation, inv.transform);
            backpackGos.Add(currentItem);
            currentItem.GetComponent<ItemBarIG>().GetItemDetails(item1);
        }

        cap.text = "Backpack Storage " + bp.items.Count + " / " + bp.cap ;
    }

    private void Update()
    {
        hyd.text = "Hydration: " + playerInfoManager.hydration;
        food.text = "Hunger: " + playerInfoManager.hunger;
        sleep.text = "Fatigue: " + playerInfoManager.sleep;
        shards.text = "Shards: " + playerInfoManager.shards;

    }
}
