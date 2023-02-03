using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SensorHolder : MonoBehaviour
{
    [SerializeField] List<GroundCheckSensor> sensors = new List<GroundCheckSensor>();
    [SerializeField] LayerMask hitLayer;
    private GroundCheckSensor centerSensor;

    public UnityEvent OnGrounded;
    public UnityEvent OnNotGrounded;

    public List<GroundCheckSensor> Sensors { get => sensors; }
    public GroundCheckSensor CenterSensor { get => centerSensor; }

    private void Start()
    {
        StartCoroutine(WaitForGrounded());
        centerSensor = sensors[0];
    }
    public bool IsAllGrounded()
    {
        foreach (var item in sensors)
        {
            Vector3 relativePos = new Vector3(transform.position.x + item.Offset.x, transform.position.y + item.Offset.y);
            if (!Physics2D.Raycast(relativePos, item.Direcion, item.Range, hitLayer))
            {
                return false;
            }
        }
        return true;
    }

    public bool IsGrounded()
    {
        foreach (var item in sensors)
        {
            Vector3 relativePos = new Vector3(transform.position.x + item.Offset.x, transform.position.y + item.Offset.y);
            if (Physics2D.Raycast(relativePos, item.Direcion, item.Range, hitLayer))
            {
                return true;
            }
        }
        return false;
    }

    private bool IsSensorGrounded(GroundCheckSensor givenSensor)
    {
        Vector3 relativePos = new Vector3(transform.position.x + givenSensor.Offset.x, transform.position.y + givenSensor.Offset.y);
        if (Physics2D.Raycast(relativePos, givenSensor.Direcion, givenSensor.Range, hitLayer))
        {
            return true;
        }
        return false;
    }
    public Collider2D GetGroundFromSensor(GroundCheckSensor givenSensor)
    {
        Vector3 relativePos = new Vector3(transform.position.x + givenSensor.Offset.x, transform.position.y + givenSensor.Offset.y);
        RaycastHit2D hit = Physics2D.Raycast(relativePos, givenSensor.Direcion, givenSensor.Range, hitLayer);
        if (hit)
        {
            return hit.collider;
        }
        return null;
    }

    public Vector2 GetNormalFromSensor(GroundCheckSensor givenSensor)
    {
        if (IsSensorGrounded(givenSensor))
        {
            Vector3 relativePos = new Vector3(transform.position.x + givenSensor.Offset.x, transform.position.y + givenSensor.Offset.y);
            RaycastHit2D hit = Physics2D.Raycast(relativePos, givenSensor.Direcion, givenSensor.Range, hitLayer);
            if (hit)
            {
                return hit.normal;
            }
        }
        return Vector2.zero;


    }
    public Collider2D[] GetAllColliders()
    {
        List<Collider2D> groundedColliders = new List<Collider2D>();
        foreach (var item in sensors)
        {
            if (!ReferenceEquals(GetGroundFromSensor(item), null))
            {
                groundedColliders.Add(GetGroundFromSensor(item));
            }
        }
        return groundedColliders.ToArray();
    }

    IEnumerator WaitForGrounded()
    {
        yield return new WaitUntil(() => IsGrounded());
        OnGrounded?.Invoke();
        StartCoroutine(WaitForNotGrounded());
    }
    IEnumerator WaitForNotGrounded()
    {
        yield return new WaitUntil(() => !IsGrounded());
        OnNotGrounded?.Invoke();
        StartCoroutine(WaitForGrounded());
    }

    private void OnDrawGizmosSelected()
    {
        foreach (var item in sensors)
        {
            Vector3 relativePos = new Vector3(transform.position.x + item.Offset.x, transform.position.y + item.Offset.y);
            Vector3 to = item.Direcion * item.Range;
            to = new Vector3(relativePos.x + to.x, relativePos.y + to.y);
            Gizmos.color = Color.red;
            if (IsSensorGrounded(item))
            {
                Gizmos.color = Color.green;
            }
            Gizmos.DrawLine(relativePos, to);
        }
    }

}
[System.Serializable]
public class GroundCheckSensor
{
    public Vector2 Direcion;
    public Vector2 Offset;
    public float Range;
}