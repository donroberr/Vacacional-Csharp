using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class State : MonoBehaviour
{
    protected Agent agent;

    public UnityEvent OnEnter, OnExit;

    public void InitializeState(Agent agent)
    {
        this.agent = agent;
    }

    public void Enter()
    {
        this.agent.agentInput.OnAttack += HandleAttack;
        this.agent.agentInput.OnJumpPressed += HandleJumpPressed;
        this.agent.agentInput.OnJumpPressed += HandleJumpReleased;
        this.agent.agentInput.OnMovement += HandleMovement;
        OnEnter?.Invoke();
        EnterState();
    }

    protected virtual void EnterState()
    {   
    }

    protected virtual void HandleMovement(Vector2 vector)
    {
    }

    protected virtual void HandleJumpReleased()
    {
    }

    protected virtual void HandleJumpPressed()
    {
    }

    protected virtual void HandleAttack()
    {
    }

    public virtual void StateUpdate()
    {
    }
    public virtual void StateFixUpdate()
    {
    }

    public void Exit()
    {
        this.agent.agentInput.OnAttack -= HandleAttack;
        this.agent.agentInput.OnJumpPressed -= HandleJumpPressed;
        this.agent.agentInput.OnJumpReleased -= HandleJumpReleased;
        this.agent.agentInput.OnMovement -= HandleMovement;
        OnExit?.Invoke();
        ExitState();
    }

    protected virtual void ExitState()
    {
    }
}
