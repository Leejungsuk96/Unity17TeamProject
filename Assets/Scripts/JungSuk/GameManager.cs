using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public PoolManager pool;
    //public Transform AttackTarget { get; private set; }  //���� ��� ��ġ
    //[SerializeField] private string AttackTargetTag = "Enemy"; //AttackTarget= �� Enemy= �±��̸�

    

    private void Awake()
    {
        instance = this; // �̱���ȭ �߰� ���� �� ����ó�� �߰� ����
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
