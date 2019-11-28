using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSprintCrouch : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private Transform povTransform;
    private float standHeight = 1.6f;
    private float crouchHeight = 1f;
    private bool isCrouching = false;

    public float moveSpeed = 4f;
    public float sprintSpeed = 8f;
    public float crouchSpeed = 1.5f;

    private PlayerSoundManager playerSoundManager;

    private PlayerStats playerStats;
    private float sprintValue = 100f;
    public float sprintTreshold = 15f;

    private bool isMoving = false;
    private Vector3 current, lastPos;
    
    void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerSoundManager = GetComponentInChildren<PlayerSoundManager>();
        Debug.Log(playerSoundManager.footStepsSoundManager);
        povTransform = transform.GetChild(0);
        playerStats = GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckMovement();
        CheckCrouch();
        CheckSprint();
    }

    void CheckMovement()
    {
        var velocity = ((transform.position - lastPos).magnitude) / Time.deltaTime;
        lastPos = transform.position;
        if (velocity > 0f)
            isMoving = true;
        else
            isMoving = false;
    }

    void CheckSprint()
    {
        if (sprintValue > 0)
        {
            if(Input.GetKeyDown(KeyCode.LeftShift) && !isCrouching)
            {
                playerMovement.speed = sprintSpeed;
                playerSoundManager.footStepsSoundManager.currentMovement = MovementTypes.Sprinting;
                if(Input.GetAxis(Axis.VERTICAL) < 0)
                {
                    playerMovement.speed = sprintSpeed/1.4f;
                }
                
            }
        }
        if(Input.GetKeyUp(KeyCode.LeftShift) && !isCrouching)
        {
            playerMovement.speed = moveSpeed;
            playerSoundManager.footStepsSoundManager.currentMovement = MovementTypes.Walking;
        }

        if(Input.GetKey(KeyCode.LeftShift) && !isCrouching && isMoving)
        {
            sprintValue -= Time.deltaTime * sprintTreshold;
            if (sprintValue < 0f)
            {
                sprintValue = 0f;
                playerMovement.speed = moveSpeed;
                playerSoundManager.footStepsSoundManager.currentMovement = MovementTypes.Walking;
            }
            playerStats.DisplayStaminaStats(sprintValue);
        }
        else
        {
            if (sprintValue != 100f)
            {
                sprintValue += (sprintTreshold / 2) * Time.deltaTime;
                playerStats.DisplayStaminaStats(sprintValue);

                if (sprintValue > 100f)
                {
                    sprintValue = 100f;
                }
            }
        }
    }

    void CheckCrouch()
    {
        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            isCrouching = true;
            playerMovement.speed = crouchSpeed;
            povTransform.localPosition = new Vector3(0f, crouchHeight, 0f);

            playerSoundManager.footStepsSoundManager.currentMovement = MovementTypes.Crouching;
        }
        if(Input.GetKeyUp(KeyCode.LeftControl))
        {
            isCrouching = false;
            playerMovement.speed = moveSpeed;
            povTransform.localPosition = new Vector3(0f, standHeight, 0f);

            playerSoundManager.footStepsSoundManager.currentMovement = MovementTypes.Walking;
        }
    }
}
