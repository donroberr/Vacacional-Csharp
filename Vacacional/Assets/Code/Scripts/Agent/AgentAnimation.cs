using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentAnimation : MonoBehaviour
{
    private Animator animator;

    private void Awake() 
    {
        animator = GetComponent<Animator>();

    }

    public void PlayAnimation(AnimationType animationType)
    {
        switch(animationType)
        {
            case AnimationType.die:
                Play("Die");
                break;
            case AnimationType.hit:
                Play("Hit");
                break;
            case AnimationType.idle:
                Play("Idle");
                break;
            case AnimationType.attack:
                Play("Attack");
                break;
            case AnimationType.run:
                Play("Run");
                break;
            case AnimationType.jump:
                Play("Jump");
                break;
            case AnimationType.fall:
                Play("Fall");
                break;
            case AnimationType.climb:
                Play("Climb");
                break;
            case AnimationType.land:
                Play("Land");
                break;
        }
        
    }

    public void Play(string name)
    {
        animator.Play(name, -1, 0f);
    }
}

public enum AnimationType
{
    die,
    hit,
    idle,
    attack,
    run,
    jump,
    fall,
    climb,
    land
}