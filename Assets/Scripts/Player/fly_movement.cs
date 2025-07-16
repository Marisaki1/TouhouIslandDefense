using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;

    [Header("Components")]
    public AudioSource audioSource;

    private Rigidbody2D rb;
    private Vector2 moveInput;
    private InputManager inputManager;
    private SkillManager skillManager;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f; // No gravity for flying movement

        inputManager = GetComponent<InputManager>();
        skillManager = GetComponent<SkillManager>();

        if (audioSource == null)
            audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        HandleMovement();
    }

    void HandleMovement()
    {
        float horizontal = 0f;
        float vertical = 0f;

        // Arrow keys
        if (Input.GetKey(KeyCode.LeftArrow)) horizontal = -1f;
        if (Input.GetKey(KeyCode.RightArrow)) horizontal = 1f;
        if (Input.GetKey(KeyCode.DownArrow)) vertical = -1f;
        if (Input.GetKey(KeyCode.UpArrow)) vertical = 1f;

        // JKLI keys (J=left, K=down, L=right, I=up)
        if (Input.GetKey(KeyCode.J)) horizontal = -1f;
        if (Input.GetKey(KeyCode.L)) horizontal = 1f;
        if (Input.GetKey(KeyCode.K)) vertical = -1f;
        if (Input.GetKey(KeyCode.I)) vertical = 1f;

        moveInput.x = horizontal;
        moveInput.y = vertical;

        // Normalize diagonal movement
        moveInput = moveInput.normalized;
    }

    void FixedUpdate()
    {
        // Move the player
        rb.velocity = moveInput * moveSpeed;
    }

    // Public methods for skills to access player data
    public Vector2 GetPosition()
    {
        return transform.position;
    }

    public Vector2 GetFacingDirection()
    {
        // Return the direction the player is facing based on movement
        return moveInput.magnitude > 0 ? moveInput : Vector2.right;
    }

    public SkillManager GetSkillManager()
    {
        return skillManager;
    }
}