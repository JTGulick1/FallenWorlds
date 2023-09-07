using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slam : MonoBehaviour
{
    private float timer;
    private float slamMax;
    private void Update()
    {
        if (gameObject.activeInHierarchy)
        {
            timer += Time.deltaTime;
            if (slamMax <= timer)
            {
                timer = 0;
                //this.gameObject.SetActive(false);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerController>().playersHealth -= 15;
            //this.gameObject.SetActive(false);
        }
    }
}
