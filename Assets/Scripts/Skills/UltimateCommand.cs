using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltimateCommand : ISkillCommand
{
    private SkillManager skillManager;
    private int slotIndex = 4; // R key slot

    public UltimateCommand(SkillManager manager)
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