using UnityEngine;
using UnityEngine.UI;

public class Player_Behaviour : MonoBehaviour
{
    public Player_Stats playerStats;
    public Image healthBar; // Reference to the health bar UI element
    private float health;

    private void Start()
    {
        health = playerStats.health;
        // Initialize the health bar to full health
        if (healthBar != null)
        {
            healthBar.fillAmount = health / playerStats.health;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Player hit!");
            health -= 20f; // Reduce health by a fixed amount (for example, 20)
            // Update the health bar
            if (healthBar != null)
            {
                healthBar.fillAmount = health / playerStats.health;
            }
            // Check if the player's health has dropped to zero or below
            if (health <= 0)
            {
                Debug.Log("Player has died!");
                // Implement player death logic here (e.g., respawn, game over screen, etc.)
            }

            // Destroy the enemy on impact
            Destroy(collision.gameObject);
        }
    }
}