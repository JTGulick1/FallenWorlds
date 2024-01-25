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
    public NavMeshAgent meshAgent;
    public GameObject item;
    private float attackTimer;
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        meshAgent = GetComponent<NavMeshAgent>();
        health += gm.GetWaveNumber();
        meshAgent.speed = (gm.GetWaveNumber() / 2) + 2.5f; //Ajust the enemy speed based off the waves
        if (meshAgent.speed <= 3.5f)
            meshAgent.speed = 3.5f;
        if (meshAgent.speed >= 16f)
            meshAgent.speed = 16f;
    }

    void Update()
    {
        if (attackTimer < 3.0f)
        {
            attackTimer += Time.deltaTime;
        }
        if (health <= 0) // Check if its dead
        {
            gm.GiveEXP(5);
            int spawnitem = Random.Range(0, 100);
            if (spawnitem == 38) // Spawn a Item
            {
                SpawnItem();
            }
            gm.enemysOnFeild--;
            gm.AddPoints(points);
            if (gm.leftOver > 0)
            {
                gm.SpawnLeftOvers();
            }
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter(Collider other) //Attacking player
    {
        if (other.gameObject.tag == "Player" && attackTimer >= 3.0f)
        {
            target.timer = 0.0f;
            attackTimer = 0.0f;
            target.playersHealth -= 10.0f;
        }
    }

    public void Shot(float damage)
    {
        health -= damage;
    }

    private void SpawnItem() // If the enemy drops and item
    {
        SetItem spawnedItem;
        GameObject newItem = Instantiate(item, this.transform.position, this.transform.rotation);
        spawnedItem = newItem.GetComponent<SetItem>();
        spawnedItem.item = gm.GetRandomItem();
    }
}
