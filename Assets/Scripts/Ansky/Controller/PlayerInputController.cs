using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : TopDownTowerController
{
    private Camera _camera;

    protected override void Awake()
    {
        _camera = Camera.main;
    }

    public void OnLook(InputValue value)
    {
        Vector2 newAim = value.Get<Vector2>();
        Vector2 mouseDirection = _camera.ScreenToWorldPoint(newAim);

        CallLookEvent(mouseDirection);
    }

    public void OnClick(InputValue value)
    {
        IsClicking = value.isPressed;
    }

    public void OnMove(InputValue value)
    {
        IsMoving = value.isPressed;
    }
}
