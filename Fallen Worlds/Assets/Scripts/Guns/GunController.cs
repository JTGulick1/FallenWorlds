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
    public ParticleSystem gunflare;
    private GameObject mostRecentBullet;
    private GameManager gm;
    private PlayerInfoManager playerInfoManager;

    private int ammoInClipPrimary;
    private int spareAmmoPrimary;
    private int ammoInClipSecondary;
    private int spareAmmoSecondary;
    private int tempAmmo;
    private int tempSpare;

    private float timer = 0.0f;
    private float cooldown = 0.0f;
    private int bulletTick;

    void Start()
    {
        playerInfoManager = PlayerInfoManager.Instance;
        inputManager = InputManager.Instance;
        inputManager.auto = primaryGun.fullAuto;
        gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        ammoInClipPrimary = primaryGun.magSize;
        spareAmmoPrimary = primaryGun.spareBullets + (playerInfoManager.weoponsLevel - 1) * (ammoInClipPrimary / 4);
        gm.SetAmmoCount(ammoInClipPrimary, spareAmmoPrimary);
    }

    void Update()
    {
        timer += Time.deltaTime;
        cooldown += Time.deltaTime;
        if (inputManager.Fire() == true && ammoInClipPrimary != 0 && timer > primaryGun.fireRate && cooldown > primaryGun.burstCooldown)
        {
            FireGun();
        }
        if (Input.GetAxis("Mouse ScrollWheel") >= 0.1 || Input.GetAxis("Mouse ScrollWheel") <= -0.1) //Changing gun logic
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

    public void BoughtWeopon(Guns gun) // when you buy a weopon replace the current one
    {
        primaryGun = gun;
        ammoInClipPrimary = gun.magSize;
        spareAmmoPrimary = gun.spareBullets;
    }

    private void Reload() // Reloading logic
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

    public void MaxAmmo() // Power up?
    {
        ammoInClipPrimary = primaryGun.magSize;
        ammoInClipSecondary = secondaryGun.magSize;
        spareAmmoPrimary = primaryGun.spareBullets;
        spareAmmoSecondary = secondaryGun.spareBullets;
        gm.SetAmmoCount(ammoInClipPrimary, spareAmmoPrimary);
    }

    public void FullAmmo()
    {
        ammoInClipPrimary = primaryGun.magSize;
        spareAmmoPrimary = primaryGun.spareBullets;
        gm.SetAmmoCount(ammoInClipPrimary, spareAmmoPrimary);
    }

    public void FireGun()
    {
        if (primaryGun.tBurst != true && primaryGun.fBurst != true)
        {
            gunflare.Play();
            mostRecentBullet = Instantiate(bullet, shootFrom.transform.position, shootFrom.transform.rotation);
            mostRecentBullet.GetComponent<Bullet>().falloff = primaryGun.falloff;
            ammoInClipPrimary--;
            gm.SetAmmoCount(ammoInClipPrimary, spareAmmoPrimary);
            mostRecentBullet.GetComponent<Bullet>().SetDamage(primaryGun.damage);
            timer = 0.0f;
            return;
        }
        if (primaryGun.tBurst == true && cooldown > primaryGun.burstCooldown)
        {
            gunflare.Play();
            mostRecentBullet = Instantiate(bullet, shootFrom.transform.position, shootFrom.transform.rotation);
            mostRecentBullet.GetComponent<Bullet>().falloff = primaryGun.falloff;
            ammoInClipPrimary--;
            gm.SetAmmoCount(ammoInClipPrimary, spareAmmoPrimary);
            mostRecentBullet.GetComponent<Bullet>().SetDamage(primaryGun.damage);
            timer = 0.0f;
            bulletTick++;
            if (bulletTick > 2)
            {
                cooldown = 0.0f;
                bulletTick = 0;
            }
            return;
        }
        if (primaryGun.fBurst == true && cooldown > primaryGun.burstCooldown)
        {
            gunflare.Play();
            mostRecentBullet = Instantiate(bullet, shootFrom.transform.position, shootFrom.transform.rotation);
            mostRecentBullet.GetComponent<Bullet>().falloff = primaryGun.falloff;
            ammoInClipPrimary--;
            gm.SetAmmoCount(ammoInClipPrimary, spareAmmoPrimary);
            mostRecentBullet.GetComponent<Bullet>().SetDamage(primaryGun.damage);
            timer = 0.0f;
            bulletTick++;
            if (bulletTick > 3)
            {
                cooldown = 0.0f;
                bulletTick = 0;
            }
            return;
        }
    }
}
