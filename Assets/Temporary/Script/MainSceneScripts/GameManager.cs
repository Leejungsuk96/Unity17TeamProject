using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform enemies1;    // enemyA prefabs create Transform, enemyA prefabs 생성 Transform
    [SerializeField] private Transform enemies2;    // enemyB prefabs create Transform, enemyB prefabs 생성 Transform
    [SerializeField] private Transform enemies3;    // enemyC prefabs create Transform, enemyC prefabs 생성 Transform
    private int enemies;


    public TextMeshProUGUI EnemyCountTxt;   // enemy count text UI, enemy 숫자 텍스트 UI
    

    public static GameManager instance;
    public PoolManager pool; // ���� ����

    void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        EnemyCountUIUpdate();
    }


    private void EnemyCountUIUpdate()
    {
        enemies = enemies1.childCount + enemies2.childCount + enemies3.childCount;    // Add the children of the created enemy's prefabs, 생성된 enemy의 prefabs의 자식을 모두 더함 
        EnemyCountTxt.text = enemies.ToString();     // enemy count upload to Text UI, 적 카운트를 textUI로 업로드
    }

}
