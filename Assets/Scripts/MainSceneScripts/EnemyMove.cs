using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyMove : MonoBehaviour
{
    [SerializeField] Transform[] waypoints;
    private float speed = 2;
    int monsterNum = 0;

    private int currentWaypointIndex = 0;

    private void Start()
    {
        transform.position = waypoints[monsterNum].transform.position;
    }

    private void Update()
    {
        MoveToWaypoint();
    }

    private void MoveToWaypoint()
    {
        if (gameObject.activeSelf)
        {
            transform.position = Vector2.MoveTowards
                (transform.position, waypoints[monsterNum].transform.position, speed * Time.deltaTime);
        }

        if(transform.position == waypoints[monsterNum].transform.position)
        monsterNum++;

        if(monsterNum == waypoints.Length)
        {
            gameObject.SetActive(false);
            monsterNum = 0;
        }
    }
}

