using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private GameManager gm;
    [SerializeField]
    public int cost;
    public bool shards = false;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other){ //if the player is close enough to the door spawn UI
        if (other.gameObject.tag == "Player"){
            gm.CloseToDoor(this.gameObject, cost, shards);
        }
    }

    private void OnTriggerExit(Collider other) { //if the player is close enough to the door despawn UI
        if (other.gameObject.tag == "Player"){
            gm.OutOfDoorRange();
        }
    }


}