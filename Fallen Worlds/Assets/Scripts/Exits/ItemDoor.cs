using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDoor : MonoBehaviour
{
    private GameManager gm;
    [SerializeField]
    Item requiredItem;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other) //if the player is close enough to the door spawn UI
    {
        if (other.gameObject.tag == "Player")
        {
            gm.CloseToItemDoor(this.gameObject, requiredItem);
        }
    }

    private void OnTriggerExit(Collider other) //if the player is close enough to the door despawn UI
    {
        if (other.gameObject.tag == "Player")
        {
            gm.OutOfDoorRange();
        }
    }
}
