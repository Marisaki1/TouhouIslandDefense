using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISkillCommand
{
    void Execute(PlayerController player);
    bool CanExecute(PlayerController player);
}