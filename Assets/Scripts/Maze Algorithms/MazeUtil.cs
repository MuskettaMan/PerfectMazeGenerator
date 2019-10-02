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

    public static Grid GenerateBinaryTree(Grid grid) {

        List<Cell> neighbors = new List<Cell>();

        for (int x = 0; x < grid.width; x++) {
            for (int y = 0; y < grid.height; y++) {
                neighbors.Clear();
                if (x > 0) {
                    neighbors.Add(grid.grid[x - 1, y]);
                }

                if (y > 0) {
                    neighbors.Add(grid.grid[x, y - 1]);
                }

                if (neighbors.Count == 0) {
                    continue;
                }

                int r = Random.Range(0, neighbors.Count);
                grid.RemoveWalls(grid.grid[x, y], neighbors[r]);
            }
        }

        return grid;
    }

    public static Grid GenerateSideWinder(Grid grid) {
        for (int x = 0; x + 1 < grid.width; ++x) {
            grid.RemoveWalls(grid.grid[x, 0], grid.grid[x + 1, 0]);
        }

        for (int y = 1; y < grid.height; ++y) {
            HashSet<Cell> runSet = new HashSet<Cell>();

            for (int x = 0; x < grid.width; ++x) {
                runSet.Add(grid.grid[x, y]);

                if ((x + 1) < grid.width && Mathf.RoundToInt(Random.value) % 2 == 1) {
                    grid.RemoveWalls(grid.grid[x, y], grid.grid[x + 1, y]);
                } else {
                    Cell cell = runSet.ElementAt(Random.Range(0, runSet.Count));
                    grid.RemoveWalls(cell, grid.grid[cell.x, cell.y - 1]);

                    runSet.Clear();
                }

            }
        }

        return grid;
    }

    public static Grid GenerateKruskal(Grid grid) {

        HashSet<Wall> edges = CalculateInsideEdges(grid);

        Dictionary<Cell, int> bucketCells = new Dictionary<Cell, int>();
        for (int x = 0, i = 0; x < grid.width; x++) {
            for (int y = 0; y < grid.height; y++, i++) {
                bucketCells[grid.grid[x, y]] = i;
            }
        }

        while (edges.Count > 0) {
            Wall edge = edges.ElementAt(Random.Range(0, edges.Count));
            edges.Remove(edge);

            if (bucketCells[edge.first] != bucketCells[edge.second]) {
                grid.RemoveWalls(edge.first, edge.second);
                int id = bucketCells[edge.second];
                //bucketCells[edge.second] = bucketCells[edge.first];

                foreach (var kvp in bucketCells) {
                    if (kvp.Value == id) {
                        bucketCells[kvp.Key] = id;
                    }
                }
            } 
        }

        return grid;
    }

    /// <summary>
    /// Get a reference to all edges in the grid excluding the outermost edges
    /// </summary>
    /// <param name="grid">The grid you want edges of</param>
    /// <returns>Returns a reference to all inside walls</returns>
    private static HashSet<Wall> CalculateInsideEdges(Grid grid) {
        HashSet<Wall> edges = new HashSet<Wall>();
        for (int x = 0; x < grid.width; x++) {
            for (int y = 0; y < grid.height; y++) {
                for (int i = 0; i < grid.grid[x, y].walls.Length; i++) {
                    if (x == 0 && i == (int)Walls.Left)
                        continue;

                    if (y == 0 && i == (int)Walls.Bottom)
                        continue;

                    if (x == grid.width - 1 && i == (int)Walls.Right)
                        continue;

                    if (y == grid.height - 1 && i == (int)Walls.Top)
                        continue;

                    edges.Add(grid.grid[x, y].walls[i]);
                }
            }
        }

        return edges;
    }

}
