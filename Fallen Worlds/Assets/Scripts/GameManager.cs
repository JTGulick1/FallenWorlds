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
    [SerializeField]
    private GameObject boss;
    public GameObject b_spawn;
    private bool bossSpawned = false;

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
    private bool refuel;

    [Header("Upgradable Spot Items")]
    private Item USItem1;
    private Item USItem2;
    private Item USItem3;
    private bool closeToUpgrade;
    public UpgradeableSpot upgradeableSpot;

    [Header("End Game")]
    private PlayerInfoManager playerInfoManager;
    private bool playerIsNoMore = false;
    private float backtoLobby = 0.0f;
    private string lobby;
    private int shardsGained;
    private TMPro.TMP_Text gained;

    [Header("Player")]
    public GameObject player;

    private void Awake()
    {
        playerInfoManager = PlayerInfoManager.Instance;
        pointstxt = GameObject.FindGameObjectWithTag("PlayersPoints").GetComponent<Text>();
        doortxt = GameObject.FindGameObjectWithTag("DoorTXT").GetComponent<Text>();
        gunController = GameObject.FindGameObjectWithTag("Player").GetComponent<GunController>();
        wavenumTXT = GameObject.FindGameObjectWithTag("WaveTXT").GetComponent<Text>();
        endScreen = GameObject.FindGameObjectWithTag("End Screen");
        backpack = GameObject.FindGameObjectWithTag("Player").GetComponent<Backpack>();
        player = GameObject.FindGameObjectWithTag("Player");
        clipAmmo = GameObject.FindGameObjectWithTag("ClipTXT").GetComponent<Text>();
        spareAmmo = GameObject.FindGameObjectWithTag("SpareTXT").GetComponent<Text>();
        gained = GameObject.FindGameObjectWithTag("GainedTXT").GetComponent<TMPro.TMP_Text>();
        gained.gameObject.SetActive(false);
        playerInfoManager.FindGameManager();
        doortxt.gameObject.SetActive(false);
        endScreen.SetActive(false);
        inputManager = InputManager.Instance;
        pointstxt.text = "0";
        wavenumTXT.text = waveNumber.ToString();
        FindSpawners();
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
        if (backpack.CheckForItemOnly(USItem1) && backpack.CheckForItemOnly(USItem2) && backpack.CheckForItemOnly(USItem3) && closeToUpgrade == true && inputManager.Interacted())
        {
            backpack.CheckForItem(USItem1);
            backpack.CheckForItem(USItem2);
            backpack.CheckForItem(USItem3);
            upgradeableSpot.Upgraded();
        }
        if (isclosetodoor == true && int.Parse(pointstxt.text) >= doorCost && inputManager.Interacted() == true && forShards == false)
        {
            GiveEXP(25);
            RemovePoints(doorCost);
            OutOfDoorRange();
            Destroy(closestdoor);
        }
        if (isclosetodoor == true && playerInfoManager.shards >= doorCost && inputManager.Interacted() == true && forShards == true)
        {
            GiveEXP(100);
            RemoveShards(doorCost);
            OutOfDoorRange();
            Destroy(closestdoor);
        }
        if (isclosetoitemdoor == true && inputManager.Interacted() == true && backpack.CheckForItem(item) == true)
        {
            GiveEXP(75);
            OutOfDoorRange();
            Destroy(closestdoor);
        }

        if (isclosetoportal == true && int.Parse(pointstxt.text) >= portalCost - ((playerInfoManager.portalLevel - 1) * 100) && inputManager.Interacted() == true)
        {
            GiveEXP(200);
            doortxt.gameObject.SetActive(true);
            gained.gameObject.SetActive(true);
            RemovePoints(portalCost);
            doortxt.text = "You Survived";
            pointstxt.gameObject.SetActive(false);
            Destroy(gunController.gameObject);
            endScreen.SetActive(true);
            shardsGained = playerInfoManager.PointsToShards(int.Parse(pointstxt.text));
            gained.text = "Shards Gained: " + shardsGained;
            playerInfoManager.AddToInventory(backpack.items);
            playerIsNoMore = true;
        }
        if (isclosetobuy == true && int.Parse(pointstxt.text) >= buyCost && inputManager.Interacted() == true && gunController.primaryGun != tempWeopon && refuel == false)
        {
            GiveEXP(15);
            gunController.BoughtWeopon(tempWeopon);
            RemovePoints(buyCost);
        }
        if (isclosetobuy == true && int.Parse(pointstxt.text) >= buyCost && inputManager.Interacted() == true && gunController.primaryGun == tempWeopon && refuel == true)
        {
            GiveEXP(5);
            gunController.FullAmmo();
            RemovePoints(buyCost);
        }
        if (enemysOnFeild == 0)
        {
            spawntimer += Time.deltaTime;
            spawners.Clear();
            FindSpawners();
            if (spawntimer >= 3.0f)
            {
                waveNumber++;
                wavenumTXT.text = waveNumber.ToString();
                spawnNumber += (7 + (3 * waveNumber));
                SpawnWave();
                spawntimer = 0.0f;
            }
        }

        if (waveNumber % 7 == 0 && bossSpawned == false)
        {
            SpawnBoss();
            bossSpawned = true;
        }

        if (bossSpawned == true && waveNumber % 7 != 0)
        {
            bossSpawned = false;
        }

        if (playerIsNoMore == true)
        {
            Cursor.lockState = CursorLockMode.None;
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
            enemysOnFeild = spawnNumber;
            leftOver = spawnNumber - 33;
            enemysOnFeild -= leftOver;
            for (int i = 0; i < 33; i++)
            {
                if (spawnNumber > 0)
                {
                    int randomSpawner = Random.Range(0, spawners.Count);
                    spawners[randomSpawner].GetComponent<SpawnEnemy>().Spawn(baseEnemy);
                    spawnNumber--;
                }
            }
            return;
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
    }

    public void SpawnLeftOvers()
    {
        enemysOnFeild++;
        if (leftOver > 0)
        {
            int randomSpawner = Random.Range(0, spawners.Count);
            spawners[randomSpawner].GetComponent<SpawnEnemy>().Spawn(baseEnemy);
            spawnNumber--;
            leftOver--;
        }
    }
    public void SpawnBoss()
    {
        Instantiate(boss, b_spawn.transform.position, b_spawn.transform.rotation);
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

    public void RemoveShards(int shards)
    {
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
            doortxt.text = "Buy Door: " + " (Cost: " + costD.ToString() + ")";
        }
        if (forS == true)
        {
            doortxt.text = "Buy Door: " + " (Cost: " + costD.ToString() + " Shards)";
        }
    }

    public void OutOfDoorRange()
    {
        isclosetodoor = false;
        doortxt.gameObject.SetActive(false);
    }

    public void CloseToBuy(Guns gun, int costD, int reloadCost)
    {
        if (gunController.primaryGun == gun)
        {
            refuel = true;
            tempWeopon = gun;
            isclosetobuy = true;
            buyCost = reloadCost;
            doortxt.gameObject.SetActive(true);
            doortxt.text = "Buy Ammo: " + gun.name + " (Cost: " + reloadCost.ToString() + ")";
            return;
        }
        if (gunController.primaryGun != gun)
        {
            refuel = false;
            tempWeopon = gun;
            isclosetobuy = true;
            buyCost = costD;
            doortxt.gameObject.SetActive(true);
            doortxt.text = "Buy: " + gun.name + " (Cost: " + costD.ToString() + ")";
            return;
        }
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

    public void Upgradeable(Item item1, Item item2, Item item3)
    {
        USItem1 = item1;
        USItem2 = item2;
        USItem3 = item3;
        closeToUpgrade = true;
        doortxt.gameObject.SetActive(true);
        doortxt.text = "Upgrade Spot?";
    }

    public void OutofUpgradeRange()
    {
        closeToUpgrade = false;
        doortxt.gameObject.SetActive(false);
    }

    public void GiveEXP(int exp)
    {
        playerInfoManager.playerEXP += exp;
    }

    public void FindSpawners()
    {
        float first = 99999999;
        float second = 99999999;
        float third = 99999999;
        foreach (GameObject spawner in GameObject.FindGameObjectsWithTag("Spawner"))
        {
            if (Vector3.Distance(player.transform.position, spawner.transform.position) <= first)
            {
                first = Vector3.Distance(player.transform.position, spawner.transform.position);
                //spawners.RemoveAt(0);
                spawners.Add(spawner);
            }
            else if (Vector3.Distance(player.transform.position, spawner.transform.position) <= second)
            {
                second = Vector3.Distance(player.transform.position, spawner.transform.position);
                //spawners.RemoveAt(1);
                spawners.Add(spawner);

            }
            else if (Vector3.Distance(player.transform.position, spawner.transform.position) <= third)
            {
                third = Vector3.Distance(player.transform.position, spawner.transform.position);
                //spawners.RemoveAt(2);
                spawners.Add(spawner);
            }
        }
    }

    #endregion;

}
