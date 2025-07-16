using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Agent : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public PlayerInput agentInput;
    public AgentAnimation animationManager;
    public AgentRenderer agentRenderer;

    public State currentState = null, previousState = null;
    public State IdleState;

    [Header("State debugging:")]
    public string stateName = "";


    private void Awake()
    {
        agentInput = GetComponentInParent<PlayerInput>();
        rb2d = GetComponent<Rigidbody2D>();
        animationManager = GetComponentInChildren<AgentAnimation>();
        agentRenderer = GetComponentInChildren<AgentRenderer>();
        State[] states = GetComponentsInChildren<State>();
        foreach (var state in states)
        {
            state.InitializeState(this);
        }
    }

    private void Start()
    {
        agentInput.OnMovement += agentRenderer.FaceDirection;
        TransitionToState(IdleState);
    }


    public void TransitionToState(State desiredState)
    {
        Debug.Log(desiredState);

        if (desiredState == null)
        {
            Debug.LogError("Desired state is null");
            return;
        }
        if (currentState != null)
        {
            currentState.Exit();

        }

        previousState = currentState;

        currentState = desiredState;
        Debug.Log(currentState);
        Debug.Log(previousState);
        Debug.Log(desiredState);

        currentState.Enter();

        DisplayState();
    }

    private void DisplayState()
    {
        if (previousState == null || previousState.GetType() != currentState.GetType())
        {
            stateName = currentState.GetType().ToString();
        }
    }

    private void Update()
    {
        currentState.StateUpdate();
    }
    private void FixedUpdate()
    {
        currentState.StateFixUpdate();
    }
}
