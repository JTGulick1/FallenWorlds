using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedTotom : MonoBehaviour
{
    PlayerController playerController;

    void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerController.ChangeSpeed(10, 18);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerController.ChangeSpeed(6, 12);
        }
    }
}
