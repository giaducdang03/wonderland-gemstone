using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    private Player playerMovement;
    //[SerializeField] private HeathBar healthBar;
    //[SerializeField] private int currentHealth = 0;
    //[SerializeField] private int maxHealth = 100;
    //[SerializeField] private float invincibilityTime = 1f;
    //[SerializeField] private int numberOfFlash = 6;
    [SerializeField] private int playerLayer = 0;
    //[SerializeField] private int enemyLayer = 6;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GetComponent<Player>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        //currentHealth = maxHealth;
        //healthBar.SetMaxHeath(maxHealth);
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Die()
    {
        playerMovement.enabled = false;
        rb.bodyType = RigidbodyType2D.Static;
        animator.SetTrigger("isDead");
        RestartLevel();
    }

    private void RestartLevel()
    {
        Debug.Log("aaaaa");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Spike"))
        {
            Die();
        }
    }
}
