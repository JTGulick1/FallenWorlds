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
    private bool forShards;

    //Wall Buy Info
    private Guns tempWeopon;
    private bool isclosetobuy = false;
    private int buyCost;

    //Portal Buy Info
    private bool isclosetoportal = false;
    private int portalCost;
    private GameObject endScreen;

    [Header("Enemy Info")]
    public List<GameObject> spawners = new List<GameObject>();
    public GameObject baseEnemy;

    private InputManager inputManager;
    private GunController gunController;

    private float spawntimer;

    private int waveNumber = 1;
    private int spawnNumber = 7;
    public int enemysOnFeild = -1;
    public int leftOver = 0;

    private Text wavenumTXT;
    public Image bleedingOut;

    [Header("Items")]
    public List<Item> items = new List<Item>();
    public Item item;
    private Backpack backpack;

    [Header("Guns")]
    private Text clipAmmo;
    private Text spareAmmo;

    [Header("End Game")]
    private PlayerInfoManager playerInfoManager;
    private bool playerIsNoMore = false;
    private float backtoLobby = 0.0f;
    private string lobby;

    private void Awake()
    {
        playerInfoManager = PlayerInfoManager.Instance;
        pointstxt = GameObject.FindGameObjectWithTag("PlayersPoints").GetComponent<Text>();
        doortxt = GameObject.FindGameObjectWithTag("DoorTXT").GetComponent<Text>();
        gunController = GameObject.FindGameObjectWithTag("Player").GetComponent<GunController>();
        wavenumTXT = GameObject.FindGameObjectWithTag("WaveTXT").GetComponent<Text>();
        endScreen = GameObject.FindGameObjectWithTag("End Screen");
        backpack = GameObject.FindGameObjectWithTag("Player").GetComponent<Backpack>();
        clipAmmo = GameObject.FindGameObjectWithTag("ClipTXT").GetComponent<Text>();
        spareAmmo = GameObject.FindGameObjectWithTag("SpareTXT").GetComponent<Text>();
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
        if (isclosetodoor == true && int.Parse(pointstxt.text) >= doorCost && inputManager.Interacted() == true && forShards == false)
        {
            RemovePoints(doorCost);
            OutOfDoorRange();
            Destroy(closestdoor);
        }
        if (isclosetodoor == true && playerInfoManager.shards >= doorCost && inputManager.Interacted() == true && forShards == true)
        {
            RemoveShards(doorCost);
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

        if (isclosetoportal == true && int.Parse(pointstxt.text) >= portalCost - ((playerInfoManager.portalLevel - 1) * 100) && inputManager.Interacted() == true)
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
                spawnNumber += (7 +(3 * waveNumber));
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
        if (spawnNumber >= 33) // max number of bad guys at one time
        {
            leftOver = spawnNumber - 33;
            enemysOnFeild = spawnNumber;
            while (spawnNumber != 0)
            {
                for (int i = 0; i < spawners.Count; i++)
                {
                    if (spawnNumber != 0)
                    {
                        spawners[i].GetComponent<SpawnEnemy>().Spawn(baseEnemy);
                        spawnNumber--;
                    }
                }
            }
        }
        if (spawnNumber <= 33)
        {
            enemysOnFeild = spawnNumber;
            while (spawnNumber != 0)
            {
                for (int i = 0; i < spawners.Count; i++)
                {
                    if (spawnNumber != 0)
                    {
                        spawners[i].GetComponent<SpawnEnemy>().Spawn(baseEnemy);
                        spawnNumber--;
                    }
                }
            }
        }
        leftOver = 0;
    }

    public void SpawnLeftOvers()
    {
        int randomSpawner = Random.Range(0, spawners.Count);
        spawners[randomSpawner].GetComponent<SpawnEnemy>().Spawn(baseEnemy);
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

    public void RemoveShards(int shards) {
        playerInfoManager.shards -= shards;
    }


    public void CloseToDoor(GameObject door, int costD, bool forS)
    {
        forShards = forS;
        closestdoor = door;
        isclosetodoor = true;
        doorCost = costD;
        doortxt.gameObject.SetActive(true);
        if (forS == false)
        {
            doortxt.text = "Buy: " + " (Cost: " + costD.ToString() + ")";
        }
        if (forS == true)
        {
            doortxt.text = "Buy: " + " (Cost: " + costD.ToString() + " Shards )";
        }
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
        //Sound effect of dying
        bleedingOut.gameObject.SetActive(true);
    }

    public void HealedUp()
    {
        //Sound effect of catching your breath
        bleedingOut.gameObject.SetActive(false);
    }

    public void KillPlayer()
    {
        doortxt.text = "You Died";
        playerIsNoMore = true;
        Destroy(gunController.gameObject);
    }

    #endregion;

}
