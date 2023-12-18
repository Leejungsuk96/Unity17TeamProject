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
        //이동 로직 구현
    }

    private void LateUpdate()
    {
        if (!enemyIsLive)
            return;
        //플립 로직 구현
    }
}
