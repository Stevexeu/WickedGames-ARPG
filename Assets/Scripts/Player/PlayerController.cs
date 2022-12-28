using Cinemachine.Utility;
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
    [SerializeField] private float moveSpeed = 600f;
    [SerializeField] private float maxSpeed = 4f;
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
    Collider2D swordCollider;

    public GameObject swordHitbox;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        swordCollider = swordHitbox.GetComponent<Collider2D>();
    }

    private void FixedUpdate()
    {

        if (movementInput != Vector2.zero && canMove && rb.simulated)
        {
            //rb.velocity = Vector2.ClampMagnitude(rb.velocity + (movementInput * moveSpeed * Time.fixedDeltaTime), maxSpeed);
            rb.AddForce(movementInput * moveSpeed * Time.deltaTime);

            if(rb.velocity.magnitude > maxSpeed)
            {
                float limitedSpeed = Mathf.Lerp(rb.velocity.magnitude, maxSpeed, idleFriction);
                rb.velocity = rb.velocity.normalized * limitedSpeed;
            }

            if (movementInput.x > 0)
            {
                spriteRenderer.flipX = false;
                gameObject.BroadcastMessage("IsFacingRight", true);
            } else if (movementInput.x < 0) {
                spriteRenderer.flipX = true;
                gameObject.BroadcastMessage("IsFacingRight", false); 
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

    public void LockMovement()
    {
        canMove = false;
    }

    public void UnlockMovement()
    {
        canMove = true;
    }
}
