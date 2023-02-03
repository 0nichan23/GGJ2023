using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class Utils
{
    public static T GetRandom<T>(this IEnumerable<T> ts)
        => ts.ElementAt(Random.Range(0, ts.Count()));

    public static bool IsOnGround(this Transform t, float legsHeight = 1, int layerMask = ~0)
    {
        var hit = Physics2D.Raycast(t.position, Vector2.down, legsHeight, layerMask);
        return hit.collider != null;
    }

    public static float Distance(Vector3 pointA, Vector3 pointB)
        => (pointA - pointB).magnitude;

    public static bool Is<T>(this Component component)
        => component.GetComponent<T>() != null;

    public static void Restart(this ParticleSystem ps)
    {
        ps.Clear();
        ps.gameObject.SetActive(true);
        ps.Play();
    }

    public static void ForAll<T>(System.Action<T> action) where T : Object
    {
        var ts = Object.FindObjectsOfType<T>();
        foreach (var t in ts)
        {
            action(t);
        }
    }
}
