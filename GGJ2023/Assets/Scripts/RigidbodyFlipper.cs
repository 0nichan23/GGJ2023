using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class RigidbodyFlipper : MonoBehaviour
{
    [SerializeField] private Vector2 rightVector = Vector3.zero;
    [SerializeField] private Vector2 leftVector = new Vector3(0, 180, 0);
    private Rigidbody2D rb;
    public bool lookingRight;

    public bool LookingRight { get => lookingRight; }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lookingRight = true;
        StartCoroutine(WaitTillNegativeVelocity());
    }

    private IEnumerator WaitTillNegativeVelocity()
    {
        yield return new WaitUntil(() => rb.velocity.x < 0);
        transform.rotation = Quaternion.Euler(leftVector);
        lookingRight = false;
        StartCoroutine(WaitTillPositiveVelocity());
    }
    private IEnumerator WaitTillPositiveVelocity()
    {
        yield return new WaitUntil(() => rb.velocity.x > 0);
        transform.rotation = Quaternion.Euler(rightVector);
        lookingRight = true;
        StartCoroutine(WaitTillNegativeVelocity());
    }
}
