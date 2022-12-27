using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Sword : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float _damage = 3;
    [SerializeField] private float _knockback = 50;

    [Header("Params & Bools")]
    [SerializeField] private Collider2D swordCollider;
    [SerializeField] private Vector3 faceRight = new Vector3(0.6f, 0.02f, 0f);
    [SerializeField] private Vector3 faceLeft = new Vector3(-0.6f, -0.02f, 0f);

    void Start()
    {
        if(swordCollider == null)
        {
            Debug.LogWarning("Sword collider not set");
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        I_Damageable damageableObject = col.GetComponent<I_Damageable>();

        if(damageableObject != null)
        {
            Vector3 parentPosition = transform.parent.position;
            Vector2 direction = (col.transform.position - parentPosition).normalized;
            Vector2 knockback = direction * _knockback;

            damageableObject.OnHit(_damage, knockback);
        }
    }

    void IsFacingRight(bool isFacingRight)
    {
        if (isFacingRight)
        {
            gameObject.transform.localPosition = faceRight;
        } else
        {
            gameObject.transform.localPosition = faceLeft;
        }
    }
}
