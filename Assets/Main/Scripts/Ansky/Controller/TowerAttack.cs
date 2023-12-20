using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAttack : MonoBehaviour
{
    private TowerStatHandler _stats;
    private RangedAttackData _attackData;

    public float TowerDamager = 20; // ���ݷ�
    public float TowerRange = 10f; // ���ݹ���
    //public float AttackDely = 2f;  // �� ���ݰ� ������
    private float CurrentDely = 0f; // ���� ������ ���
    public GameObject bulletObj;
    private float BulletPerShot;
    private void Awake()
    {
        _stats = GetComponent<TowerStatHandler>();
        _attackData = _stats.CurrentStats.attackSO as RangedAttackData;
        TowerDamager = _stats.CurrentStats.attackSO.power;
        TowerRange = _attackData.range;
        BulletPerShot = _attackData.numberofProjectilesPerShot;
    }

    private void Update()
    {
        CurrentDely -= Time.deltaTime;
        if(CurrentDely <= 0f)
        {
            Attack();
            CurrentDely = _stats.CurrentStats.attackSO.delay;
        }
    }

    private void Attack()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position,TowerRange);
        int CurrentBulletcount = 0;
        foreach(Collider2D collider in colliders)
        {
            if (collider.CompareTag("Enemy") && CurrentBulletcount < BulletPerShot)
            {
                Vector3 BulletSpawnPosition = transform.position;
                Bullet bullet = Instantiate(bulletObj, BulletSpawnPosition, Quaternion.identity).GetComponent<Bullet>();
                bullet.SetTarget(collider.transform, TowerDamager);
                CurrentBulletcount++;
            }
        }
    }
}   
