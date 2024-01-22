using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Transform teleportLocation;
    public float rechargeTimer;
    public float currentTime;
    public GameObject cube;
    public GameObject cPlayer;

    public void Start()
    {
        currentTime = rechargeTimer;
        cPlayer = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        if (currentTime <= rechargeTimer)
        {
            currentTime += Time.deltaTime;
        }
        if (currentTime >= rechargeTimer)
        {
            cube.SetActive(true);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && currentTime >= rechargeTimer)
        {
            cube.SetActive(false);
            currentTime = 0.0f;
            Teleport();
        }
    }

    public void Teleport()
    {
        cPlayer.SetActive(false);
        cPlayer.transform.position = teleportLocation.position;
        cPlayer.SetActive(true);
    }
}
