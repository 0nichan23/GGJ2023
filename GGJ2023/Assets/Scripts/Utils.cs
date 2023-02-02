using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class Utils
{
    public static T GetRandom<T>(this IEnumerable<T> ts)
        => ts.ElementAt(Random.Range(0, ts.Count()));

    public static bool IsOnGround(this Transform t)
    {
        throw new System.Exception("not implemented");
    }
}
