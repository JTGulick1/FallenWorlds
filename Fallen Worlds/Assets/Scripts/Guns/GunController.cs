using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public Guns primaryGun;
    public Guns secondaryGun;
    private Guns tempGun;
    private InputManager inputManager;
    public Transform shootFrom;
    public GameObject bullet;
    private GameObject mostRecentBullet;
    private GameManager gm;

    private int ammoInClipPrimary;
    private int spareAmmoPrimary;
    private int ammoInClipSecondary;
    private int spareAmmoSecondary;
    private int tempAmmo;
    private int tempSpare;

    void Start()
    {
        inputManager = InputManager.Instance;
        inputManager.auto = primaryGun.fullAuto;
        gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        ammoInClipPrimary = primaryGun.magSize;
        ammoInClipSecondary = secondaryGun.magSize;
        spareAmmoPrimary = primaryGun.spareBullets;
        spareAmmoSecondary = secondaryGun.spareBullets;
        gm.SetAmmoCount(ammoInClipPrimary, spareAmmoPrimary);
    }

    void Update()
    {
        if (inputManager.Fire() == true && ammoInClipPrimary != 0)
        {
            mostRecentBullet = Instantiate(bullet, shootFrom.transform.position, shootFrom.transform.rotation);
            ammoInClipPrimary--;
            gm.SetAmmoCount(ammoInClipPrimary, spareAmmoPrimary);
            mostRecentBullet.GetComponent<Bullet>().SetDamage(primaryGun.damage);
        }
        if (Input.GetAxis("Mouse ScrollWheel") >= 0.1 || Input.GetAxis("Mouse ScrollWheel") <= -0.1)
        {
            tempGun = primaryGun;
            primaryGun = secondaryGun;
            secondaryGun = tempGun;

            tempAmmo = ammoInClipPrimary;
            ammoInClipPrimary = ammoInClipSecondary;
            ammoInClipSecondary = tempAmmo;

            tempSpare = spareAmmoPrimary;
            spareAmmoPrimary = spareAmmoSecondary;
            spareAmmoSecondary = tempSpare;

            gm.SetAmmoCount(ammoInClipPrimary, spareAmmoPrimary);

            inputManager.auto = primaryGun.fullAuto;
        }
        if (inputManager.Reload() == true)
        {
            Reload();
        }
    }

    public void BoughtWeopon(Guns gun)
    {
        primaryGun = gun;
        ammoInClipPrimary = gun.magSize;
        spareAmmoPrimary = gun.spareBullets;
    }

    private void Reload()
    {
        if (ammoInClipPrimary == primaryGun.magSize)
        {
            return;
        }
        if (spareAmmoPrimary == 0)
        {
            return;
        }
        int diff;
        if (spareAmmoPrimary < primaryGun.magSize)
        {
            diff = (primaryGun.magSize - ammoInClipPrimary);
            if (diff > spareAmmoPrimary)
            {
                diff = spareAmmoPrimary;
                spareAmmoPrimary -= diff;
            }
            ammoInClipPrimary += diff;
            spareAmmoPrimary -= diff;
            if (spareAmmoPrimary <= 0)
                spareAmmoPrimary = 0;
            gm.SetAmmoCount(ammoInClipPrimary, spareAmmoPrimary);
            return;
        }
        diff = (primaryGun.magSize - ammoInClipPrimary);
        ammoInClipPrimary = primaryGun.magSize;
        spareAmmoPrimary -= diff;
        gm.SetAmmoCount(ammoInClipPrimary, spareAmmoPrimary);
    }

    public void MaxAmmo()
    {
        ammoInClipPrimary = primaryGun.magSize;
        ammoInClipSecondary = secondaryGun.magSize;
        spareAmmoPrimary = primaryGun.spareBullets;
        spareAmmoSecondary = secondaryGun.spareBullets;
        gm.SetAmmoCount(ammoInClipPrimary, spareAmmoPrimary);
    }
}
