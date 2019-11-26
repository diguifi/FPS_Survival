using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController characterController;
    private Health healthManager;
    private Vector3 moveDirection;
    private float verticalVelocity;
    private float gravity = 20f;
    private float timeFalling = 0f;
    public float speed = 4f;
    public float jumpForce = 10f;

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
        healthManager = GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckFallDamage();
    }

    void Move()
    {
        moveDirection = new Vector3(Input.GetAxis(Axis.HORIZONTAL), 0f, Input.GetAxis(Axis.VERTICAL));
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= speed * Time.deltaTime;

        ApplyGravity();

        characterController.Move(moveDirection);
    }

    void ApplyGravity()
    {
        verticalVelocity -= gravity * Time.deltaTime;
        Jump();
        moveDirection.y = verticalVelocity * Time.deltaTime;
    }

    void Jump()
    {
        if (characterController.isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            verticalVelocity = jumpForce;
        }
    }

    void CheckFallDamage()
    {
        if (!characterController.isGrounded)
        {
            timeFalling += Time.deltaTime;
        }
        else
        {
            if (timeFalling > 1.3f)
                healthManager.DealDamage((timeFalling * timeFalling) * 2);
            timeFalling = 0f;
        }
    }
}
