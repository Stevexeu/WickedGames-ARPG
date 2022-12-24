using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController_Slime : MonoBehaviour
{
    [Header("Enemy Stats")]
    [SerializeField] private float _damage = 1;
    [SerializeField] private float _knockback = 500f;

    public void OnCollisionEnter2D(Collision2D col)
    {
        Collider2D collider = col.collider;
        I_Damageable damageable = collider.GetComponent<I_Damageable>();

        if(damageable != null)
        {
            Vector2 direction = (collider.transform.position - transform.position).normalized;
            Vector2 knockback = direction * _knockback;

            damageable.OnHit(_damage, knockback);

        }
    }
}
