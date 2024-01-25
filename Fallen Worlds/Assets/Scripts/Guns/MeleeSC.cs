using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeSC : MonoBehaviour
{
    public EnemyManager stabbedEnemy;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            stabbedEnemy = other.GetComponent<EnemyManager>();
            stabbedEnemy.Shot(100);
        }
    }
}
