using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //public float moveSpeed = 5f;

    private Rigidbody2D rb;

    public Vector2 moveInput;
    public Animator animator;
    private SpriteRenderer spriteRenderer;

    private CheckGround checkGround;

    [SerializeField] private int jumpCount = 0;
    [SerializeField] private int maxJumpCount = 2;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpHeight = 5f;
    //[SerializeField] private float climbSpeed = 8f;
    //[SerializeField] private AudioSource jumpSounceEffect;
    //[SerializeField] private float attackDelayTime = 0.5f;
    //[SerializeField] private float currentAttackDelayTime = 0;

    private enum MovementState { idle, running, jumping, falling, attacking }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        checkGround = GetComponentInChildren<CheckGround>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // xem nguoi dung co an nut gi khong
        moveInput.x = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput.x * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && jumpCount < maxJumpCount)
        {
            //jumpSounceEffect.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
            jumpCount++;
        }
        UpdateAnimation();

    }

    private void UpdateAnimation()
    {
        MovementState state;
        if (moveInput.x > 0)
        {
            spriteRenderer.flipX = false;
            state = MovementState.running;
        } 
        else if (moveInput.x < 0)
        {
            state = MovementState.running;
            spriteRenderer.flipX= true;
        }
        else
        {
            state = MovementState.idle;
        }
        animator.SetInteger("state", (int)state);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (checkGround.isGround == true)
        {
            jumpCount = 0;
        }
        if (collision.gameObject.CompareTag("Spike"))
        {
            this.enabled = false;
        }
    }
}
