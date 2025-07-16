using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    [Header("Bullet Settings")]
    public float damage = 25f;
    public float lifetime = 5f;
    public LayerMask enemyLayer = 1;

    void Start()
    {
        // Destroy bullet after lifetime
        Destroy(gameObject, lifetime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if hit enemy
        if (((1 << other.gameObject.layer) & enemyLayer) != 0)
        {
            Debug.Log($"Bullet hit {other.name} for {damage} damage");

            // Simple enemy destruction (replace with your damage system later)
            if (other.CompareTag("Enemy"))
            {
                Destroy(other.gameObject);
            }

            Destroy(gameObject);
        }

        // Destroy on wall/obstacle collision
        if (other.CompareTag("Wall") || other.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}