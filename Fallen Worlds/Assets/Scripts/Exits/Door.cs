using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private GameManager gm;
    [SerializeField]
    int cost;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other){
        if (other.gameObject.tag == "Player"){
            gm.CloseToDoor(this.gameObject, cost);
        }
    }

    private void OnTriggerExit(Collider other){
        if (other.gameObject.tag == "Player"){
            gm.OutOfDoorRange();
        }
    }


}