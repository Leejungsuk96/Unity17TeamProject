using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamageSystem : MonoBehaviour
{
    [SerializeField] private LayerMask levelCollisionLayer;

    private RangedAttackData _attackData;

    private Vector2 _direction;
    public bool fxOnDestory = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (levelCollisionLayer.value == (levelCollisionLayer.value | (1 << collision.gameObject.layer)))
        {
            DestroyProjectile(collision.ClosestPoint(transform.position) - _direction * .2f, fxOnDestory);
        }
        else if (_attackData.target.value == (_attackData.target.value | (1 << collision.gameObject.layer)))
        {
            HealthSystem healthSystem = collision.GetComponent<HealthSystem>();
            if (healthSystem != null)
            {
                healthSystem.ChangeHealth(-_attackData.power);
                Debug.Log(healthSystem.CurrentHealth);
            }
            DestroyProjectile(collision.ClosestPoint(transform.position), fxOnDestory);
        }
    }

    private void DestroyProjectile(Vector3 position, bool createFx)
    {
        if (createFx)
        {

        }
        gameObject.SetActive(false);
    }
}
