using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController_Slime : MonoBehaviour
{
    [Header("Enemy Stats")]
    [SerializeField] private float _damage = 1;

    public void OnCollisionEnter2D(Collision2D col)
    {
        I_Damageable damageable = col.collider.GetComponent<I_Damageable>();

        if(damageable != null)
        {
            damageable.OnHit(_damage);

        }
    }
}
