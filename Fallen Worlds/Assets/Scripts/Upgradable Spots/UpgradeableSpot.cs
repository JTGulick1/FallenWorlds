using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeableSpot : MonoBehaviour
{
    [Header("Health Upgrade")]
    public Item HI1;
    public Item HI2;
    public Item HI3;
    public GameObject HealthUpgradeTotom;

    [Header("Speed Upgrade")]
    public Item SI1;
    public Item SI2;
    public Item SI3;
    public GameObject SpeedUpgradeTotom;

    public enum Upgrade
    {
        HealthUpgrade,
        SpeedUpgrade
    }
    public Upgrade upgrade;

    private GameManager gm;

    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    { //if the player is close enough to spawn UI
        if (other.gameObject.tag == "Player")
        {
            gm.upgradeableSpot = this;
            if (upgrade == Upgrade.HealthUpgrade)
            {
                gm.Upgradeable(HI1, HI2, HI3);
            }
            if (upgrade == Upgrade.SpeedUpgrade)
            {
                gm.Upgradeable(SI1, SI2, SI3);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    { //Despawn UI
        if (other.gameObject.tag == "Player")
        {
            gm.OutofUpgradeRange();
        }
    }

    public void Upgraded()
    {
        if (upgrade == Upgrade.HealthUpgrade)
        {
            Instantiate(HealthUpgradeTotom, transform.position, transform.rotation);
        }
        if (upgrade == Upgrade.SpeedUpgrade)
        {
            Instantiate(SpeedUpgradeTotom, transform.position, transform.rotation);
        }
        Destroy(gameObject);
    }
}
