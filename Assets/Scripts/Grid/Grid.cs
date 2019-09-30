using UnityEngine;
using System.Collections.Generic;

public class Grid {

    /// <summary>
    /// Width of the grid
    /// </summary>
    public int width { get; private set; }
    /// <summary>
    /// Height of the grid
    /// </summary>
    public int height { get; private set; }

    /// <summary>
    /// The 2D array containing all the cells
    /// </summary>
    public Cell[,] grid { get; private set; }

    public DepthFirst depthFirst { get; private set; }
    public MazeAlgorithm[] algorithms { get; private set; }
    public MazeType currentAlgorithm;

    /// <summary>
    /// Grid constructor, sets the width and the height and fills the <see cref="Grid.grid"/> array
    /// </summary>
    /// <param name="width">Width of the grid</param>
    /// <param name="height">Height of the grid</param>
    public Grid(int width, int height, MazeType type) {
        this.width = width;
        this.height = height;
        this.currentAlgorithm = type;

        grid = new Cell[width, height];

        for (int x = 0; x < width; x++) {
            for (int y = 0; y < height; y++) {
                grid[x, y] = new Cell(x, y);
            }
        }

        algorithms = new MazeAlgorithm[] { DepthFirst.GenerateMaze };

        algorithms[(int)currentAlgorithm].Invoke(this);
    }

    public bool IsInside(int x, int y) {
        return x >= 0 && x < width && y >= 0 && y < height;
    }

    /// <summary>
    /// Returns a random neighbor that hasn't been visited
    /// </summary>
    /// <param name="cell">Cell you want a random neighbor off</param>
    /// <returns></returns>
    public Cell GetRandomNeighbor(Cell cell) {

        // List to store the neighbors
        List<Cell> neighbors = new List<Cell>();

        // Define the locations for all the neighbor directions
        var top = new Vector2Int(cell.x, cell.y + 1);
        var bottom = new Vector2Int(cell.x, cell.y - 1);
        var right = new Vector2Int(cell.x + 1, cell.y);
        var left = new Vector2Int(cell.x - 1, cell.y);

        // Check if the neighbor isn't null and hasn't been visited yet and then add it to list
        if (GetNeighbor(top) != null && !GetNeighbor(top).visited)
            neighbors.Add(GetNeighbor(top));

        if (GetNeighbor(bottom) != null && !GetNeighbor(bottom).visited)
            neighbors.Add(GetNeighbor(bottom));

        if (GetNeighbor(right) != null && !GetNeighbor(right).visited)
            neighbors.Add(GetNeighbor(right));

        if (GetNeighbor(left) != null && !GetNeighbor(left).visited)
            neighbors.Add(GetNeighbor(left));

        // If there are any neighbors, return a random one
        if (neighbors.Count > 0) {
            int r = Mathf.FloorToInt(Random.Range(0, neighbors.Count));
            return neighbors[r];
        } else {
            // else return nothing
            return null;
        }
        
    }

    public void Reset() {
        for (int x = 0; x < width; x++) {
            for (int y = 0; y < height; y++) {
                grid[x, y].Reset();
            }
        }
    }

    private Cell GetNeighbor(Vector2Int pos) {

        if (IsInside(pos.x, pos.y)) {
            return grid[pos.x, pos.y];
        }

        return null;
    }

    public void RemoveWalls(Cell a, Cell b) {

        var x = a.x - b.x;
        if (x == 1) {
            a.walls[(int)Wall.Left] = false;
            b.walls[(int)Wall.Right] = false;
        } else if (x == -1) {
            a.walls[(int)Wall.Right] = false;
            b.walls[(int)Wall.Left] = false;
        }

        var y = a.y - b.y;
        if (y == 1) {
            a.walls[(int)Wall.Bottom] = false;
            b.walls[(int)Wall.Top] = false;
        } else if (y == -1) {
            a.walls[(int)Wall.Top] = false;
            b.walls[(int)Wall.Bottom] = false;
        }
    }

}

public enum CellNeighbors {
    Top,
    Bottom,
    Right,
    Left
}
