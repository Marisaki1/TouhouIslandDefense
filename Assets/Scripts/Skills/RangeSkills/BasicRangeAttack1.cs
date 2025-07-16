using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Basic Range Attack 1", menuName = "Skills/Range/Basic Range Attack 1")]
public class BasicRangeAttack1 : SkillData
{
    [Header("Range Attack 1 Settings")]
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;
    public Transform firePointOverride; // Optional override for fire point

    public override void Execute(PlayerController player)
    {
        base.Execute(player);

        if (bulletPrefab != null)
        {
            // Get fire point from player or use override
            Transform firePoint = GetFirePoint(player);

            if (firePoint != null)
            {
                // Create bullet at fire point
                GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

                // Give bullet velocity
                Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
                if (bulletRb != null)
                {
                    bulletRb.velocity = firePoint.right * bulletSpeed;
                }

                // Set bullet damage if it has a damage component
                var bulletDamage = bullet.GetComponent<BulletDamage>();
                if (bulletDamage != null)
                {
                    bulletDamage.damage = damage;
                }
            }
            else
            {
                Debug.LogWarning("No fire point found for Basic Range Attack 1");
            }
        }
        else
        {
            Debug.LogWarning("No bullet prefab assigned to Basic Range Attack 1");
        }
    }

    private Transform GetFirePoint(PlayerController player)
    {
        // Use override if provided
        if (firePointOverride != null)
            return firePointOverride;

        // Try to find PlayerShooting component for fire point
        var playerShooting = player.GetComponent<PlayerShooting>();
        if (playerShooting != null && playerShooting.firePoint != null)
            return playerShooting.firePoint;

        // Try to find fire point by name
        Transform firePoint = player.transform.Find("FirePoint");
        if (firePoint != null)
            return firePoint;

        // Fallback to player transform
        return player.transform;
    }
}