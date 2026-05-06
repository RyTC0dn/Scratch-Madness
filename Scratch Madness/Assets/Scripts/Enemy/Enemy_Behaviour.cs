using UnityEngine;
using UnityEngine.UI;

public class Enemy_Behaviour : MonoBehaviour
{
    [Header("Enemy Settings")]
    public float speed = 5f; // Speed at which the enemy moves

    [Header("Enemy Stats")]
    public Enemy_Stats stats;

    public Image healthBar; // Reference to the health bar UI element
    private float health;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        health = stats.health;

        // Initialize the health bar to full health
        if (healthBar != null)
        {
            healthBar.fillAmount = health / health;
        }
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player_Projectile"))
        {
            Debug.Log("Enemy hit! Current health: " + health);
            // Reduce health by a fixed amount (for example, 20)
            health -= 20f;
            // Update the health bar
            if (healthBar != null)
            {
                healthBar.fillAmount = health / stats.health;
            }
            // Check if the enemy's health has dropped to zero or below
            if (health <= 0)
            {
                Destroy(gameObject); // Destroy the enemy GameObject
            }
            // Destroy the projectile on impact
            Destroy(collision.gameObject);
        }
    }
}