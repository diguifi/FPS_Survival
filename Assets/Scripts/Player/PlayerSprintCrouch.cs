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

    private PlayerFootSteps playerFootSteps;

    private PlayerStats playerStats;
    private float sprintValue = 100f;
    public float sprintTreshold = 15f;
    
    void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerFootSteps = GetComponentInChildren<PlayerFootSteps>();
        povTransform = transform.GetChild(0);
        playerStats = GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckCrouch();
        CheckSprint();
    }

    void CheckSprint()
    {
        if (sprintValue > 0)
        {
            if(Input.GetKeyDown(KeyCode.LeftShift) && !isCrouching)
            {
                playerMovement.speed = sprintSpeed;

                playerFootSteps.currentMovement = MovementTypes.Sprinting;
            }
        }
        if(Input.GetKeyUp(KeyCode.LeftShift) && !isCrouching)
        {
            playerMovement.speed = moveSpeed;

            playerFootSteps.currentMovement = MovementTypes.Walking;
        }

        if(Input.GetKey(KeyCode.LeftShift) && !isCrouching)
        {
            
            sprintValue -= Time.deltaTime * sprintTreshold;
            if (sprintValue < 0f)
            {
                sprintValue = 0f;
                playerMovement.speed = moveSpeed;
                playerFootSteps.currentMovement = MovementTypes.Walking;
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

            playerFootSteps.currentMovement = MovementTypes.Crouching;
        }
        if(Input.GetKeyUp(KeyCode.LeftControl))
        {
            isCrouching = false;
            playerMovement.speed = moveSpeed;
            povTransform.localPosition = new Vector3(0f, standHeight, 0f);

            playerFootSteps.currentMovement = MovementTypes.Walking;
        }
    }
}
