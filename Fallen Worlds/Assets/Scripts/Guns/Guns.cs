using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenuAttribute(fileName = "New Gun", menuName = "Gun Creation/Guns")]
public class Guns : ScriptableObject
{
    //public Image gunImage;
    public float damage;
    public int magSize;
    public int spareBullets;
    public GameObject bulllet;
    public bool fullAuto = false;
}
