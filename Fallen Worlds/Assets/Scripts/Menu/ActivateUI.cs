using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateUI : MonoBehaviour
{
    [SerializeField] private GameObject canvus;
    public InputManager inputManager;
    private void Start()
    {
        inputManager = InputManager.Instance;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && inputManager.Interacted() == true)
        {
            TurnOn();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        TurnOff();
    }


    private void TurnOn()
    {
        Cursor.lockState = CursorLockMode.None;
        canvus.SetActive(true);
        return;
    }

    private void TurnOff()
    {
        Cursor.lockState = CursorLockMode.Locked;
        canvus.SetActive(false);
        return;
    }
}
