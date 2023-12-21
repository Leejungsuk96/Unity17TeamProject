using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoint;

    float timer;

    private void Awake()
    {
        spawnPoint = GetComponentsInChildren<Transform>(); // ���� ����Ʈ���� ���� ����
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > 1f) // ���� ���� �ð�
        {
            timer = 0;
            Spwan();
        }
    }

    void Spwan() // ���� ����
    {
        GameObject enemy = GameManager.instance.pool.Get(Random.Range(0,4));
        enemy.transform.position = spawnPoint[1].position;
    }
}
