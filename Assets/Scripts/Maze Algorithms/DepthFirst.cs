using System.Collections.Generic;
using System;

public class DepthFirst {

    public static Grid GenerateMaze(Grid grid) {
        Cell current = grid.grid[0, 0];
        Stack<Cell> stack = new Stack<Cell>();
        do {
            current.visited = true;

            var next = grid.GetRandomNeighbor(current);

            if (next != null) {
                next.visited = true;

                stack.Push(current);

                grid.RemoveWalls(current, next);

                current = next;
            } else if (stack.Count > 0) {
                current = stack.Pop();
            }
        } while (stack.Count > 0);

        return grid;
    }

}
