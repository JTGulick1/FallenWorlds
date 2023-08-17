using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float speed = 50.0f;
    public float damage;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Destroy(this.gameObject, 5.0f);
    }

    void Update()
    {
        rb.AddForce(transform.forward * speed);
    }

    public void SetDamage(float dam)
    {
        damage = dam;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
    }
}
