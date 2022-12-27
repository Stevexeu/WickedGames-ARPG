using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;

public class DamageableCharacter : MonoBehaviour, I_Damageable
{
    [Header("Enemy Stats")]
    [SerializeField] private float _health = 9;
    [SerializeField] private bool isAlive = true;
    [SerializeField] public bool _targetable = true;
    [SerializeField] private bool disablesSimulation = false;
    [SerializeField] public float priority = 0;

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

    public bool Targetable
    {
        get { return _targetable; }
        set
        {
            _targetable = value;

            if (disablesSimulation)
            {
                rb.simulated = false;
            }
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
        rb.AddForce(knockback, ForceMode2D.Impulse);
        Debug.Log("Force");
    }

    public void OnHit(float damage)
    {
        Health -= damage;
    }

    public void OnObjectDestroyed()
    {
        Destroy(gameObject);
    }

    public void OnHit(Vector2 knockback)
    {
        rb.AddForce(knockback, ForceMode2D.Impulse);
        Debug.Log("Force");
    }
}
