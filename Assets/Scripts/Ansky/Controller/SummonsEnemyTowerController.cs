using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonsEnemyTowerController : MonoBehaviour
{
    private int currentSommonsCount = 0;
    private int waveSpawnPosCount = 0;
    private int waveSpawnCount = 0;
    [SerializeField] private int currentWaveIndex = 0;

    public float spawnInterval = .5f;

    public List<GameObject> summonsEnemyTowersPrefabs = new List<GameObject>();

    [SerializeField] private Transform summonsEnemyPositionRoot;
    public List<Transform> summonsEnemyTowersPositions = new List<Transform>();

    [SerializeField] private TowerStats defaultStats;
    [SerializeField] private TowerStats rangedStats;

    private void Awake()
    {
        for (int i = 0; i < summonsEnemyPositionRoot.childCount; i++)
        {
            summonsEnemyTowersPositions.Add(summonsEnemyPositionRoot.GetChild(i));
        }
    }

    private void Start()
    {
        StartCoroutine("StartNextWave");
    }

    IEnumerator StartNextWave()
    {
        while (true)
        {
            if (currentSommonsCount < waveSpawnCount)
            {
                yield return new WaitForSeconds(2f);

                if (currentWaveIndex % 10 == 0)
                {
                    waveSpawnPosCount = waveSpawnPosCount + 1 > summonsEnemyTowersPositions.Count ? waveSpawnPosCount : waveSpawnPosCount + 1;
                    waveSpawnCount = 0;
                }

                if (currentWaveIndex % 3 == 0)
                {
                    waveSpawnCount += 20;
                }

                for (int i = 0; i < waveSpawnPosCount; i++)
                {
                    int posIdx = i;
                    for (int j = 0; j < waveSpawnCount; j++)
                    {
                        int prefabIdx = Random.Range(0, summonsEnemyTowersPrefabs.Count);
                        GameObject enemy = Instantiate(summonsEnemyTowersPrefabs[prefabIdx], summonsEnemyTowersPositions[posIdx].position, Quaternion.identity);
                        //enemy.GetComponent<HealthSystem>().OnDeath += OnEnemyDeath;
                        //enemy.GetComponent<TowerStatHandler>().AddStatModifier(defaultStats);
                        //enemy.GetComponent<TowerStatHandler>().AddStatModifier(rangedStats);

                        currentSommonsCount++;
                        yield return new WaitForSeconds(spawnInterval);
                    }
                }

                currentWaveIndex++;
            }

            yield return null;
        }
    }


    //private void OnEnemyDeath()
    //{
    //    currentSommonsCount--;
    //}
}
