using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    private Vector3 moveDirection = Vector3.zero;
    private TowerStatHandler _stats;
    private float moveSpeed;

    private void Awake()
    {
        _stats = GetComponent<TowerStatHandler>();
    }

    private void Start()
    {
        moveSpeed = _stats.CurrentStats.speed;
    }

    private void Update()
    {
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }

    public void MoveTo(Vector3 direction)
    {
        moveDirection = direction;
    }
}
