using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Boundaries
{
    private static float minX = -3f;
    private static float maxX = 3f;

    private static float minY = -5f;

    public static bool OutOfBounds(Transform target)
    {
        return OutOfBounds(target.position);
    }

    public static bool OutOfBounds(Vector3 position)
    {
        return !(position.x > minX && position.x < maxX && position.y > minY);
    }
}
