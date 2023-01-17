using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyCore : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Detection detection;
    public Animator animator;
    public PlayerController _playerController;
    public Rigidbody2D body;
    public Transform playerTransform;
    NavMeshAgent agent;
    public GameObject damageTextPrefab, enemyInstance;
    public float floatDamageNumber = 0;
    public Attack_Sword attackSword;

    [Header("Attack Range")]
    [SerializeField] public string _tagTarget = "Player";
    [SerializeField] public float _defaultRadius = 5.3f;
    [SerializeField] public float _critRadius = 24.27f;

    [Header("Attack Params")]
    [SerializeField] public float _damage = 1;
    [SerializeField] public float _crit;
    [SerializeField] public float _critMultiplier;
    [SerializeField] public float _cooldownDuration = 3.0f;
    [SerializeField] public float _knockbackAmount = 1.0f;

    [Header("Booleans")]
    [SerializeField] public bool _inDamageRange = false;
    [SerializeField] public bool _isAlive = true;
    [SerializeField] public bool _attackAvailible = true;
    [SerializeField] public bool _canFollow = false;

    [Header("Enemy Stats")]
    [SerializeField] public float _enemyHealth;
    [SerializeField] public float _enemyShield;


    private void Start()
    {
        _crit = _damage * _critMultiplier;
        animator = GetComponent<Animator>();
        animator.SetBool("isAlive", _isAlive);
        Detection detection = GetComponent<Detection>();
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        _enemyHealth += _enemyShield;
    }

    public void Update()
    {
        if (_inDamageRange && _attackAvailible == true)
            ApplyDamage();

        if (_canFollow)
        {
            agent.SetDestination(playerTransform.position);
        }

        if (!_canFollow)
        {
            agent.ResetPath();
        }
    }

    public void Freeze()
    {
        body.constraints = RigidbodyConstraints2D.FreezePosition;
    }

    public void Unfreeze()
    {
        body.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    public IEnumerator StartCooldown()
    {
        _attackAvailible = false;
        yield return new WaitForSeconds(_cooldownDuration);
        _attackAvailible = true;
    }

    public void ApplyDamage()
    {
        if (_playerController._health > 0)
        {
            _playerController.TakeDamage(_damage);
            Debug.Log($"Attacking with: {_damage} and {_crit} Crit damage, with a multiplier of {_critMultiplier}");
            StartCoroutine(StartCooldown());
        }
    }

    public void TakeDamage(float value)
    {
        floatDamageNumber = value;
        GameObject DamageTextInstance = Instantiate(damageTextPrefab, enemyInstance.transform);
        DamageTextInstance.transform.GetChild(0).GetComponent<TextMeshPro>().SetText($"{floatDamageNumber}");
        animator.SetTrigger("takeDamage");

        _enemyHealth -= value;

        if (_enemyHealth < 1)
        {
            Death();
        }
    }

    public void Death()
    {
        animator.SetBool("isAlive", false);
    }

    public void Destroy()
    {
        GameObject.Destroy(gameObject);
    }

    public void Knockback()
    {
        //Knockback Code Insert
    }

    public void startFollow()
    {
        _canFollow = true;
    }

    public void stopFollow()
    {
        _canFollow = false;
    }

}
