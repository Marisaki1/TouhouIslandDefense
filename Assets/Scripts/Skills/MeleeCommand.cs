using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MeleeCommand : ISkillCommand
{
    private SkillManager skillManager;
    private int slotIndex = 0; // A key slot

    public MeleeCommand(SkillManager manager) => skillManager = manager;

    public void Execute(PlayerController player)
    {
        skillManager.UseSkill(slotIndex, player);
    }

    public bool CanExecute(PlayerController player)
    {
        return skillManager.CanUseSkill(slotIndex);
    }
}