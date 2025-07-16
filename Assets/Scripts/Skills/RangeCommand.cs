using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeCommand : ISkillCommand
{
    private SkillManager skillManager;
    private int slotIndex = 1; // S key slot

    public RangeCommand(SkillManager manager)
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