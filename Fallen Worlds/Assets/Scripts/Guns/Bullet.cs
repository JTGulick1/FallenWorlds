using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float speed = 100.0f;
    public float damage;
    private Rigidbody rb;
    public float falloff;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Destroy(this.gameObject, falloff);
    }

    void Update()
    {
        rb.AddForce(transform.forward * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
    }
}
