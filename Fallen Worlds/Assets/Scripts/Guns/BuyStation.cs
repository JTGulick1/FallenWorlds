using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyStation : MonoBehaviour
{
    private GameManager gm;
    [SerializeField]
    private int cost;
    [SerializeField]
    private int reloadCost;
    [SerializeField]
    private Guns weopon;
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other) //if the player is close enough to the wall buy spawn UI
    {
        if (other.gameObject.tag == "Player")
        {
            gm.CloseToBuy(weopon, cost, reloadCost);
        }
    }

    private void OnTriggerExit(Collider other) //if the player is close enough to the wall buy despawn UI
    {
        if (other.gameObject.tag == "Player")
        {
            gm.OutOfBuyRange();
        }
    }
}
