using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour, I_Damageable
{
    [Header("Enemy Stats")]
    [SerializeField] private float _health = 9;
    [SerializeField] private bool isAlive = true;
    [SerializeField] public bool _targetable = true;

    Animator animator;
    Rigidbody2D rb;
    Collider2D physicsCollider;

    public float Health
    {
        set
        {
            if (value < _health)
            {
                animator.SetTrigger("takeDamage");
            }

            _health = value;

            if (_health <= 0)
            {
                animator.SetBool("isAlive", false);
                Targetable = false;
            }
        }
        get
        {
            return _health;
        }
    }

    public bool Targetable { get { return _targetable; }
        set
        {
            _targetable = value;
            rb.simulated = value;
            physicsCollider.enabled = value;
        }
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("isAlive", isAlive);
        rb = GetComponent<Rigidbody2D>();
        physicsCollider = GetComponent<Collider2D>();
    }

    public void OnHit(float damage, Vector2 knockback)
    {
        Health -= damage;
        rb.AddForce(knockback);
    }

    public void OnHit(float damage)
    {
        Health -= damage;
    }

    public void OnObjectDestroyed()
    {
        Destroy(gameObject);
    }
}
