using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetItem : MonoBehaviour
{
    public Item item;
    private Backpack backpack;

    private void Start()
    {
        backpack = GameObject.FindGameObjectWithTag("Player").GetComponent<Backpack>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            backpack.AddItem(item);
            Destroy(this.gameObject);
        }
    }
}
