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
    
    void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerFootSteps = GetComponentInChildren<PlayerFootSteps>();
        povTransform = transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        CheckCrouch();
        CheckSprint();
    }

    void CheckSprint()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift) && !isCrouching)
        {
            playerMovement.speed = sprintSpeed;

            playerFootSteps.currentMovement = MovementTypes.Sprinting;
        }
        if(Input.GetKeyUp(KeyCode.LeftShift) && !isCrouching)
        {
            playerMovement.speed = moveSpeed;

            playerFootSteps.currentMovement = MovementTypes.Walking;
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
