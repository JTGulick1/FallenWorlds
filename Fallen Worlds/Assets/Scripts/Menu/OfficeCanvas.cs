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

    private int officeLevel = 0;
    private int deskLevel = 1;
    private int fileLevel = 1;
    private int weoponsLevel = 1;
    private int backpackLevel = 1;
    private int bedLevel = 1;
    private int waterFillerLevel = 1;
    private int foodSupplyLevel = 1;
    private int portalLevel = 1;


    void Start()
    {
        playerInfoManager = PlayerInfoManager.Instance;
        officeLevel = deskLevel + fileLevel + weoponsLevel + backpackLevel + bedLevel + waterFillerLevel + foodSupplyLevel + portalLevel;
        officeLevelTXT.text = "Office Level: " + officeLevel;
        deskLevelTXT.text = "Desk Level: " + deskLevel + " (Health Regen Increase 1% per upgrade) Cost: " + (deskLevel * 20) + " Shards";
        fileLevelTXT.text = "File Level: " + fileLevel + " (Speed Increase 1% per upgrade) Cost: " + (fileLevel * 20) + " Shards";
        weoponsLevelTXT.text = "Weopons Stash: " + weoponsLevel + " (Increased Spare Ammo) Cost: " + (weoponsLevel * 20) + " Shards";
        backpackLevelTXT.text = "Backpack Level: " + backpackLevel + " (Backpack Size 1 slot per upgrade) Cost: " + (backpackLevel * 20) + " Shards";
        bedLevelTXT.text = "Bed Level: " + bedLevel + " (Sleeping takes less time) Cost: " + (bedLevel * 20) + " Shards";
        waterFillerLevelTXT.text = "Water Filler Level: " + waterFillerLevel + " (Hydration can be bought for cheaper) Cost: " + (waterFillerLevel * 20) + " Shards";
        foodSupplyLevelTXT.text = "Food Supply Level: " + foodSupplyLevel + " (Food can be bought for cheaper) Cost: " + (foodSupplyLevel * 20) + " Shards";
        portalLevelTXT.text = "Portal Level: " + portalLevel + " (Returning through portal is cheaper) Cost: " + (portalLevel * 20) + " Shards";
    }


}
