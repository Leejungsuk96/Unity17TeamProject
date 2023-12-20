using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public PoolManager pool; // 몬스터 생성

    void Awake()
    {
        instance = this;
    }
}
