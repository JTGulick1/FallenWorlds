using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Points
    private Text pointstxt;

    //Door info
    private Text doortxt;
    private bool isclosetodoor = false;
    private bool isclosetoitemdoor = false;
    private GameObject closestdoor;
    private int doorCost;

    //Wall Buy Info
    private Guns tempWeopon;
    private bool isclosetobuy = false;
    private int buyCost;

    //Portal Buy Info
    private bool isclosetoportal = false;
    private int portalCost;
    private GameObject endScreen;

    //Enemy
    public List<GameObject> spawners = new List<GameObject>();
    public GameObject baseEnemy;

    private InputManager inputManager;
    private GunController gunController;

    private float spawntimer;

    private int waveNumber = 1;
    private int spawnNumber = 7;
    public int enemysOnFeild = -1;

    private Text wavenumTXT;

    //Items
    public List<Item> items = new List<Item>();
    public Item item;
    private Backpack backpack;

    private Text clipAmmo;
    private Text spareAmmo;

    //End Game
    private PlayerInfoManager playerInfoManager;
    private bool playerIsNoMore = false;
    private float backtoLobby = 0.0f;
    private string lobby;

    private void Awake()
    {
        pointstxt = GameObject.FindGameObjectWithTag("PlayersPoints").GetComponent<Text>();
        doortxt = GameObject.FindGameObjectWithTag("DoorTXT").GetComponent<Text>();
        gunController = GameObject.FindGameObjectWithTag("Player").GetComponent<GunController>();
        wavenumTXT = GameObject.FindGameObjectWithTag("WaveTXT").GetComponent<Text>();
        endScreen = GameObject.FindGameObjectWithTag("End Screen");
        backpack = GameObject.FindGameObjectWithTag("Player").GetComponent<Backpack>();
        clipAmmo = GameObject.FindGameObjectWithTag("ClipTXT").GetComponent<Text>();
        spareAmmo = GameObject.FindGameObjectWithTag("SpareTXT").GetComponent<Text>();
        playerInfoManager = GameObject.FindGameObjectWithTag("PlayerInfoManager").GetComponent<PlayerInfoManager>();
        playerInfoManager.FindGameManager();
        doortxt.gameObject.SetActive(false);
        endScreen.SetActive(false);
        inputManager = InputManager.Instance;
        pointstxt.text = "0";
        wavenumTXT.text = waveNumber.ToString();
        foreach (GameObject gameObject in GameObject.FindGameObjectsWithTag("Spawner"))
        {
            spawners.Add(gameObject);
        }
        SpawnWave();
    }
    private void Start()
    {
        if (inputManager == null)
        {
            inputManager = InputManager.Instance;
        }
    }
    private void Update()
    {
        if (isclosetodoor == true && int.Parse(pointstxt.text) >= doorCost && inputManager.Interacted() == true)
        {
            RemovePoints(doorCost);
            OutOfDoorRange();
            Destroy(closestdoor);
        }
        if (isclosetoitemdoor == true && inputManager.Interacted() == true)
        {
            if (backpack.CheckForItem(item) == true)
            {
                OutOfDoorRange();
                Destroy(closestdoor);
            }
        }

        if (isclosetoportal == true && int.Parse(pointstxt.text) >= portalCost && inputManager.Interacted() == true)
        {
            doortxt.gameObject.SetActive(true);
            RemovePoints(portalCost);
            doortxt.text = "You Survived";
            pointstxt.gameObject.SetActive(false);
            Destroy(gunController.gameObject);
            endScreen.SetActive(true);
            playerInfoManager.PointsToShards(int.Parse(pointstxt.text));
            playerInfoManager.AddToInventory(backpack.items);
            playerIsNoMore = true;
        }
        if (isclosetobuy == true && int.Parse(pointstxt.text) >= buyCost && inputManager.Interacted() == true && gunController.primaryGun != tempWeopon)
        {
            gunController.BoughtWeopon(tempWeopon);
            RemovePoints(buyCost);
        }
        if (enemysOnFeild == 0)
        {
            spawntimer += Time.deltaTime;
            if (spawntimer >= 3.0f)
            {
                waveNumber++;
                wavenumTXT.text = waveNumber.ToString();
                spawnNumber += 7;
                SpawnWave();
                spawntimer = 0.0f;
            }
        }

        if (playerIsNoMore == true)
        {
            playerInfoManager.inGameTick = false;
            playerInfoManager.timer = 0.0f;
            doortxt.gameObject.SetActive(true);
            endScreen.SetActive(true);
            lobby = "Menu";
            backtoLobby += Time.deltaTime;
            if (backtoLobby >= 10.0f)
            {
                SceneManager.LoadScene(lobby);
            }
        }
    }


    #region Helper Functions
    public void SpawnWave()
    {
        enemysOnFeild = spawnNumber;
        for (int i = 0; i < spawnNumber; i++)
        {
            int seedNumber = Random.Range(0, spawners.Count);
            spawners[seedNumber].GetComponent<SpawnEnemy>().Spawn(baseEnemy);
        }
    }
    public void AddPoints(int pts)
    {
        pts += int.Parse(pointstxt.text);
        pointstxt.text = pts.ToString();
    }

    public void RemovePoints(int pts)
    {
        int tempint;
        tempint = int.Parse(pointstxt.text);
        tempint -= pts;
        pointstxt.text = tempint.ToString();
    }

    public void CloseToDoor(GameObject door, int costD)
    {
        closestdoor = door;
        isclosetodoor = true;
        doorCost = costD;
        doortxt.gameObject.SetActive(true);
        doortxt.text = "Buy: " + " (Cost: " + costD.ToString() + ")";
    }

    public void OutOfDoorRange()
    {
        isclosetodoor = false;
        doortxt.gameObject.SetActive(false);
    }

    public void CloseToBuy(Guns gun, int costD)
    {
        tempWeopon = gun;
        isclosetobuy = true;
        buyCost = costD;
        doortxt.gameObject.SetActive(true);
        doortxt.text = "Buy: " + gun.name + " (Cost: " + costD.ToString() + ")";
    }

    public void OutOfBuyRange()
    {
        tempWeopon = null;
        isclosetobuy = false;
        doortxt.gameObject.SetActive(false);
    }

    public void CloseToPortal(int costD)
    {
        if (waveNumber % 5 == 0)
        {
            isclosetoportal = true;
            portalCost = costD;
            doortxt.gameObject.SetActive(true);
            doortxt.text = "Buy: " + " (Cost: " + costD.ToString() + ")";
        }
        if (waveNumber % 5 != 0)
        {
            doortxt.text = "Portal Not Active";
        }
    }

    public void OutOfPortalRange()
    {
        isclosetoportal = false;
        doortxt.gameObject.SetActive(false);
    }

    public int GetWaveNumber()
    {
        return waveNumber;
    }

    public Item GetRandomItem()
    {
        Item tempitem;

        tempitem = items[Random.Range(0, items.Count)];

        return tempitem;
    }

    public void CloseToItemDoor(GameObject door, Item tempItem)
    {
        closestdoor = door;
        isclosetoitemdoor = true;
        item = tempItem;
        doortxt.gameObject.SetActive(true);
        doortxt.text = "Buy: " + " (Required Item: " + tempItem.name + ")";
    }

    public void SetAmmoCount(int clip, int spare)
    {
        clipAmmo.text = clip.ToString();
        spareAmmo.text = spare.ToString();
    }

    public void Dying()
    {
        //Start to black out
    }

    public void KillPlayer()
    {
        doortxt.text = "You Died";
        playerIsNoMore = true;
        Destroy(gunController.gameObject);
    }

    #endregion;

}
