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

    private AudioSource click;

    private void Start()
    {
        playerInfoManager = PlayerInfoManager.Instance;
        click = GameObject.FindGameObjectWithTag("MenuAC").GetComponent<AudioSource>();
    }

    private void Update()
    {
        UpdateStats();
    }

    public void UpdateStats() // update the players stats when needed
    {
        hydration.text = "Hydration: " + playerInfoManager.hydration;
        hunger.text = "Hunger: " + playerInfoManager.hunger;
        fatigue.text = "Fatigue: " + playerInfoManager.sleep;
        shards.text = "Shards: " + playerInfoManager.shards;
    }

    public void DrinkWater()
    {
        if (playerInfoManager.shards >= 15 - (playerInfoManager.waterFillerLevel - 1))
        {
            playerInfoManager.shards -= 15;
            playerInfoManager.hydration += 15;
        }
    }
    public void EatFood()
    {
        if (playerInfoManager.shards >= 15 - (playerInfoManager.foodSupplyLevel - 1))
        {
            playerInfoManager.shards -= 15;
            playerInfoManager.hunger += 15;
        }
    }

    // Functions that make the UI feel better
    #region Extra Functions
    public void MenuOn()
    {
        click.Play();
        menu.SetActive(true);
        inventory.SetActive(false);
        office.SetActive(false);
        crafting.SetActive(false);
        store.SetActive(false);
    }
    public void InvOn()
    {
        click.Play();
        menu.SetActive(false);
        inventory.SetActive(true);
        office.SetActive(false);
        crafting.SetActive(false);
        store.SetActive(false);
    }
    public void OfficeOn()
    {
        click.Play();
        menu.SetActive(false);
        inventory.SetActive(false);
        office.SetActive(true);
        crafting.SetActive(false);
        store.SetActive(false);
    }
    public void CraftingOn()
    {
        click.Play();
        menu.SetActive(false);
        inventory.SetActive(false);
        office.SetActive(false);
        crafting.SetActive(true);
        store.SetActive(false);
    }
    public void StoreOn()
    {
        click.Play();
        menu.SetActive(false);
        inventory.SetActive(false);
        office.SetActive(false);
        crafting.SetActive(false);
        store.SetActive(true);
    }
    #endregion
}
