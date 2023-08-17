using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManager : MonoBehaviour
{
    [SerializeField]
    private float health = 50f;
    [SerializeField]
    private int points = 50;
    private GameManager gm;
    private PlayerController target;
    private NavMeshAgent meshAgent;
    public GameObject item;
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        meshAgent = GetComponent<NavMeshAgent>();
        health += gm.GetWaveNumber();
        meshAgent.speed = (gm.GetWaveNumber() / 2) + 2.5f;
        if (meshAgent.speed <= 3.5f)
            meshAgent.speed = 3.5f;
        if (meshAgent.speed >= 16f)
            meshAgent.speed = 16f;
    }

    void Update()
    {
        if (health <= 0)
        {
            int spawnitem = Random.Range(0, 100);
            if (spawnitem == 69)
            {
                SpawnItem();
            }
            gm.enemysOnFeild--;
            gm.AddPoints(points);
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            health -= collision.gameObject.GetComponent<Bullet>().damage;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            target.timer = 0.0f;
            target.playersHealth -= 10.0f;
        }
    }

    private void SpawnItem()
    {
        SetItem spawnedItem;
        GameObject newItem = Instantiate(item, this.transform.position, this.transform.rotation);
        spawnedItem = newItem.GetComponent<SetItem>();
        spawnedItem.item = gm.GetRandomItem();
    }
}
