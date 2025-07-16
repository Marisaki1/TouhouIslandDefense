using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Bullet Settings")]
    public int damage = 1;
    public float lifeTime = 5f;
    public string targetTag = "Enemy"; // What this bullet can hit

    void Start()
    {
        // Destroy bullet after lifetime
        Destroy(gameObject, lifeTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(targetTag))
        {
            // Deal damage to target
            HealthSystem targetHealth = other.GetComponent<HealthSystem>();
            if (targetHealth != null)
            {
                targetHealth.TakeDamage(damage);
            }

            // Destroy bullet
            Destroy(gameObject);
        }
    }
}