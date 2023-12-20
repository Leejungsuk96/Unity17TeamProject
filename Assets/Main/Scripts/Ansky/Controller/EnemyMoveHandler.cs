using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveHandler : MonoBehaviour
{
    // enemy ���� ����, �̵���� ���� ����
    [SerializeField] public float hp = 0.0f; // ü��
    private int wayPointCount; // �̵���� ����
    private Transform[] wayPoints; // �̵���� ����
    private int currentIndex = 0; // ���� ��ǥ���� �ε���
    private EnemyMovement movement2D; // ������Ʈ �̵�����

    public void Setup(Transform[] wayPoins)
    {
        movement2D = GetComponent<EnemyMovement>();

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
            if(Vector3.Distance(transform.position, wayPoints[currentIndex].position) < 0.01f * movement2D.MoveSpeed)
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
            movement2D.MoveTo(direction);
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
