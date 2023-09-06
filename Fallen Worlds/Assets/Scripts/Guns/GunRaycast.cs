using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRaycast : MonoBehaviour
{
    public GameObject shootFrom;
    public EnemyManager enemyManager;
    private GunController gunController;

    private void Start()
    {
        gunController = GameObject.FindGameObjectWithTag("Player").GetComponent<GunController>();
    }
    public void FireRaycast()
    {
        Physics.Raycast(shootFrom.transform.position, transform.forward, out RaycastHit hit);
        if (hit.collider != null)
        {
            if (hit.collider.tag == "Enemy")
            {
                enemyManager = hit.collider.GetComponent<EnemyManager>();
                enemyManager.Shot(gunController.primaryGun.damage);
            }
        }
    }
}
