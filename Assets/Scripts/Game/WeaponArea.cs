using UnityEngine;

public class WeaponArea : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject); // Destroy the enemy
        }
    }

    void Start()
    {
        // Auto-destroy the hitbox after a short time
        Destroy(gameObject, 0.2f); // Lifetime of attack
    }
}
