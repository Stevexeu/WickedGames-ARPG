using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Animator animator;
    public float Health
    {
        set
        {
            health = value;
            if(health <= 0)
            {
                Defeated();
            }
        }
        get
        {
            return health;
        }
    }

    public float health = 1;

    public void Start()
    {
        animator = GetComponent<Animator>();    
    }

    public void Defeated()
    {
        animator.SetTrigger("Death");
    }

    public void RemoveEnemy()
    {
        Destroy(gameObject);
    }

    public void TakeDamage()
    {
        animator.SetTrigger("takeDamage");
    }
}
