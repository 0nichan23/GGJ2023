using System.Collections.Generic;
using UnityEngine;

public class ProximitySensor<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] protected float checkRadius;
    [SerializeField] protected LayerMask targetLayer;

    public T[] GetTargetsInProximity()//without line of sight
    {
        Collider2D[] foundColliders = Physics2D.OverlapCircleAll(transform.position, checkRadius, targetLayer);
        List<T> foundObjects = new List<T>();
        foreach (var item in foundColliders)
        {
            T obj = item.GetComponent<T>();
            if (!ReferenceEquals(obj, null))
            {
                foundObjects.Add(obj);
            }
        }
        return foundObjects.ToArray();
    }
    public T[] GetLegalTargets()//with line of sight
    {
        T[] targets = GetTargetsInProximity();
        if (targets.Length == 0)
        {
            return null;
        }
        List<T> legalTargets = new List<T>();

        foreach (var item in targets)
        {
            Vector2 dir = item.transform.position - transform.position;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, checkRadius, targetLayer);
            if (!ReferenceEquals(hit.collider, null))
            {
                if (item.transform.position == hit.collider.transform.position)
                {
                    legalTargets.Add(item);
                }
            }
          
        }
        return legalTargets.ToArray();
    }

    public T GetClosestLegalTarget()//closest with line of sight
    {
        T[] legalTargets = GetLegalTargets();
        if (ReferenceEquals(legalTargets, null) || legalTargets.Length == 0)
        {
            return null;
        }
        T closestPoint = legalTargets[0];
        for (int i = 0; i < legalTargets.Length; i++)
        {
            float dist = Utils.Distance(closestPoint.transform.position, transform.position);
            if (Utils.Distance(legalTargets[i].transform.position, transform.position) < dist)
            {
                closestPoint = legalTargets[i];
            }
        }
        return closestPoint;
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, checkRadius);
        if (!ReferenceEquals(GetClosestLegalTarget(), null))
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, GetClosestLegalTarget().transform.position);
        }
    }

}
