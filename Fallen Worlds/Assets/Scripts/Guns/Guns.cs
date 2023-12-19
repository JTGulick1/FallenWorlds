using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenuAttribute(fileName = "New Gun", menuName = "Gun Creation/Guns")]
public class Guns : ScriptableObject
{
    //public Image gunImage;
    public GameObject gunPrefab;
    [Header("Base Gun Stats")]
    public float damage;
    public int magSize;
    public int spareBullets;
    public GameObject bullet;
    [Header("Rate Of Fire")]
    [Tooltip("Only for full auto or burst gun, Leave 0 if it is none")]
    public float fireRate;
    public float burstCooldown;
    [Tooltip("How long till the bullet despawns")]
    public float falloff;
    public bool fullAuto = false;
    public bool tBurst = false;
    public bool fBurst = false;
    public float zoom = 38.0f;
    public AudioClip shootingSound;
    public AudioClip emptySound;
}
