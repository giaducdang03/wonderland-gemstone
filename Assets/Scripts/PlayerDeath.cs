using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    private Player playerMovement;
    [SerializeField] private HeathBar healthBar;
    [SerializeField] private int currentHealth = 0;
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private float invincibilityTime = 1f;
    [SerializeField] private int numberOfFlash = 6;
    [SerializeField] private int playerLayer = 0;
    [SerializeField] private int enemyLayer = 6;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GetComponent<Player>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
        healthBar.SetMaxHeath(maxHealth);
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
        var currentScene = SceneManager.GetActiveScene().buildIndex;
        if (currentScene == 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        } 
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Spike"))
        {
            Die();
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(20);
            if (currentHealth <= 0)
            {
                Die();
            }
        }
    }
    private void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHeath(currentHealth);
        StartCoroutine(Invinsibility());
    }
    private IEnumerator Invinsibility()
    {
        Physics2D.IgnoreLayerCollision(playerLayer, enemyLayer, true);
        for (int i = 0; i < numberOfFlash; i++)
        {
            spriteRenderer.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(invincibilityTime / (numberOfFlash * 2));
            spriteRenderer.color = Color.white;
            yield return new WaitForSeconds(invincibilityTime / (numberOfFlash * 2));
        }
        Physics2D.IgnoreLayerCollision(playerLayer, enemyLayer, false);
    }
}
