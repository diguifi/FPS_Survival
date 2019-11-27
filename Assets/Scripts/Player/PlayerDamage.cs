using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    private AudioSource damageSound;
    [SerializeField]
    private AudioClip[] damageClip;

    void Awake()
    {
        damageSound = GetComponent<AudioSource>();
    }

    public void TakeDamage()
    {
        damageSound.volume = Random.Range(0.2f, 0.4f);
        damageSound.clip = damageClip[Random.Range(0, damageClip.Length)];
        damageSound.Play();
    }
}
