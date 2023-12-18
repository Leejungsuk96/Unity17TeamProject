using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs; // ÇÁ¸®ÆÕ º¸°ü

    List<GameObject>[] enemyPools;

    void Awake()
    {
        enemyPools = new List<GameObject>[enemyPrefabs.Length];

        for (int index = 0; index < enemyPools.Length; index++)
        {
            enemyPools[index] = new List<GameObject>();
        }
    }

    public GameObject Get(int index)
    {
        GameObject select = null;

        foreach (GameObject item in enemyPools[index])
        {
             if (!item.activeSelf)
            {
                select = item;
                select.SetActive(true);
                break;
            }
        }

        if (!select)
        {
            select = Instantiate(enemyPrefabs[index], transform);
            enemyPools[index].Add(select);
        }

        return select;
    }
}
