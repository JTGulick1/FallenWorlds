using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Unity.Netcode;


[RequireComponent(typeof(CharacterController))]
public class PlayerController: NetworkBehaviour
{
    //Simple movement script

    [SerializeField]
    private float playerSpeed = 6.0f;
    [SerializeField]
    private float jumpHeight = 1.0f;
    [SerializeField]
    private float gravityValue = -9.81f;
    private float gravityDamage = 0f;
    private float offGroundTimer = 0f;
    public PlayerInput playerInput = null;

    private float playerBaseSpeed = 6.0f;
    private float sprintingSpeed = 12.0f;

    public float playersHealth = 30.0f;

    public float regenTime = 7.0f;
    public float timer = 0.0f;

    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    public InputManager inputManager;
    private Transform camTransform;
    private GameManager gameManager;
    private PlayerInfoManager playerInfoManager;
    public GameObject cBrain;
    private GameObject inventory;
    private GameObject settings;
    private GameObject remap;
    private bool curBool = true;
    private GunController GC;
    public GameObject meleeBall;
    public float meleeReset = 0.0f;
    public PlayerInput PlayerInput => playerInput;

    private void Start()
    {
        playerInfoManager = PlayerInfoManager.Instance;
        controller = GetComponent<CharacterController>();
        inputManager = InputManager.Instance;
        camTransform = Camera.main.transform;
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        GC = GetComponent<GunController>();
        inventory = GameObject.FindGameObjectWithTag("inGameInv");
        settings = GameObject.FindGameObjectWithTag("inGameSett");
        remap = GameObject.FindGameObjectWithTag("remapCan");
        inventory.SetActive(false);
        settings.SetActive(false);
        remap.SetActive(false);
        meleeBall.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        playerInput = GetComponent<PlayerInput>();
    }

    void Update()
    {
        if (!IsOwner)
        {
            if (playersHealth <= 0.0f)
            {
                gameManager.KillPlayer();
            }

            if (playersHealth != 30.0f) // alert player of low health
            {
                gameManager.HealedUp();
                timer += Time.deltaTime;
                if (timer >= regenTime - ((playerInfoManager.deskLevel - 1) / 4))
                {
                    playersHealth += 0.1f;
                    if (playersHealth >= 30.0f)
                    {
                        playersHealth = 30.0f;
                    }
                }
            }

            if (playersHealth <= 11.0f)
            {
                gameManager.Dying();
            }

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
                    GC.StopFire();
                    cBrain.SetActive(true);
                    inventory.SetActive(false);
                    return;
                }
                if (inventory.activeSelf == false)
                {
                    LockC();
                    GC.StopFire();
                    cBrain.SetActive(false);
                    inventory.SetActive(true);
                    return;
                }
            }

            if (meleeReset <= 1.0f)
            {
                meleeReset += Time.deltaTime;
            }
            if (meleeReset >= 0.1f && meleeBall.activeSelf)
            {
                meleeBall.SetActive(false);
            }
            if (inputManager.Melee() == true && meleeReset >= 1.0f)
            {
                Melee();
            }

            if (inputManager.SettingsMenu() == true)
            {
                SettMenu();
            }

            if (groundedPlayer != true) // Fall Damage
            {
                offGroundTimer += Time.deltaTime;
                if (offGroundTimer > 0.75f)
                {
                    gravityDamage = offGroundTimer * 10.0f;
                }
            }

            if (groundedPlayer == true) // Fall Damage Cont:
            {
                offGroundTimer = 0.0f;
                if (gravityDamage >= 1)
                {
                    playersHealth -= gravityDamage;
                    gravityDamage = 0.0f;
                }
            }

            playerVelocity.y += (gravityValue * Time.deltaTime) * 2;
            controller.Move(playerVelocity * Time.deltaTime);
        }
    }

    public void Melee()
    {
        //Melee Sound
        //Melee Animation
        meleeBall.SetActive(true);
        meleeReset = 0.0f;
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
            GC.StopFire();
            cBrain.SetActive(true);
            settings.SetActive(false);
            return;
        }
        if (settings.activeSelf == false)
        {
            LockC();
            GC.StopFire();
            cBrain.SetActive(false);
            settings.SetActive(true);
            return;
        }
    }
}