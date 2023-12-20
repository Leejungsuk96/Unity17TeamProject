using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamageSystem : MonoBehaviour
{

    private RangedAttackData _attackData;


    private void OnTriggerEnter2D(Collider2D collision)
    {

            HealthSystem healthSystem = collision.GetComponent<HealthSystem>();
            if (healthSystem != null)
            {
                healthSystem.ChangeHealth(-_attackData.power);
                Debug.Log(healthSystem.CurrentHealth);
            }
    }
}
