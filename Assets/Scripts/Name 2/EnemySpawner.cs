using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // enemy 만들고 이동경로 따라가고
    [SerializeField] private GameObject enemyPrefab; // 적 프리팹
    [SerializeField] private float spawnTime; // 생성 타임
    [SerializeField] private Transform[] wayPoints;  // 현재 스테이지 이동 경로

    private void Awake()
    {
        // 적 생성 코루틴 함수 호출
        StartCoroutine("spawnEnemy");
    }

    private IEnumerator spawnEnemy()
    {
        while (true)
        {
            GameObject clone = Instantiate(enemyPrefab);    // 적 오브젝트 생성
            Monster enemy = clone.GetComponent<Monster>();  // 방금 생성된 적의 Monster 컴포넌트

            enemy.Setup(wayPoints); // wayPoint 정보를 매개변수로 Setup() 호출

            yield return new WaitForSeconds(spawnTime);     // spawnTime 동안 대기
        }
    }
}
