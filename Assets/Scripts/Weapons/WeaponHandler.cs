using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponBulletType
{
    NONE,
    BULLET
}

public enum WeaponAimType
{
    NONE,
    AIM
}

public class WeaponHandler : MonoBehaviour
{
    private Animator animator;
    [SerializeField]
    private GameObject muzzleFlash;
    [SerializeField]
    private AudioSource shootSound, reloadSound;
    public WeaponBulletType bulletType;
    public WeaponAimType aimType;
    public GameObject attackPoint;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public bool ShootAnimationIsPlaying()
    {
        return animator.GetCurrentAnimatorStateInfo(0).IsName(AnimationTags.ATTACK_STATE);
    }
    
    public void ShootAnimation()
    {
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName(AnimationTags.ATTACK_STATE))
            animator.SetTrigger(AnimationTags.SHOOT_TRIGGER);
    }

    public void TurnOnMuzzleFlash()
    {
        muzzleFlash.SetActive(true);
    }

    public void TurnOffMuzzleFlash()
    {
        muzzleFlash.SetActive(false);
    }

    public void PlayShootSound()
    {
        shootSound.Play();
    }

    public void PlayReloadSound()
    {
        reloadSound.Play();
    }

    public void TurnOnAttackPoint()
    {
        attackPoint.SetActive(true);
    }

    public void TurnOffAttackPoint()
    {
        if (attackPoint.activeInHierarchy)
            attackPoint.SetActive(false);
    }
}
