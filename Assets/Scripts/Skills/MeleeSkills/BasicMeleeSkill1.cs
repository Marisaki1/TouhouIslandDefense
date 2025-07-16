using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Simple Basic Melee", menuName = "Skills/Simple/Basic Melee")]
public class SimpleBasicMeleeSkill : SkillData
{
    [Header("Melee Settings")]
    public float attackRadius = 2f;
    public LayerMask enemyLayer = 1;

    public override void Execute(PlayerController player)
    {
        base.Execute(player);

        Vector2 attackPosition = player.GetPosition() + player.GetFacingDirection() * attackRadius;

        // Find enemies in range
        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPosition, attackRadius, enemyLayer);

        foreach (Collider2D enemy in enemies)
        {
            Debug.Log($"Melee attack hit {enemy.name} for {damage} damage");

            // Simple enemy destruction (replace with your damage system later)
            if (enemy.CompareTag("Enemy"))
            {
                Destroy(enemy.gameObject);
            }
        }

        // Visual feedback
        //DebugExtensions.DrawCircle(attackPosition, attackRadius, Color.red, 0.5f);
    }
}