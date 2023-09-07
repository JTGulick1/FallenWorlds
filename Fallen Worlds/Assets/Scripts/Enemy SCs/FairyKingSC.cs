using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

public class FairyKingSC : EnemyManager
{
    public GameObject slam;
    public GameObject throwable;
    public GameObject shootfrom;

    public void ThrowJav()
    {
        Instantiate(throwable, shootfrom.transform.position, shootfrom.transform.rotation);
    }

    public void FlyAndSlam()
    {
        slam.SetActive(true);
    }
}
