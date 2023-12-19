using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class UnitInputController : CharacterController
{
    private Camera _camera;
    private void Awake()
    {
        _camera = Camera.main;
    }

    public void OnMove(InputValue value)
    {
        // Debug.Log("OnMove" + value.ToString());
        Vector2 moveInput = value.Get<Vector2>().normalized;
        CallMoveEvent(moveInput);
    }

    public void OnLook(InputValue value)
    {
        // Debug.Log("OnLook" + value.ToString());
        Vector2 newAim = value.Get<Vector2>();
        Vector2 worldPos = _camera.ScreenToWorldPoint(newAim);
        newAim = (worldPos - (Vector2)transform.position).normalized;

        if (newAim.magnitude >= .9f)
        // Vector ���� �Ǽ��� ��ȯ
        {
            CallLookEvent(newAim);
        }
    }

    public void OnFire(InputValue value)
    {
        IsAttacking = value.isPressed;
    }
}
//public void OnMove(InputAction.CallbackContext context)
//{

//    if (context.performed)
//    {
//        Vector2 mousePosition = context.ReadValue<Vector2>();

//        Vector2 worldPos = _camera.ScreenToWorldPoint(mousePosition);
//        Vector2 moveDirection = (worldPos - (Vector2)transform.position).normalized;
//        CallMoveEvent(moveDirection);
//    }
//}

//public void OnLook(InputValue value)
//{
//    Vector2 newAim = value.Get<Vector2>();
//    Vector2 WorldPos = _camera.ScreenToWorldPoint(newAim);
//    newAim = (WorldPos - (Vector2)transform.position).normalized;

//    if (newAim.magnitude >= 0.9f)
//    {
//        CallLookEvent(newAim);
//    }
//}
//public void OnSelect(InputValue value)
//{

//}