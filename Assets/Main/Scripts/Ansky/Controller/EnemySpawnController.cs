using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawneController : MonoBehaviour
{
    // enemy ����� �̵���� ���󰡰�
    [SerializeField] private GameObject enemyPrefab; // �� ������
    [SerializeField] private float spawnTime; // ���� Ÿ��
    [SerializeField] private Transform[] wayPoints;  // ���� �������� �̵� ���

    private void Awake()
    {
        // �� ���� �ڷ�ƾ �Լ� ȣ��
        StartCoroutine("spawnEnemy");
    }

    private IEnumerator spawnEnemy()
    {
        while (true)
        {
            GameObject clone = Instantiate(enemyPrefab);    // �� ������Ʈ ����
            clone.transform.parent = transform;
            EnemyMoveHandler enemy = clone.GetComponent<EnemyMoveHandler>();  // ��� ������ ���� Monster ������Ʈ

            enemy.Setup(wayPoints); // wayPoint ������ �Ű������� Setup() ȣ��

            yield return new WaitForSeconds(spawnTime);     // spawnTime ���� ���
        }
    }
}
