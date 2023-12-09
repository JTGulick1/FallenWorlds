using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager _instance;
    public bool auto;
    public static InputManager Instance
    {
        get
        {
            return _instance;
        }
    }

    private PlayerControls inputActions;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
        inputActions = new PlayerControls();
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }


    public Vector2 GetPlayerMovement()
    {
        return inputActions.MouseKeyboard.Movement.ReadValue<Vector2>();
    }
    public Vector2 GetMouseDelta()
    {
        return inputActions.MouseKeyboard.Look.ReadValue<Vector2>();
    }

    public bool Jumped()
    {
        return inputActions.MouseKeyboard.Jump.triggered;
    }
    public bool Sprinting()
    {
        return inputActions.MouseKeyboard.Sprint.IsPressed();
    }
    public bool Fire()
    {
        if (auto == true)
        {
            return inputActions.MouseKeyboard.FireWeopon.IsPressed();
        }
        return inputActions.MouseKeyboard.FireWeopon.triggered;
    }

    public bool Reload()
    {
        return inputActions.MouseKeyboard.Reload.triggered;
    }

    public bool Interacted()
    {
        return inputActions.MouseKeyboard.Interact.triggered;
    }

    public bool OpenInventory()
    {
        return inputActions.MouseKeyboard.OpenInventory.triggered;
    }

    public bool ADS()
    {
        return inputActions.MouseKeyboard.ADS.IsPressed();
    }

    public bool Cursor()
    {
        return inputActions.MouseKeyboard.LockUnlock.triggered;
    }
}
