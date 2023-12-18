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
        spawnPoint = GetComponentsInChildren<Transform>(); // 스폰 포인트에서 몬스터 생성
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > 0.2f) // 몬스터 스폰 시간
        {
            timer = 0;
            Spwan();
        }
    }

    void Spwan() // 몬스터 스폰
    {
        GameObject enemy = GameManager.instance.pool.Get(Random.Range(0,3));
        enemy.transform.position = spawnPoint[Random.Range(1,spawnPoint.Length)].position;
    }
}
