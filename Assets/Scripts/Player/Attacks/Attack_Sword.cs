using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.iOS;

public class Attack_Sword : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] public float _damage = 3;
    [SerializeField] public float _critMultiplier = 0;
    [SerializeField] public float _knockback = 50;

    [Header("Params & Bools")]
    [SerializeField] private Collider2D swordCollider;
    [SerializeField] private Vector3 faceRight = new Vector3(0.6f, 0.02f, 0f);
    [SerializeField] private Vector3 faceLeft = new Vector3(-0.6f, -0.02f, 0f);

    [Header("Range")]
    [SerializeField] public string tagTarget = "Enemy";
    [SerializeField] public float defaultRadius;
    [SerializeField] public float critRadius;
    [SerializeField] public List<Collider2D> detectedObjs = new List<Collider2D>();
    [SerializeField] public BoxCollider2D col;

    void Start()
    {
        if (swordCollider == null)
        {
            Debug.LogWarning("Attack_Sword Collider not set");
        }
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == tagTarget)
        {
            float _crit = _damage * _critMultiplier;
            detectedObjs.Add(collider);

            if (_critMultiplier > 0)
            {
                collider.gameObject.GetComponent<EnemyCore>().TakeDamage(_crit);
                Debug.Log($"Attacking with: {_damage} and {_crit} Crit damage, with a multiplier of {_critMultiplier} and a knockback force of {_knockback}");
                if (_knockback > 0)
                {
                    //Knockback Code Insert
                }
            }

            else
            {
                collider.gameObject.GetComponent<EnemyCore>().TakeDamage(_damage);
                Debug.Log($"Attacking with: {_damage} and {_crit} Crit damage, with a multiplier of {_critMultiplier} and a knockback force of {_knockback}");
                if (_knockback > 0)
                {
                    //Knockback Code Insert
                }
            }
        }
    }

    public void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == tagTarget)
        {
            detectedObjs.Remove(collider);
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
