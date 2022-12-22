using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Sword : MonoBehaviour
{
    [Header("Params")]
    [SerializeField] private float damage = 3;
    [SerializeField] private Collider2D swordCollider;

    Vector2 rightAttackOffset;

    private void Start()
    {
        rightAttackOffset = transform.localPosition;
    }

    public void AttackRight()
    {
        swordCollider.enabled = true;
        transform.localPosition = rightAttackOffset;
    }

    public void AttackLeft()
    {
        swordCollider.enabled = true;
        transform.localPosition = new Vector3(rightAttackOffset.x * -1, rightAttackOffset.y);
    }

    public void StopAttack()
    {
        swordCollider.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            EnemyController enemy = other.GetComponent<EnemyController>();
            if (enemy != null)
            {
                enemy.Health -= damage;
                enemy.TakeDamage();
            }
        }
    }
}
