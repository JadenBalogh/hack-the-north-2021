using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils
{
    ///<summary>Returns whether two transforms are within a given distance of each other.</summary>
    public static bool InRange(Transform t1, Transform t2, float range) => InRange(t1.position, t2.position, range);

    ///<summary>Returns whether two vectors are within a given distance of each other.</summary>
    public static bool InRange(Vector2 p1, Vector2 p2, float range)
    {
        return Vector2.SqrMagnitude(p1 - p2) <= range * range;
    }
}
