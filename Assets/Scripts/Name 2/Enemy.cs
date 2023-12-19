using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Transform[] movePos;
    int moveNum = 0;
    public float enemySpeed;
    public Rigidbody enemyTarget;

    bool enemyIsLive = true;

    Rigidbody2D enemyRigid;
    SpriteRenderer enemySpriter;

    private void Start()
    {
        transform.position = movePos[moveNum].transform.position;
    }
    void Awake()
    {
        enemyRigid = GetComponent<Rigidbody2D>();
        enemySpriter = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        if (!enemyIsLive)
            return;
    }

    

    private void LateUpdate()
    {
        if (!enemyIsLive)
            return;
        //플립 로직 구현
    }

    
}
