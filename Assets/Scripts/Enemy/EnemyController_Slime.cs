using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.IO.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController_Slime : MonoBehaviour
{
    [Header("Enemy Stats")]
    [SerializeField] private float _damage = 1;
    [SerializeField] private float _knockback = 50f;
    [SerializeField] private float _moveSpeed = 2000f;
    [SerializeField] private float _followColliderSize = 12f;
    [SerializeField] private float _normalColliderSize = 4.2f;
    [SerializeField] private float _nextShot = 0.15f;
    [SerializeField] private float _fireDelay = 0.5f;
    public Detection detection;
    private Rigidbody2D rb;
    public DamageableCharacter character;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        character = GetComponent<DamageableCharacter>();
    }

    void FixedUpdate()
    {
        if (detection.detectedObjs.Count > 0)
        {
            Vector2 direction = (detection.detectedObjs[0].transform.position - transform.position).normalized;
            rb.AddForce(direction * _moveSpeed * Time.deltaTime);
            detection.col.GetComponent<CircleCollider2D>().radius = _followColliderSize;
        }
        else
        {
            detection.col.GetComponent<CircleCollider2D>().radius = _normalColliderSize;
        }
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        Collider2D collider = col.collider;
        I_Damageable damageable = collider.GetComponent<I_Damageable>();

        if (damageable != null)
        {
            {
                Vector2 direction = (collider.transform.position - transform.position).normalized;

                if (col.gameObject.GetComponent<DamageableCharacter>().priority > 0)
                {
                    Vector2 knockback = direction * _knockback;
                    damageable.OnHit(knockback);

                    if (Time.time > _nextShot)
                    {
                         damageable.OnHit(_damage);

                        _nextShot = Time.time + _fireDelay;
                    }
                }
            }
        }
    }
}
