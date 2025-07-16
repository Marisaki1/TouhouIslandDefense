using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Skill", menuName = "Skills/Skill Data")]
public class SkillData : ScriptableObject
{
    [Header("Basic Properties")]
    public string skillName;
    public SkillType skillType;
    public string description;

    [Header("Stats")]
    public float damage;
    public float cooldown;
    public float range;
    public float manaCost;

    [Header("Effects")]
    public GameObject effectPrefab;
    public AudioClip soundEffect;

    public virtual void Execute(PlayerController player)
    {
        Debug.Log($"Executing {skillName} - Override this method in derived classes");

        // Play sound effect if available
        if (soundEffect != null && player.audioSource != null)
        {
            player.audioSource.PlayOneShot(soundEffect);
        }

        // Instantiate effect if available
        if (effectPrefab != null)
        {
            Instantiate(effectPrefab, player.transform.position, player.transform.rotation);
        }
    }

    public virtual bool CanExecute(PlayerController player)
    {
        // Override for custom conditions (mana, stamina, etc.)
        return true;
    }
}