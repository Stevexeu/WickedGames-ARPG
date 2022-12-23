using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Enemy Stats")]
    [SerializeField] private float _health = 9;
    [SerializeField] private bool isAlive = true;
    Animator animator;

    public float Health
    {
        set
        {
            if (value < _health)
            {
                animator.SetTrigger("takeDamage");
            }

            _health = value;
            if(_health <= 0)
            {
                animator.SetBool("isAlive", false);
            }
        }
        get
        {
            return _health;
        }
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnHit(float damage)
    {
        Health -= damage;
    }
}
