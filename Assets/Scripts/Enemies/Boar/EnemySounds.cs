using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySounds : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip noiseClip, dieClip;
    [SerializeField]
    private AudioClip[] attackClips; 


    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayNoiseSound()
    {
        audioSource.clip = noiseClip;
        audioSource.Play();
    }

    public void PlayAttackSound()
    {
        audioSource.clip = attackClips[Random.Range(0, attackClips.Length)];
        audioSource.Play();
    }

    public void PlayDieSound()
    {
        audioSource.clip = dieClip;
        audioSource.Play();
    }
}
