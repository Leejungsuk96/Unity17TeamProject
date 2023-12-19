using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAttack : MonoBehaviour
{
    public int TowerDamager = 20; // 공격력
    public float TowerRange = 10f; // 공격범위
    public float AttackDely = 2f;  // 매 공격간 딜레이
    private float CurrentDely = 0f; // 현재 딜레이 계산
    public GameObject bulletObj;

    private void Update()
    {
        CurrentDely -= Time.deltaTime;
        if(CurrentDely <= 0f)
        {
            Attack();
            CurrentDely = AttackDely;
        }
    }

    private void Attack()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, TowerRange);

        foreach(Collider2D collider in colliders)
        {
            if (collider.CompareTag("Enemy"))
            {
                Vector3 BulletSpawnPosition = transform.position;
                Bullet bullet = Instantiate(bulletObj, BulletSpawnPosition, Quaternion.identity).GetComponent<Bullet>();
                bullet.SetTarget(collider.transform, TowerDamager);
            }
        }
    }
}   
