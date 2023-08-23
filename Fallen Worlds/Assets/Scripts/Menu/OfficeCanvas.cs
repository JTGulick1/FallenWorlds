using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfficeCanvas : MonoBehaviour
{
    public TMPro.TMP_Text officeLevelTXT;
    public TMPro.TMP_Text deskLevelTXT;
    public TMPro.TMP_Text fileLevelTXT;
    public TMPro.TMP_Text weoponsLevelTXT;
    public TMPro.TMP_Text backpackLevelTXT;
    public TMPro.TMP_Text bedLevelTXT;
    public TMPro.TMP_Text waterFillerLevelTXT;
    public TMPro.TMP_Text foodSupplyLevelTXT;
    public TMPro.TMP_Text portalLevelTXT;
    private PlayerInfoManager playerInfoManager;

    void Start()
    {
        playerInfoManager = PlayerInfoManager.Instance;
        UpdateOffice();
    }

    public void UpgradeOffice(int upgrade) // when presson the the button find what upgrade and see if the player can upgrade it
    {
        if (upgrade == 1 && playerInfoManager.shards >= playerInfoManager.deskLevel * 20)
        {
            playerInfoManager.shards -= playerInfoManager.deskLevel * 20;
            playerInfoManager.deskLevel++;
        }
        if (upgrade == 2 && playerInfoManager.shards >= playerInfoManager.fileLevel * 20)
        {
            playerInfoManager.shards -= playerInfoManager.fileLevel * 20;
            playerInfoManager.fileLevel++;
        }            
        if (upgrade == 3 && playerInfoManager.shards >= playerInfoManager.weoponsLevel * 20)
        {
            playerInfoManager.shards -= playerInfoManager.weoponsLevel * 20;
            playerInfoManager.weoponsLevel++;
        }
        if (upgrade == 4 && playerInfoManager.shards >= playerInfoManager.backpackLevel * 20)
        {
            playerInfoManager.shards -= playerInfoManager.backpackLevel * 20;
            playerInfoManager.backpackLevel++;
        }
        if (upgrade == 5 && playerInfoManager.shards >= playerInfoManager.bedLevel * 20)
        {
            playerInfoManager.shards -= playerInfoManager.bedLevel * 20;
            playerInfoManager.bedLevel++;
        }
        if (upgrade == 6 && playerInfoManager.shards >= playerInfoManager.waterFillerLevel * 20)
        {
            playerInfoManager.shards -= playerInfoManager.waterFillerLevel * 20;
            playerInfoManager.waterFillerLevel++;
        }
        if (upgrade == 7 && playerInfoManager.shards >= playerInfoManager.foodSupplyLevel * 20)
        {
            playerInfoManager.shards -= playerInfoManager.foodSupplyLevel * 20;
            playerInfoManager.foodSupplyLevel++;
        }
        if (upgrade == 8 && playerInfoManager.shards >= playerInfoManager.portalLevel * 20)
        {
            playerInfoManager.shards -= playerInfoManager.portalLevel * 20;
            playerInfoManager.portalLevel++;
        }
        UpdateOffice();
    }

    private void UpdateOffice() // update UI
    {
        playerInfoManager.officeLevel = playerInfoManager.deskLevel + playerInfoManager.fileLevel + playerInfoManager.weoponsLevel + playerInfoManager.backpackLevel + playerInfoManager.bedLevel + playerInfoManager.waterFillerLevel + playerInfoManager.foodSupplyLevel + playerInfoManager.portalLevel - 8;
        officeLevelTXT.text = "Office Level: " + playerInfoManager.officeLevel;
        deskLevelTXT.text = "Desk Level: " + playerInfoManager.deskLevel + " (Health Regen Increase 1% per upgrade) Cost: " + (playerInfoManager.deskLevel * 20) + " Shards";
        fileLevelTXT.text = "File Level: " + playerInfoManager.fileLevel + " (Speed Increase 1% per upgrade) Cost: " + (playerInfoManager.fileLevel * 20) + " Shards";
        weoponsLevelTXT.text = "Weopons Stash: " + playerInfoManager.weoponsLevel + " (Increased Spare Ammo) Cost: " + (playerInfoManager.weoponsLevel * 20) + " Shards";
        backpackLevelTXT.text = "Backpack Level: " + playerInfoManager.backpackLevel + " (Backpack Size 1 slot per upgrade) Cost: " + (playerInfoManager.backpackLevel * 20) + " Shards";
        bedLevelTXT.text = "Bed Level: " + playerInfoManager.bedLevel + " (Sleeping takes less time) Cost: " + (playerInfoManager.bedLevel * 20) + " Shards";
        waterFillerLevelTXT.text = "Water Filler Level: " + playerInfoManager.waterFillerLevel + " (Hydration can be bought for cheaper) Cost: " + (playerInfoManager.waterFillerLevel * 20) + " Shards";
        foodSupplyLevelTXT.text = "Food Supply Level: " + playerInfoManager.foodSupplyLevel + " (Food can be bought for cheaper) Cost: " + (playerInfoManager.foodSupplyLevel * 20) + " Shards";
        portalLevelTXT.text = "Portal Level: " + playerInfoManager.portalLevel + " (Returning through portal is cheaper) Cost: " + (playerInfoManager.portalLevel * 20) + " Shards";
    }
}
