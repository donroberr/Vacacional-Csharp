using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    public Collider2D agentCollider;
    public LayerMask groundMask;

    public bool isGrounded = false;

    [Header("Gizmos Parameters: ")]
    [Range(-2f, 2f)]
    public float boxCastYOffset = -0.1f;
    [Range(-2f, 2f)]
    public float boxCastXOffset = -0.1f;
    
}
