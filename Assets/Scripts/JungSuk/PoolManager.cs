using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    //.. ��������� ������ ����
    public GameObject[] prefabs;

    //.. Ǯ ����� �ϴ� ����Ʈ��
    List<GameObject>[] pools;

    private void Awake()
    {
        pools = new List<GameObject>[prefabs.Length];

        for(int index = 0; index < pools.Length; index++)
        {
            pools[index] = new List<GameObject>();
        }        
    }

    public GameObject PoolingEnemy(int index)
    {
        GameObject select = null;
        // ������ Ǯ�� ��� �ִ�(��Ȱ��ȭ ��) ���� ������Ʈ ����

        // �߰��ϸ� select ������ �Ҵ�

        foreach (GameObject Enemy in pools[index])
        {
            if(!Enemy.activeSelf)
            {
                select = Enemy;
                select.SetActive(true);
                break;
            }
        }


        // ��� ���� �ִٸ� ���Ӱ� �����ؼ� select ������ �Ҵ�
        if(select == null)
        {
            select = Instantiate(prefabs[index], transform);
            pools[index].Add(select);
        }

        return select;
    }

}
