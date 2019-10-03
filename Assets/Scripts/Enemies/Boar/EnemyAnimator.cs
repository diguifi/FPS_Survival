using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Walk(bool walk)
    {
        animator.SetBool(AnimationTags.WALK_STATE, walk);
    }

    public void Run(bool run)
    {
        animator.SetBool(AnimationTags.RUN_STATE, run);
    }

    public void Attack()
    {
        animator.SetTrigger(AnimationTags.ATTACK_STATE);
    }

    public void Dead()
    {
        animator.SetTrigger(AnimationTags.DEAD_STATE);
    }
}
