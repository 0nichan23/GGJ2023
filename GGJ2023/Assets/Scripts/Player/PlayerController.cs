using UnityEngine;
using System;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform gfx;
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
        GameManager.Instance.InputManager.OnStepDownDown.AddListener(StartMoveDown);
        groundCheck.OnNotGrounded.AddListener(StartCoyoteTime);
        groundCheck.OnGrounded.AddListener(ResetJumped);
    }

    private void Update()
    {
        SetInputVelocity();
        RoatatePlayerGFXToMatchGround();
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

    private void RoatatePlayerGFXToMatchGround()
    {
        var normal = groundCheck.GetNormalFromSensor(groundCheck.CenterSensor);
        var rotationDifference = Quaternion.FromToRotation(Vector3.up, normal);
        gfx.rotation = rotationDifference;
    }

    private void StartMoveDown()
    {
        StartCoroutine(MoveDownCounter(groundCheck.GetAllColliders()));
    }

    private IEnumerator CoyoteCounter()
    {
        coyoteAvailable = true;
        yield return new WaitForSecondsRealtime(coyoteTime);
        coyoteAvailable = false;
    }
    private IEnumerator MoveDownCounter(Collider2D[] givenColliders)
    {
        if (givenColliders.Length <= 0)
        {
            yield break;
        }
        foreach (var item in givenColliders)
        {
            if (item.gameObject.CompareTag("Platform"))
            {
                item.isTrigger = true;
            }
        }
        yield return new WaitUntil(() => transform.position.y < givenColliders[0].bounds.min.y);
        foreach (var item in givenColliders)
        {
            item.isTrigger = false;
        }

    }
}
