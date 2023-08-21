using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    private GameManager gm;
    [SerializeField]
    int cost;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other) //if the player is close enough to the portal spawn UI
    {
        if (other.gameObject.tag == "Player")
        {
            gm.CloseToPortal(cost);
        }
    }

    private void OnTriggerExit(Collider other) //if the player is close enough to the portal despawn UI
    {
        if (other.gameObject.tag == "Player")
        {
            gm.OutOfPortalRange();
        }
    }
}
