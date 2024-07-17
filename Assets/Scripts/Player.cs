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

    [SerializeField] private float climbSpeed = 8f;

    private CheckGround checkGround;

    private bool isAttaching = false;

    [SerializeField] private int jumpCount = 0;
    [SerializeField] private int maxJumpCount = 2;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpHeight = 5f;
    //[SerializeField] private float climbSpeed = 8f;
    //[SerializeField] private AudioSource jumpSounceEffect;
    //[SerializeField] private float attackDelayTime = 0.5f;
    //[SerializeField] private float currentAttackDelayTime = 0;

    private bool isClimbing;
    private bool isLadder;

    public static Player Instance { get; private set; }


    private enum MovementState { idle, running, jumping, falling, attacking }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        };

    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        checkGround = GetComponentInChildren<CheckGround>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (isClimbing)
        {
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(rb.velocity.x, moveInput.y * climbSpeed);
        }
        else
        {
            rb.gravityScale = 1f;
        }
    }


    private void Update()
    {
        // xem nguoi dung co an nut gi khong
        moveInput.x = Input.GetAxis("Horizontal");

        moveInput.y = Input.GetAxis("Vertical");
        if (isLadder && Mathf.Abs(moveInput.y) > 0)
        {
            isClimbing = true;
        }

        if (!isAttaching || moveInput.x != 0)
        {
            rb.velocity = new Vector2(moveInput.x * moveSpeed, rb.velocity.y);
        }

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
            spriteRenderer.flipX = true;
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

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("GroundAttachAble"))
        {
            isAttaching = true;
            Rigidbody2D rigid = collision.gameObject.GetComponent<Rigidbody2D>();
            //transform.SetParent(collision.transform);
            rb.velocity = new Vector2(rigid.velocity.x, rb.velocity.y);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("GroundAttachAble"))
        {
            isAttaching = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ladder"))
        {
            isLadder = false;
            isClimbing = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ladder"))
        {
            isLadder = true;
        }
    }
}
