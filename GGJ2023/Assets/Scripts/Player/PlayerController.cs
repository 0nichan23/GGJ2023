using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float JumpHeight;

    [SerializeField] private SensorHolder groundCheck;

    private Rigidbody2D rb;

    private Vector2 baseVelocity;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GameManager.Instance.InputManager.OnJumpDown.AddListener(Jump);
    }

    private void Update()
    {
        SetInputVelocity();
    }
    private void FixedUpdate()
    {
        MoveController();
    }

    private void Jump()
    {
        if (groundCheck.IsGrounded())
        {
            baseVelocity.y = JumpHeight;
        }
    }
    private void SetInputVelocity()
    {
        baseVelocity.x = GameManager.Instance.InputManager.GetMoveDirection().x;
    }
    private void MoveController()
    {
        rb.velocity = baseVelocity * movementSpeed;
    }
}
