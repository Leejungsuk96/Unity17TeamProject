using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float enemySpeed;
    public Rigidbody enemyTarget;

    bool enemyIsLive = true;

    Rigidbody2D enemyRigid;
    SpriteRenderer enemySpriter;

    void Awake()
    {
        enemyRigid = GetComponent<Rigidbody2D>();
        enemySpriter = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        if (!enemyIsLive)
            return;
        //�̵� ���� ����
    }

    private void LateUpdate()
    {
        if (!enemyIsLive)
            return;
        //�ø� ���� ����
    }
}
