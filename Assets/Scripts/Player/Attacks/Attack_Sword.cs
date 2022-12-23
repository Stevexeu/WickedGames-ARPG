using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Sword : MonoBehaviour
{
    [Header("Params")]
    [SerializeField] private float damage = 3;
    [SerializeField] private Collider2D swordCollider;

    private void Start()
    {
        if(swordCollider == null)
        {
            Debug.LogWarning("Sword collider not set");
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        col.collider.SendMessage("OnHit", damage); 
    }
}
