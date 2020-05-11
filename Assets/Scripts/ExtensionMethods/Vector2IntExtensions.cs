using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Vector2IntExtensions {
    
    /// <summary>
    /// Vector2 to Vector 2 int
    /// <para>Uses truncation</para>
    /// </summary>
    /// <param name="vector2Int">Extension of</param>
    /// <param name="vector">Vector2 you wish to convert</param>
    /// <returns>Truncated Vector2</returns>
    public static Vector2Int FromVector2(this Vector2Int vector2Int, Vector2 vector) {
        vector2Int.x = (int)vector.x;
        vector2Int.y = (int)vector.y;

        return vector2Int;
    }

}
