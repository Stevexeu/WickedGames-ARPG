using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Sword : MonoBehaviour
{
    Vector2 rightAttackOffset;
    Collider2D swordCollider;

    private void Start()
    {
        swordCollider = GetComponent<Collider2D>();
        rightAttackOffset = transform.localPosition; 
    }

    public void AttackRight()
    {
        print("Attack R");
        swordCollider.enabled = true;
        transform.localPosition = rightAttackOffset;
    }

    public void AttackLeft()
    {
        print("Attack L");
        swordCollider.enabled = true;
        transform.localPosition = new Vector3(rightAttackOffset.x * -1, rightAttackOffset.y);
    }

    public void StopAttack()
    {
        swordCollider.enabled = false;
    }
}
