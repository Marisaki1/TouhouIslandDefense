using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    [System.Serializable]
    public class SkillSlot
    {
        public KeyCode inputKey;
        public SkillData currentSkill;
        public float lastUsedTime;

        public bool CanUse()
        {
            return currentSkill != null && Time.time >= lastUsedTime + currentSkill.cooldown;
        }

        public void Use(PlayerController player)
        {
            if (CanUse() && currentSkill.CanExecute(player))
            {
                currentSkill.Execute(player);
                lastUsedTime = Time.time;
            }
        }

        public float GetCooldownRemaining()
        {
            if (currentSkill == null) return 0f;
            return Mathf.Max(0f, (lastUsedTime + currentSkill.cooldown) - Time.time);
        }
    }

    [Header("Skill Slots")]
    public SkillSlot[] skillSlots = new SkillSlot[5]; // A, S, D, F, R

    [Header("Default Skills")]
    public SkillData defaultMeleeSkill;
    public SkillData defaultRangeSkill;
    public SkillData defaultSpecialSkill;
    public SkillData defaultDefenseSkill;
    public SkillData defaultUltimateSkill;

    void Start()
    {
        InitializeSkillSlots();
    }

    void InitializeSkillSlots()
    {
        // Initialize with default key mappings and skills
        skillSlots[0] = new SkillSlot { inputKey = KeyCode.A, currentSkill = defaultMeleeSkill };
        skillSlots[1] = new SkillSlot { inputKey = KeyCode.S, currentSkill = defaultRangeSkill };
        skillSlots[2] = new SkillSlot { inputKey = KeyCode.D, currentSkill = defaultSpecialSkill };
        skillSlots[3] = new SkillSlot { inputKey = KeyCode.F, currentSkill = defaultDefenseSkill };
        skillSlots[4] = new SkillSlot { inputKey = KeyCode.R, currentSkill = defaultUltimateSkill };
    }

    public void UseSkill(int slotIndex, PlayerController player)
    {
        if (slotIndex >= 0 && slotIndex < skillSlots.Length)
        {
            skillSlots[slotIndex].Use(player);
        }
    }

    public bool CanUseSkill(int slotIndex)
    {
        return slotIndex >= 0 && slotIndex < skillSlots.Length && skillSlots[slotIndex].CanUse();
    }

    public void ChangeSkill(int slotIndex, SkillData newSkill)
    {
        if (slotIndex >= 0 && slotIndex < skillSlots.Length)
        {
            skillSlots[slotIndex].currentSkill = newSkill;
        }
    }

    public SkillData GetSkillInSlot(int slotIndex)
    {
        if (slotIndex >= 0 && slotIndex < skillSlots.Length)
        {
            return skillSlots[slotIndex].currentSkill;
        }
        return null;
    }

    public float GetCooldownRemaining(int slotIndex)
    {
        if (slotIndex >= 0 && slotIndex < skillSlots.Length)
        {
            return skillSlots[slotIndex].GetCooldownRemaining();
        }
        return 0f;
    }
}