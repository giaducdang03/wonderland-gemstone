using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //public float moveSpeed = 5f;

    private Rigidbody2D rb;

    public Vector2 moveInput;
    public Animator animator;

    private CheckGround checkGround;

    [SerializeField] private int jumpCount = 0;
    [SerializeField] private int maxJumpCount = 2;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpHeight = 5f;
    //[SerializeField] private float climbSpeed = 8f;
    //[SerializeField] private AudioSource jumpSounceEffect;
    //[SerializeField] private float attackDelayTime = 0.5f;
    //[SerializeField] private float currentAttackDelayTime = 0;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        checkGround = GetComponentInChildren<CheckGround>();
        //animator = GetComponent<Animator>();
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

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (checkGround.isGround == true)
        {
            jumpCount = 0;
        }
    }
}
