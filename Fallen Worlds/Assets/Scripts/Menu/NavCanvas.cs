using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavCanvas : MonoBehaviour
{
    public GameObject menu;
    public GameObject inventory;
    public GameObject office;
    public GameObject crafting;
    public GameObject store;
    public TMPro.TMP_Text hydration;
    public TMPro.TMP_Text hunger;
    public TMPro.TMP_Text fatigue;
    public TMPro.TMP_Text shards;
    private PlayerInfoManager playerInfoManager;

    private void Start()
    {
        playerInfoManager = PlayerInfoManager.Instance;
    }

    private void Update()
    {
        UpdateStats();
    }

    public void UpdateStats()
    {
        hydration.text = "Hydration: " + playerInfoManager.hydration;
        hunger.text = "Hunger: " + playerInfoManager.hunger;
        fatigue.text = "Fatigue: " + playerInfoManager.sleep;
        shards.text = "Shards: " + playerInfoManager.shards;
    }

    public void MenuOn()
    {
        menu.SetActive(true);
        inventory.SetActive(false);
        office.SetActive(false);
        crafting.SetActive(false);
        store.SetActive(false);
    }
    public void InvOn()
    {
        menu.SetActive(false);
        inventory.SetActive(true);
        office.SetActive(false);
        crafting.SetActive(false);
        store.SetActive(false);
    }
    public void OfficeOn()
    {
        menu.SetActive(false);
        inventory.SetActive(false);
        office.SetActive(true);
        crafting.SetActive(false);
        store.SetActive(false);
    }
    public void CraftingOn()
    {
        menu.SetActive(false);
        inventory.SetActive(false);
        office.SetActive(false);
        crafting.SetActive(true);
        store.SetActive(false);
    }
    public void StoreOn()
    {
        menu.SetActive(false);
        inventory.SetActive(false);
        office.SetActive(false);
        crafting.SetActive(false);
        store.SetActive(true);
    }

}
