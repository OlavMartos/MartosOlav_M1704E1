using UnityEngine;

public static class Calculator
{
    public static float distance = 0.523f;
    public static int length = 8;

    /// <summary>
    /// Get the game position of the item selected in the matrix
    /// </summary>
    /// <param name="point">The matrix points of the object</param>
    /// <returns>A Vector3 as position</returns>
    public static Vector3 GetPositionFromMatrix(int[] point)
    {
        return new Vector3(-(length - 1f) * distance + point[1] * 2f * distance,
            (length - 1f) * distance - point[0] * 2f * distance, 0);
    }

    /// <summary>
    /// Check the distance of the path to the objective
    /// </summary>
    /// <param name="point">Point of the path selected by the ai</param>
    /// <param name="obj">The objective to arrive</param>
    /// <returns>The heuristic of the point</returns>
    public static float CheckDistanceToObj(int[] point, int[] obj)
    {
        return Vector3.Distance(GetPositionFromMatrix(obj), GetPositionFromMatrix(point));
    }
}
