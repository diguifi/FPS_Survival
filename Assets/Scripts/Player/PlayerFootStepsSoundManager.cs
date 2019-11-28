using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootStepsSoundManager : MonoBehaviour
{
    private AudioSource footstepSound;
    [SerializeField]
    private AudioClip[] footstepClip;
    private CharacterController characterController;
    private float accumulatedDistance;
    [HideInInspector]
    public float volumeMin, volumeMax;
    [HideInInspector]
    public float stepDistance;
    [HideInInspector]
    public MovementTypes currentMovement = MovementTypes.Walking;

    private float sprintVolume = 1f;
    private float walkVolumeMin = 0.2f;
    private float walkVolumeMax = 0.7f;
    private float crouchVolume = 0.1f;
    private float walkStepDistance = 0.4f;

    void Awake()
    {
        footstepSound = GetComponent<AudioSource>();
        characterController = GetComponentInParent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckFootSteps();
    }

    void CheckFootSteps()
    {
        if (!characterController.isGrounded)
            return;

        CheckMovementType();

        if (characterController.velocity.sqrMagnitude > 0)
        {
            accumulatedDistance += Time.deltaTime;

            if (accumulatedDistance > stepDistance)
            {
                footstepSound.volume = Random.Range(volumeMin, volumeMax);
                footstepSound.clip = footstepClip[Random.Range(0, footstepClip.Length)];
                footstepSound.Play();

                accumulatedDistance = 0f;
            }
        }
        else
            accumulatedDistance = 0f;
    }

    void CheckMovementType()
    {
        if (currentMovement == MovementTypes.Walking)
        {
            stepDistance = walkStepDistance;
            volumeMin = walkVolumeMin;
            volumeMax = walkVolumeMax;
        }
        else if (currentMovement == MovementTypes.Sprinting)
        {
            stepDistance = walkStepDistance - 0.1f;
            volumeMin = sprintVolume;
            volumeMax = sprintVolume;
        }
        else if (currentMovement == MovementTypes.Crouching)
        {
            stepDistance = walkStepDistance + 0.15f;
            volumeMin = crouchVolume;
            volumeMax = crouchVolume;
        }
    }
}
