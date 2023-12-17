using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StatsChagneType
{
    Add,
    Multiple,
    Override,
}

[Serializable]
public class CharacterStats
{
    public StatsChagneType statsChangeType;
    [Range(1, 100)] public int maxHealth;
    [Range(1, 20f)] public float speed;

    //공격 데이터
     public AttackSO attackSO;
}
