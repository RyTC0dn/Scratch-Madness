using UnityEngine;

public class Player_Behaviour : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Player hit!");
            // Here you can implement logic to reduce the player's health or trigger a death animation
            // For example, you could have a Player_Stats script that manages the player's health
            // and call a method like playerStats.TakeDamage(20f);
        }
    }
}