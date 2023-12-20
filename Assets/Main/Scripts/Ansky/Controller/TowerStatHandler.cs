using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TowerStatHandler : MonoBehaviour
{

    [SerializeField] private TowerStats baseStats;
    public TowerStats CurrentStats { get; private set; }

    private void Awake()
    {
        UpdateTowerStats();
    }

    private void UpdateTowerStats()
    {
        AttackSO attackSO = null;
        if (baseStats.attackSO != null)
        {
            attackSO = Instantiate(baseStats.attackSO);
        }

        CurrentStats = new TowerStats { attackSO = attackSO };
        CurrentStats.statsChangeType = baseStats.statsChangeType;
        CurrentStats.maxHealth = baseStats.maxHealth;
        CurrentStats.speed = baseStats.speed;


    }
}
