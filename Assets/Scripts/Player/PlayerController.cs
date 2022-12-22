using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    bool IsMoving
    {
        set
        {
            isMoving = value;
            animator.SetBool("isMoving", isMoving);
        }
    }

    [Header("Movement")]
    [SerializeField] private float moveSpeed = 150f;
    [SerializeField] private float maxSpeed = 8f;
    [SerializeField] private float collisionOffset = 0.05f;
    [SerializeField] private ContactFilter2D movementFilter;

    [Header("Bools")]
    [SerializeField] private bool isMoving = false;
    [SerializeField] private bool canMove = true;

    [Header("Params")]
    [SerializeField] private float idleFriction = 0.9f;

    Vector2 movementInput;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rb;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();
    Animator animator;

    public Attack_Sword attack_Sword;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {

        if (movementInput != Vector2.zero && canMove)
        {
            rb.velocity = Vector2.ClampMagnitude(rb.velocity + (movementInput * moveSpeed * Time.fixedDeltaTime), maxSpeed);

            if (movementInput.x > 0)
            {
                spriteRenderer.flipX = false;
            } else if (movementInput.x < 0) {
                spriteRenderer.flipX = true;
            }

            IsMoving = true;

        } else {
            rb.velocity = Vector2.Lerp(rb.velocity, Vector2.zero, idleFriction);

            IsMoving = false;
        }
    }

    void OnMove(InputValue movementValue)
    {
        movementInput = movementValue.Get<Vector2>();
    }

    void OnFire()
    {
        animator.SetTrigger("swordAttack");
    }

    public void AttackSword()
    {
        LockMovement();
        if(spriteRenderer.flipX == true)
        {
            attack_Sword.AttackLeft();
        }
        else
        {
            attack_Sword.AttackRight();
        }
    }

    public void LockMovement()
    {
        canMove = false;
    }

    public void UnlockMovement()
    {
        canMove = true;
    }

    public void StopAttack()
    {
        UnlockMovement();
        attack_Sword.StopAttack();
    }
}
