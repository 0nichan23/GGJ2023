using UnityEngine;
using System;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float JumpHeight;

    [SerializeField] private SensorHolder groundCheck;
    [SerializeField, Range(0,0.3f)] private float coyoteTime;

    private bool coyoteAvailable;
    private bool jumped;

    private Rigidbody2D rb;

    private Vector2 baseVelocity;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GameManager.Instance.InputManager.OnJumpDown.AddListener(Jump);
        groundCheck.OnNotGrounded.AddListener(StartCoyoteTime);
        groundCheck.OnGrounded.AddListener(ResetJumped);
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
        if (groundCheck.IsGrounded() || coyoteAvailable)
        {
            rb.velocity = new Vector2(rb.velocity.x, JumpHeight);
            jumped = true;
        }
    }
    private void SetInputVelocity()
    {
        baseVelocity.x = GameManager.Instance.InputManager.GetMoveDirection().x;
    }
    private void MoveController()
    {
        rb.velocity = new Vector2(baseVelocity.x * movementSpeed, rb.velocity.y);
    }
    private void ResetJumped()
    {
        jumped = false;
    }

    private void StartCoyoteTime()
    {
        if (jumped)
        {
            return;
        }
        StartCoroutine(CoyoteCounter());
    }

    private IEnumerator CoyoteCounter()
    {
        coyoteAvailable = true;
        yield return new WaitForSecondsRealtime(coyoteTime);
        coyoteAvailable = false;
    }
}
