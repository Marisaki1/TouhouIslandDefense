using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Simple Basic Defense", menuName = "Skills/Simple/Basic Defense")]
public class SimpleBasicDefenseSkill : SkillData
{
    [Header("Defense Settings")]
    public float shieldDuration = 3f;

    public override void Execute(PlayerController player)
    {
        base.Execute(player);

        // Simple shield effect - you can add visual effects here
        Debug.Log($"Defense activated for {shieldDuration} seconds");

        // Add a simple shield component temporarily
        var shield = player.gameObject.AddComponent<SimpleShield>();
        shield.duration = shieldDuration;
    }
}