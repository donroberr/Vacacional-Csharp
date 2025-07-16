using System;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    [field: SerializeField] 
    public Vector2 MovementVector { get; private set; }
    public event Action OnAttack, OnJumpPressed, OnJumpReleased, OnWeaponChange;
    public event Action<Vector2> OnMovement;
    public KeyCode jumpKey, attackKey, menuKey;
    public UnityEvent OnMenuKeyPressed;

    private void Update()
    {
        if(Time.timeScale > 0)
        {
            GetMovementInput();
            GetJumpInput();
            GetAttackInput();
            GetWeapomSwapInput();
        }


        GetManuInput();

    }

    private void GetManuInput()
    {
        if(Input.GetKeyDown(menuKey))
        {
            OnMenuKeyPressed?.Invoke();
        }
    }

    private void GetWeapomSwapInput()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            OnWeaponChange?.Invoke();
        }
    }

    private void GetAttackInput()
    {
        if(Input.GetKeyDown(attackKey))
        {
            OnAttack?.Invoke();
        }
    }

    private void GetJumpInput()
    {
        if(Input.GetKeyDown(jumpKey))
        {
            OnJumpPressed?.Invoke();
        }
        if(Input.GetKeyUp(jumpKey))
        {
            OnJumpReleased?.Invoke();
        }
    }

    private void GetMovementInput()
    {
        MovementVector = GetMovementVector();
        OnMovement?.Invoke(MovementVector);
        
    }

    private Vector2 GetMovementVector()
    {
        return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }
}
