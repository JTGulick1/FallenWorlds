using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Unity.Netcode;


[RequireComponent(typeof(CharacterController))]
public class PlayerControllerMenu: NetworkBehaviour
{
    //Simple movement script

    [SerializeField]
    private float playerSpeed = 6.0f;
    [SerializeField]
    private float jumpHeight = 1.0f;
    [SerializeField]
    private float gravityValue = -9.81f;
    public PlayerInput playerInput = null;

    private float playerBaseSpeed = 6.0f;
    private float sprintingSpeed = 12.0f;

    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    public InputManager inputManager;
    private Transform camTransform;
    private PlayerInfoManager playerInfoManager;
    public GameObject cBrain;
    private GameObject inventory;
    private GameObject settings;
    private GameObject remap;
    private bool curBool = true;
    public PlayerInput PlayerInput => playerInput;

    private void Start()
    {
        playerInfoManager = PlayerInfoManager.Instance;
        controller = GetComponent<CharacterController>();
        inputManager = InputManager.Instance;
        camTransform = Camera.main.transform;
        inventory = GameObject.FindGameObjectWithTag("inGameInv");
        settings = GameObject.FindGameObjectWithTag("inGameSett");
        remap = GameObject.FindGameObjectWithTag("remapCan");
        inventory.SetActive(false);
        settings.SetActive(false);
        remap.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        playerInput = GetComponent<PlayerInput>();
    }

    void Update()
    {
        if (!IsOwner)
        {
            groundedPlayer = controller.isGrounded;
            if (groundedPlayer && playerVelocity.y < 0)
            {
                playerVelocity.y = 0f;
            }

            Vector2 movement = inputManager.GetPlayerMovement();
            Vector3 move = new Vector3(movement.x, 0f, movement.y);
            move = camTransform.forward * move.z + camTransform.right * move.x;
            move.y = 0f;
            controller.Move(move * Time.deltaTime * (playerSpeed + ((playerInfoManager.fileLevel - 1) / 4)));

            // Changes the height position of the player..
            if (inputManager.Jumped() && groundedPlayer)
            {
                playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            }

            if (inputManager.Sprinting() == true)
            {
                playerSpeed = sprintingSpeed;
            }
            else
            {
                playerSpeed = playerBaseSpeed;
            }
            if (inputManager.OpenInventory() == true) // Open inventory if the player pressed tab
            {
                if (inventory.activeSelf == true)
                {
                    LockC();
                    cBrain.SetActive(true);
                    inventory.SetActive(false);
                    return;
                }
                if (inventory.activeSelf == false)
                {
                    LockC();
                    cBrain.SetActive(false);
                    inventory.SetActive(true);
                    return;
                }
            }


            if (inputManager.SettingsMenu() == true)
            {
                SettMenu();
            }


            playerVelocity.y += (gravityValue * Time.deltaTime) * 2;
            controller.Move(playerVelocity * Time.deltaTime);
        }
        
    }


    public void LockC(){
        if (curBool == true)
        {
            Cursor.lockState = CursorLockMode.None;
            curBool = false;
            return;
        }
        if (curBool == false)
        {
            Cursor.lockState = CursorLockMode.Locked;
            curBool = true;
            return;
        }
    }

    public void ChangeSpeed(int speed, int Sprinting)
    {
        playerSpeed = speed;
        playerBaseSpeed = speed;
        sprintingSpeed = Sprinting;
    }

    public void SettMenu()
    {
        if (settings.activeSelf == true)
        {
            LockC();
            cBrain.SetActive(true);
            settings.SetActive(false);
            return;
        }
        if (settings.activeSelf == false)
        {
            LockC();
            cBrain.SetActive(false);
            settings.SetActive(true);
            return;
        }
    }
}