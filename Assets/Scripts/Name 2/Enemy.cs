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
        MovePath(); // �̵� ����
    }

    private void MovePath()
    {
        transform.position = Vector2.MoveTowards(transform.position, movePos[moveNum].transform.position, enemySpeed * Time.deltaTime);
        if (transform.position == movePos[moveNum].transform.position)
            moveNum++;
        if (moveNum == movePos.Length)
            moveNum = 0;
    }

    private void LateUpdate()
    {
        if (!enemyIsLive)
            return;
        //�ø� ���� ����
    }

    private void OnEnable()
    {
        movePos = movePos;
    }
}
