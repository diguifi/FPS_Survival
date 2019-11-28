using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBreathSoundManager : MonoBehaviour
{
    private AudioSource breathSound;
    [SerializeField]
    private AudioClip[] breathClip;

    void Awake()
    {
        breathSound = GetComponent<AudioSource>();
    }

    public void RunTired(float sprintValue)
    {
        if (sprintValue > 1f)
                breathSound.volume = 1f - (sprintValue/100f);
        if (!breathSound.isPlaying || breathSound.clip != breathClip[0])
        {
            breathSound.clip = breathClip[0];
            breathSound.Play();
        }
    }
    public void Recover(float sprintValue)
    {
        if (sprintValue > 1f)
                breathSound.volume = 1f - (sprintValue/100f);
        if (!breathSound.isPlaying || breathSound.clip != breathClip[1])
        {
            breathSound.clip = breathClip[1];
            breathSound.Play();
        }
    }
    public void Stop()
    {
        breathSound.Stop();
    }
}
