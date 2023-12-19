using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    private int damager;
    private int speed = 5;
    private List<Bullet> bullets;

    public void SetTarget(Transform _target, int _damage)
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
}
