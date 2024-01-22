using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaTeleport : MonoBehaviour
{
    public Transform teleportLocation;
    public float teleportTime;
    public float currentTime;
    public GameObject cPlayer;
    private bool isHere;

    public void Start()
    {
        cPlayer = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        if (isHere == true)
        {
            currentTime += Time.deltaTime;
        }
        if (currentTime >= teleportTime)
        {
            currentTime = 0.0f;
            Teleport();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            currentTime = 0.0f;
            isHere = true;
        }
    }
    public void Teleport()
    {
        cPlayer.SetActive(false);
        cPlayer.transform.position = teleportLocation.position;
        cPlayer.SetActive(true);
        isHere = false;
    }
}
