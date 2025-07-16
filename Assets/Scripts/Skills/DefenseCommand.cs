using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseCommand : ISkillCommand
{
    private SkillManager skillManager;
    private int slotIndex = 3; // F key slot

    public DefenseCommand(SkillManager manager)
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