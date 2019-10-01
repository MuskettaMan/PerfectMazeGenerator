using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MazeUtil {

    public static Grid GenerateDepthFirst(Grid grid) {
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

    public static Grid GeneratePrim(Grid grid) {
        
        Cell startCell = grid.grid[0, 0];
        HashSet<Cell> pathSet = new HashSet<Cell>();
        pathSet.Add(startCell);

        while (pathSet.Count > 0) {
            int r = Random.Range(0, pathSet.Count);
            var cell = pathSet.ElementAt(r);
            pathSet.Remove(cell);
            cell.visited = true;

            var neighbors = grid.GetAllVisitedNeighbors(cell);
            if (neighbors.Length > 0) {
                int rand = Random.Range(0, neighbors.Length);
                grid.RemoveWalls(cell, neighbors[rand]); 
            }

            var unvisitedNeighbors = grid.GetAllUnvisitedNeighbors(cell);
            for (int i = 0; i < unvisitedNeighbors.Length; i++) {
                pathSet.Add(unvisitedNeighbors[i]);
            }

        }

        return grid;
    }

}
