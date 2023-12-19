using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class TopDownTowerController : MonoBehaviour
{
    public event Action OnClickEvent;
    public event Action OnMoveEvent;
    public event Action<Vector2> OnLookEvent;


    protected TowerStatHandler Stats { get; private set; }
    protected bool IsClicking { get; set; }
    protected bool IsMoving { get; set; }

    protected virtual void Awake()
    {
        Stats = GetComponent<TowerStatHandler>();
    }

    protected virtual void Update()
    {
        HandleClick();
        MoveClick();
    }

    private void MoveClick()
    {
        if (IsMoving)
        {
            CallMoveEvent();
        }
    }

    private void HandleClick()
    {
        if (IsClicking)
        {
            CallClickEvent();
        }
    }

    public void CallClickEvent()
    {
        OnClickEvent?.Invoke();
    }

    public void CallMoveEvent()
    {
        OnMoveEvent?.Invoke();
    }

    public void CallLookEvent(Vector2 direction)
    {
        OnLookEvent?.Invoke(direction);
    }


}
