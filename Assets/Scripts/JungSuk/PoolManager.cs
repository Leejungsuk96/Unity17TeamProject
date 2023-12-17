using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    //.. 프리펩들을 보관할 변수
    public GameObject[] prefabs;

    //.. 풀 담당을 하는 리스트들
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
        // 선택한 풀의 놀고 있는(비활성화 된) 게임 오브젝트 접근

        // 발견하면 select 변수에 할당

        foreach (GameObject Enemy in pools[index])
        {
            if(!Enemy.activeSelf)
            {
                select = Enemy;
                select.SetActive(true);
                break;
            }
        }


        // 모두 쓰고 있다면 새롭게 생성해서 select 변수에 할당
        if(select == null)
        {
            select = Instantiate(prefabs[index], transform);
            pools[index].Add(select);
        }

        return select;
    }

}
