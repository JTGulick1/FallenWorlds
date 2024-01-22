using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfoManager : MonoBehaviour
{

    public List<Item> inverntory = new List<Item>();

    public List<Item> backpack = new List<Item>();
    [SerializeField]
    private int backpackCap;
    [Header("Player Stats")]
    public int playerLevel = 1;
    public int shards;
    public int hunger;
    public int hydration;
    public int sleep;
    public int playerEXP = 0;
    public int playerEXPCap = 100;

    private GameManager gm;

    public bool inGameTick;
    private bool HT = false; //hydration tick checks if the player is in game or in lobby
    private bool ET = false; //sleep tick
    public float timer;

    [Header("Office Stats")]
    public int officeLevel = 0;
    public int deskLevel = 1;
    public int fileLevel = 1;
    public int weoponsLevel = 1;
    public int backpackLevel = 1;
    public int bedLevel = 1;
    public int waterFillerLevel = 1;
    public int foodSupplyLevel = 1;
    public int portalLevel = 1;


    private static PlayerInfoManager _instance;

    public static PlayerInfoManager Instance
    {
        get
        {
            return _instance;
        }
    }




    private void Awake()
    {
        Object.DontDestroyOnLoad(this.gameObject);
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
        inGameTick = false;
    }

    private void Update()
    {
        if (inGameTick == true)
        {
            timer += Time.deltaTime;
            if (timer >= 45.0f && HT == false)
            {
                hydration--;
                HT = true;
            }
            if (timer >= 60.0f - (bedLevel - 1) && ET == false)
            {
                sleep--;
                ET = true;
            }
            if (timer >= 75.0f)
            {
                hunger--;
                timer = 0.0f;
                HT = false;
                ET = false;
            }
        }
        if (inGameTick == false)
        {
            timer += Time.deltaTime;
            if (timer >= 45.0f && HT == false && hydration != 100)
            {
                hydration++;
                HT = true;
            }
            if (timer >= 60.0f && ET == false && sleep != 100)
            {
                sleep++;
                ET = true;
            }
            if (timer >= 75.0f && hunger != 100)
            {
                hunger++;
                timer = 0.0f;
                HT = false;
                ET = false;
            }
        }
        if (playerEXP >= playerEXPCap)
        {
            Promote();
        }
    }

    public void FindGameManager()
    {
        gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    public void Dead()
    {
        if (hunger <= 10 || hydration <= 10 || sleep <= 10)
        {
            gm.Dying();
        }
        if (hunger == 0 || hydration == 0 || sleep == 0)
        {
            gm.KillPlayer();
        }
    }

    public int PointsToShards(int Points)
    {
        float temp = 0;
        // Takes every 100 points that the player has and converts it to 1 shard
        temp += Points / 100;
        shards = ((int)temp);
        return ((int)temp);
    }

    public void AddToInventory(List<Item> items)
    {
        foreach (Item item in items)
        {
            backpack.Add(item);
        }
    }

    public void MoveToInGameBackPack(List<Item> items)
    {
        foreach (Item item in backpack)
        {
            items.Add(item);
        }
        backpack.Clear();
    }

    public void Promote()
    {
        playerLevel++;
        playerEXP = playerEXP - playerEXPCap;
        playerEXPCap = playerLevel * 53;
    }
}
