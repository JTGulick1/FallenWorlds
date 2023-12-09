using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharacterController))]
public class PlayerController: MonoBehaviour
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
    
    private float playerBaseSpeed = 6.0f;
    private float sprintingSpeed = 12.0f;

    public float playersHealth = 30.0f;

    public float regenTime = 7.0f;
    public float timer = 0.0f;

    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private InputManager inputManager;
    private Transform camTransform;
    private GameManager gameManager;
    private PlayerInfoManager playerInfoManager;
    public GameObject cBrain;
    public GameObject inventory;
    private bool curBool = true;
    private GunController GC;

    private void Start()
    {
        playerInfoManager = PlayerInfoManager.Instance;
        controller = GetComponent<CharacterController>();
        inputManager = InputManager.Instance;
        camTransform = Camera.main.transform;
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        GC = GetComponent<GunController>();
        inventory = GameObject.FindGameObjectWithTag("inGameInv");
        inventory.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (playersHealth <= 0.0f)
        {
            gameManager.KillPlayer();
        }

        if (playersHealth != 30.0f) // alert player of low health
        {
            gameManager.HealedUp();
            timer += Time.deltaTime;
            if (timer >= regenTime - ((playerInfoManager.deskLevel - 1) / 4)){
                playersHealth += 0.1f;
                if (playersHealth >= 30.0f){
                    playersHealth = 30.0f;
                }
            }
        }

        if (playersHealth <= 11.0f)
        {
            gameManager.Dying();
        }

        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0){
            playerVelocity.y = 0f;
        }

        Vector2 movement = inputManager.GetPlayerMovement();
        Vector3 move = new Vector3(movement.x, 0f, movement.y);
        move = camTransform.forward * move.z + camTransform.right * move.x;
        move.y = 0f;
        controller.Move(move * Time.deltaTime * (playerSpeed + ((playerInfoManager.fileLevel - 1) / 4)));

        // Changes the height position of the player..
        if (inputManager.Jumped() && groundedPlayer){
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        if (inputManager.Sprinting() == true){
            playerSpeed = sprintingSpeed;
        }else{
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

        if (inputManager.Cursor())
        {
            LockC();
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
}