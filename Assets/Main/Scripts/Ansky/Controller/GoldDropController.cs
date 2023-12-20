using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldDropController : MonoBehaviour
{
    private HealthSystem _healthSystem;

    private void Awake()
    {
        _healthSystem = GetComponent<HealthSystem>();
    }

    private void Start()
    {
        _healthSystem.OnDeath += GoldDrop;
    }

    void GoldDrop()
    {
        PlayerGoldManager.instance.AddGold(1);
    }
}