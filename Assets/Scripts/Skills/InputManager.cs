using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [Header("References")]
    public PlayerController playerController;
    public SkillManager skillManager;

    private Dictionary<KeyCode, ISkillCommand> skillCommands;

    void Start()
    {
        if (playerController == null)
            playerController = GetComponent<PlayerController>();

        if (skillManager == null)
            skillManager = GetComponent<SkillManager>();

        InitializeSkillCommands();
    }

    void InitializeSkillCommands()
    {
        skillCommands = new Dictionary<KeyCode, ISkillCommand>
        {
            { KeyCode.A, new MeleeCommand(skillManager) },
            { KeyCode.S, new RangeCommand(skillManager) },
            { KeyCode.D, new SpecialCommand(skillManager) },
            { KeyCode.F, new DefenseCommand(skillManager) },
            { KeyCode.R, new UltimateCommand(skillManager) }
        };
    }

    void Update()
    {
        HandleSkillInput();
    }

    void HandleSkillInput()
    {
        foreach (var kvp in skillCommands)
        {
            if (Input.GetKeyDown(kvp.Key))
            {
                if (kvp.Value.CanExecute(playerController))
                {
                    kvp.Value.Execute(playerController);
                }
                else
                {
                    Debug.Log($"Cannot execute skill bound to {kvp.Key}");
                }
            }
        }
    }

    public void RemapSkill(KeyCode oldKey, KeyCode newKey)
    {
        if (skillCommands.ContainsKey(oldKey))
        {
            var command = skillCommands[oldKey];
            skillCommands.Remove(oldKey);
            skillCommands[newKey] = command;
        }
    }
}