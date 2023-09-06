using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    private float timer = 0.0f;
    private float nextSpawn = 3.0f;
    public int totalToSpawn = 0;
    private GameObject type;
    private void Update()
    {
        timer += Time.deltaTime;
        if (totalToSpawn != 0)
        {
            if (timer >= nextSpawn)
            {
                Instantiate(type, this.transform.position, this.transform.rotation);
                timer = 0.0f;
                totalToSpawn--;
            }
        }
    }
    public void Spawn(GameObject enemy)
    {
        totalToSpawn++;
        type = enemy;
    }
}
