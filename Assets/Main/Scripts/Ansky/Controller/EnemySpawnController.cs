using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawneController : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab; // �� ������
    [SerializeField] private Transform[] wayPoints;  // ���� �������� �̵� ���

    private void Awake()
    {
        StartCoroutine("spawnEnemy");
    }

    private IEnumerator spawnEnemy()
    {
        while (true)
        {
            GameObject clone = Instantiate(enemyPrefab);    // �� ������Ʈ ����
            clone.transform.parent = transform;
            EnemyMoveHandler enemy = clone.GetComponent<EnemyMoveHandler>();  // ��� ������ ���� Monster ������Ʈ
            TowerStatHandler _stats = clone.GetComponent<TowerStatHandler>();
            enemy.Setup(wayPoints); // wayPoint ������ �Ű������� Setup() ȣ��

            yield return new WaitForSeconds(_stats.CurrentStats.spawnSpeed);     // spawnTime ���� ���
        }
    }
}
