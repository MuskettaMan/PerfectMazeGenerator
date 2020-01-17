using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Vector2IntExtensions {
    
    public static Vector2Int FromVector2(this Vector2Int vector2Int, Vector2 vector) {
        vector2Int.x = (int)vector.x;
        vector2Int.y = (int)vector.y;

        return vector2Int;
    }

}
