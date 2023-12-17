using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform spawnPoint;

    float timer;

    private void Awake()
    {
        spawnPoint = GetComponent<Transform>();
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
        GameManager.instance.pool.PoolingEnemy(0);
    }
}
