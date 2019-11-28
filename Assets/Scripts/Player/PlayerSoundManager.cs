using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundManager : MonoBehaviour
{
    public PlayerDamageSoundManager damageSoundManager;
    public PlayerFootStepsSoundManager footStepsSoundManager;
    public PlayerBreathSoundManager breathSoundManager;

    void Awake()
    {
        damageSoundManager = GetComponentInChildren<PlayerDamageSoundManager>();
        footStepsSoundManager = GetComponentInChildren<PlayerFootStepsSoundManager>();
        breathSoundManager = GetComponentInChildren<PlayerBreathSoundManager>();
    }
}
