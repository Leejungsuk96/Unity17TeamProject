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
        //Vector2 moveInput = value.Get<Vector2>();
        //Vector2 WorldPos = _camera.ScreenToWorldPoint(moveInput);
        //moveInput = WorldPos.normalized;
        //CallMoveEvent(moveInput);
        Vector2 moveInput = value.Get<Vector2>();
        if (moveInput != null)
        {
            Ray ray = _camera.ScreenPointToRay(moveInput);
            //RaycastHit hit;
            //if (Physics.Raycast(ray, out hit))
            //{
            //    if (hit.collider.CompareTag("벽태그이름"))
            //    {
            //        정지
            //    }
            //}
            CallMoveEvent(moveInput);
        }

    }

    public void OnLook(InputValue value)
    {
        Vector2 newAim = value.Get<Vector2>();
        Vector2 WorldPos = _camera.ScreenToWorldPoint(newAim);
        newAim = (WorldPos - (Vector2)transform.position).normalized;

        if (newAim.magnitude >= 0)
        {
            CallLookEvent(newAim);
        }
    }
    public void OnSelect(InputValue value)
    {
        
    }

}
