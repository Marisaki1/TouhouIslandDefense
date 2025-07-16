using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialCommand : ISkillCommand
{
    private SkillManager skillManager;
    private int slotIndex = 2; // D key slot

    public SpecialCommand(SkillManager manager)
    {
        skillManager = manager;
    }

    public void Execute(PlayerController player)
    {
        skillManager.UseSkill(slotIndex, player);
    }

    public bool CanExecute(PlayerController player)
    {
        return skillManager.CanUseSkill(slotIndex);
    }
}