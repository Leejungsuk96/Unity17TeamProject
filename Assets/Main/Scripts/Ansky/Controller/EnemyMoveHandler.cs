using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveHandler : MonoBehaviour
{
    private int wayPointCount; // �̵���� ����
    private Transform[] wayPoints; // �̵���� ����
    private int currentIndex = 0; // ���� ��ǥ���� �ε���
    private EnemyMovement movement; // ������Ʈ �̵�����
    private TowerStatHandler _stat;

    private void Awake()
    {
        _stat = GetComponent<TowerStatHandler>();
    }

    public void Setup(Transform[] wayPoins)
    {
        movement = GetComponent<EnemyMovement>();

        //�� �̵���� WayPoints ���� ����
        wayPointCount = wayPoins.Length;
        this.wayPoints = new Transform[wayPointCount];
        this.wayPoints = wayPoins;

        // ���� ��ġ�� ù��° wayPoint�� ����
        transform.position = wayPoints[currentIndex].position;

        //�� �̵� ��ǥ���� ���� �Լ� ����
        StartCoroutine("OnMove");
    }

    private IEnumerator OnMove()
    {
        // ���� �̵� ����
        NextMoveTo();

        while (true)
        {
            //transform.Rotate(Vector3.forward * 10);
            
            // �� �����ӿ� 0.02f���� ũ�� �����̱� ������ if���ǹ��� �ɸ��� �ʰ� ��� Ż���ϴ� �� ����
            if(Vector3.Distance(transform.position, wayPoints[currentIndex].position) < 0.01f * _stat.CurrentStats.speed)
            {
                NextMoveTo();   // ���� �̵� ����
            }

            yield return null;
        }
    }

    private void NextMoveTo()
    {
        // �̵��� wayPoint�� ����������
        if(currentIndex < wayPointCount - 1) 
        {
            // enemy��ġ�� ��ǥ ��ġ�� ����
            transform.position = wayPoints[currentIndex].position;
            // �̵� ���� ���� 
            currentIndex++;
            Vector3 direction = (wayPoints[currentIndex].position - transform.position).normalized;
            movement.MoveTo(direction);
        }
        // ������ wayPoint �϶�
        else
        {
            currentIndex = 0;
            NextMoveTo();
            // enemy ����
            //Destroy(gameObject);
        }
    }
}
