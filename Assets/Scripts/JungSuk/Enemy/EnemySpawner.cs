using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    Vector3 spawnPosition;
    float timer;

    private void Awake()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 0.2f)
        {
            Spawn();
            timer = 0;
        }
    }

    void Spawn()
    {
        
       GameObject enemy = GameManager.instance.pool.PoolingEnemy(0);
        spawnPosition = new Vector3(-7, 3, 0);
        enemy.transform.position = spawnPosition;
    }
}
