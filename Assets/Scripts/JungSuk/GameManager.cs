using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public PoolManager pool;
    //public Transform AttackTarget { get; private set; }  //공격 대상 위치
    //[SerializeField] private string AttackTargetTag = "Enemy"; //AttackTarget= 적 Enemy= 태그이름

    

    private void Awake()
    {
        instance = this; // 싱글톤화 추가 공부 후 예외처리 추가 예정
        //AttackTarget = GameObject.FindGameObjectWithTag(AttackTargetTag).transform;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
