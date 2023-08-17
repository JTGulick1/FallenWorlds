using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharacterController))]
public class PlayerController: MonoBehaviour
{
    [SerializeField]
    private float playerSpeed = 6.0f;
    [SerializeField]
    private float jumpHeight = 1.0f;
    [SerializeField]
    private float gravityValue = -9.81f;
    
    private float playerBaseSpeed = 6.0f;

    public float playersHealth = 30.0f;

    public float regenTime = 7.0f;
    public float timer = 0.0f;

    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private InputManager inputManager;
    private Transform camTransform;
    private GameManager gameManager;


    private void Start()
    {
        controller = GetComponent<CharacterController>();
        inputManager = InputManager.Instance;
        camTransform = Camera.main.transform;
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    void Update()
    {
        if (playersHealth <= 0.0f)
        {
            gameManager.KillPlayer();
        }

        if (playersHealth != 30.0f)
        {
            timer += Time.deltaTime;
            if (timer >= regenTime){
                playersHealth += 0.1f;
                if (playersHealth >= 30.0f){
                    playersHealth = 30.0f;
                }
            }
        }

        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0){
            playerVelocity.y = 0f;
        }

        Vector2 movement = inputManager.GetPlayerMovement();
        Vector3 move = new Vector3(movement.x, 0f, movement.y);
        move = camTransform.forward * move.z + camTransform.right * move.x;
        move.y = 0f;
        controller.Move(move * Time.deltaTime * playerSpeed);

        // Changes the height position of the player..
        if (inputManager.Jumped() && groundedPlayer){
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        if (inputManager.Sprinting() == true){
            playerSpeed = 12.0f;
        }else{
            playerSpeed = playerBaseSpeed;
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}