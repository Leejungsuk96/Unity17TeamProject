using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Movement : MonoBehaviour
{
    private CharacterController _controller;
    private float moveSpeed = 5f;
    private Vector2 moveDirection = Vector2.zero;
    private Rigidbody2D _rigidbody;


    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _controller.OnMoveEvent += Move;
    }

    private void FixedUpdate()
    {
        ApplyMovement(moveDirection);
    }

    private void Move(Vector2 direction)
    {
        moveDirection = direction;

    }

    private void ApplyMovement(Vector2 direction)
    {
        _rigidbody.MovePosition(_rigidbody.position + direction * moveSpeed * Time.deltaTime);

    }
}
