using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAttack : MonoBehaviour
{
    public int TowerDamager = 20; // ���ݷ�
    public float TowerRange = 10f; // ���ݹ���
    public float AttackDely = 2f;  // �� ���ݰ� ������
    private float CurrentDely = 0f; // ���� ������ ���
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
