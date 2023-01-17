using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using wickedgames;

public class EnemyCore : MonoBehaviour
{
    [Header("References")]
    DamageableCharacter _damageableCharacter;

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
    [SerializeField] public bool _attackAvailible = true;

    [Header("Enemy Stats")]
    [SerializeField] public bool isAlive = true;
    [SerializeField] public float _enemyHealth;

    Animator animator;
    public PlayerController _playerController;
    public Rigidbody2D body;

    private void Start()
    {
        _crit = _damage * _critMultiplier;
        _damageableCharacter = GetComponent<DamageableCharacter>();
        animator = GetComponent<Animator>();
        animator.SetBool("isAlive", isAlive);
        Detection detection = GetComponent<Detection>();
    }

    public void Update()
    {
        if (_inDamageRange && _attackAvailible == true)
            ApplyDamage();
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

}
