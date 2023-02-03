using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    private PlayerActions actionMap;

    public UnityEvent OnJumpDown;
    public UnityEvent OnAttackDown;
    public UnityEvent OnInteractDown;
    public UnityEvent OnInteractUp;
    public UnityEvent OnStepDownDown;


    private void Start()
    {
        actionMap = new PlayerActions();
        actionMap.Enable();

        actionMap.BasicActions.Jump.started += InvokeOnJumpDown;
        actionMap.BasicActions.Attack.started += InvokeOnAttackDown;
        actionMap.BasicActions.Interact.started += InvokeOnInteractDown;
        actionMap.BasicActions.Interact.canceled += InvokeOnInteractUp;
        actionMap.BasicActions.MoveDown.started += InvokeOnStepDownDown;
    }
    public void InvokeOnStepDownDown(InputAction.CallbackContext obj)
    {
        OnStepDownDown?.Invoke();
    }
    public void InvokeOnJumpDown(InputAction.CallbackContext obj)
    {
        OnJumpDown?.Invoke();
    }
    public void InvokeOnInteractDown(InputAction.CallbackContext obj)
    {
        OnInteractDown?.Invoke();
    }
    public void InvokeOnInteractUp(InputAction.CallbackContext obj)
    {
        OnInteractUp?.Invoke();
    }

    public void InvokeOnAttackDown(InputAction.CallbackContext obj)
    {
        OnAttackDown?.Invoke();
    }
    public Vector2 GetMoveDirection()
    {
        return actionMap.BasicActions.Movement.ReadValue<Vector2>();
    }
}
