using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject obj1;
    public GameObject obj2;
    public GameObject obj3;

    public event Action OnGameOver;

    public TextMeshProUGUI EnemyCountTxt;

    private int enemyCount;
    private int GameoverEnemyCount = 20;

    public static GameManager instance;
    public PoolManager pool;

    private EnemySpawneController _enemy1;
    private EnemySpawneController _enemy2;
    private EnemySpawneController _enemy3;

    private

    void Awake()
    {
        instance = this;
        _enemy1 = obj1.GetComponent<EnemySpawneController>();
        _enemy2 = obj2.GetComponent<EnemySpawneController>();
        _enemy3 = obj3.GetComponent<EnemySpawneController>();
    }

    private void Update()
    {
        EnemyCount();
        EnemyCountUIUpdate();
    }

    private void FixedUpdate()
    {
       if(enemyCount > GameoverEnemyCount)
        {
            CallGameOver();
        }
    }

    private void EnemyCountUIUpdate()
    {
        EnemyCountTxt.text = enemyCount.ToString();
    }

    private void EnemyCount()
    {
        enemyCount = _enemy1.count + _enemy2.count + _enemy3.count;
    }

    private void CallGameOver()
    {
        OnGameOver?.Invoke();
    }
}
