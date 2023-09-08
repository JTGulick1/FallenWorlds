using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthTotom : MonoBehaviour
{
    private float timer = 0.0f;
    private float sendregen = 10.0f;
    PlayerController playerController;
    public BoxCollider box;
    public GameObject lig;

    void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= sendregen)
        {
            Regen();
        }
    }

    private void Regen()
    {
        lig.SetActive(true);
        box.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        timer = 0.0f;
        playerController.playersHealth += 30.0f;
        box.isTrigger = false;
        lig.SetActive(false);
    }
}
