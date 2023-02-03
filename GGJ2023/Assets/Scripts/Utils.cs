using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class Utils
{
    public static T GetRandom<T>(this IEnumerable<T> ts)
        => ts.ElementAt(Random.Range(0, ts.Count()));

    public static bool IsOnGround(this Transform t, float legsHeight = 1)
    {
        var hit = Physics2D.Raycast(t.position, Vector2.down, legsHeight);
        return hit.collider != null;
    }

    public static float CalcRange(Vector3 pointA, Vector3 pointB)
    {
        return (pointA - pointB).magnitude;
    }

}
