using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jav : MonoBehaviour
{
    [SerializeField]
    private float speed = 10.0f;
    public float damage = 15.0f;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Destroy(gameObject, 5);
    }

    void Update()
    {
        rb.AddForce(transform.forward * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerController>().playersHealth -= 15;
            Destroy(gameObject);
        }
    }
}
