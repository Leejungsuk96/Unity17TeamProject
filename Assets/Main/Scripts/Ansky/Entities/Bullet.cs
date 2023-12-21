using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    private float damager;
    private int speed = 10;
    private List<Bullet> bullets;

    private TowerStatHandler _stats;

    private void Awake()
    {
        _stats = GetComponent<TowerStatHandler>();
    }

    public void SetTarget(Transform _target, float _damage)
    {
        target = _target;
        damager = _damage;
    }

    public void Update()
    {
        if(target != null)
        {
            ShootingBullet();
        }
    }

    private void ShootingBullet()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * speed);

        float distance = Vector3.Distance(transform.position, target.position);
        if (distance < 0f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        HealthSystem healthSystem = collision.GetComponent<HealthSystem>();
        if (healthSystem != null)
        {
            healthSystem.ChangeHealth(-damager);
            Debug.Log(healthSystem.CurrentHealth);
            Destroy(gameObject);
        }
    }

}
