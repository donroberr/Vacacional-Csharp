using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class IdleState : State
{
    public State MoveState;
    protected override void EnterState()
    {
        agent.animationManager.PlayAnimation(AnimationType.idle);
    }

    protected override void HandleMovement(Vector2 input)
    {
        print("Input: " + input);
        if (Mathf.Abs(input.x) > 0)
        {
            print("Moving");
            agent.TransitionToState(MoveState);
        }

    }
}
