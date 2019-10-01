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

    /// <summary>
    /// Utility object with maze algorithms
    /// </summary>
    public MazeUtil mazeUtil { get; private set; }

    /// <summary>
    /// Array that stores all the available algorithms
    /// </summary>
    public MazeAlgorithm[] algorithms { get; private set; }

    /// <summary>
    /// The current maze algorithm that is being used
    /// </summary>
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

        algorithms = new MazeAlgorithm[] { MazeUtil.GeneratePrim };

        algorithms[(int)currentAlgorithm].Invoke(this);
    }

    /// <summary>
    /// Get a random cell on the grid
    /// </summary>
    /// <returns>Random cell</returns>
    public Cell GetRandomCell() {
        Cell cell = grid[Random.Range(0, width), Random.Range(0, height)];

        return cell;
    }

    /// <summary>
    /// Resize the grid
    /// </summary>
    /// <param name="width">The new width of the grid</param>
    /// <param name="height">The new height of the grid</param>
    public void ResizeGrid(int width, int height) {
        this.width = width;
        this.height = height;

        grid = new Cell[width, height];

        for (int x = 0; x < width; x++) {
            for (int y = 0; y < height; y++) {
                grid[x, y] = new Cell(x, y);
            }
        }

        algorithms[(int)currentAlgorithm].Invoke(this);
    }

    /// <summary>
    /// Is the given position inside the grid
    /// </summary>
    /// <param name="x">The x position you want to check</param>
    /// <param name="y">The y position you want to check</param>
    /// <returns>A boolean result</returns>
    public bool IsInside(int x, int y) {
        return x >= 0 && x < width && y >= 0 && y < height;
    }

    /// <summary>
    /// Returns a random neighbor that hasn't been visited
    /// </summary>
    /// <param name="cell">Cell you want a random neighbor off</param>
    /// <returns></returns>
    public Cell GetRandomNeighbor(Cell cell) {

        var neighbors = GetAllUnvisitedNeighbors(cell);
        
        // If there are any neighbors, return a random one
        if (neighbors.Length > 0) {
            int r = Mathf.FloorToInt(Random.Range(0, neighbors.Length));
            return neighbors[r];
        } else {
            // else return nothing
            return null;
        }
        
    }

    /// <summary>
    /// Get all the neighbors around a given cell
    /// </summary>
    /// <param name="cell">The cell you want all the neighbors of</param>
    /// <returns>Return an array of the neighbors</returns>
    public Cell[] GetAllNeighbors(Cell cell) {
        // List to store the neighbors
        List<Cell> neighbors = new List<Cell>();

        // Define the locations for all the neighbor directions
        var top = new Vector2Int(cell.x, cell.y + 1);
        var bottom = new Vector2Int(cell.x, cell.y - 1);
        var right = new Vector2Int(cell.x + 1, cell.y);
        var left = new Vector2Int(cell.x - 1, cell.y);
        //(!GetNeighbor(top).visited || !visited)
        // Check if the neighbor isn't null and hasn't been visited yet and then add it to list
        if (GetCell(top) != null) {
            neighbors.Add(GetCell(top));
        }

        if (GetCell(bottom) != null) {
            neighbors.Add(GetCell(bottom));
        }

        if (GetCell(right) != null) {
            neighbors.Add(GetCell(right));
        }

        if (GetCell(left) != null) {
            neighbors.Add(GetCell(left));
        }

        return neighbors.ToArray();
    }

    /// <summary>
    /// Get all the neighbors that haven't been visited yet
    /// </summary>
    /// <param name="cell">Cell you want the neighbors of</param>
    /// <returns>An array of all the unvisited neighbors</returns>
    public Cell[] GetAllUnvisitedNeighbors(Cell cell) {
        var neighbors = GetAllNeighbors(cell);
        List<Cell> newNeighbors = new List<Cell>();
        for (int i = 0; i < neighbors.Length; i++) {
            if (!neighbors[i].visited) {
                newNeighbors.Add(neighbors[i]);
            }
        }

        return newNeighbors.ToArray();
    }

    /// <summary>
    /// Get all the neighbors that have been visited
    /// </summary>
    /// <param name="cell">Cell you want the neighbors of</param>
    /// <returns>An array of all the visited neighbors</returns>
    public Cell[] GetAllVisitedNeighbors(Cell cell) {
        var neighbors = GetAllNeighbors(cell);
        List<Cell> newNeighbors = new List<Cell>();
        for (int i = 0; i < neighbors.Length; i++) {
            if (neighbors[i].visited) {
                newNeighbors.Add(neighbors[i]);
            }
        }

        return newNeighbors.ToArray();
    }

    /// <summary>
    /// Reset the grid
    /// </summary>
    public void Reset() {
        for (int x = 0; x < width; x++) {
            for (int y = 0; y < height; y++) {
                grid[x, y].Reset();
            }
        }
    }

    /// <summary>
    /// Get the cell at a Vector2Int position
    /// </summary>
    /// <param name="pos">Position you want the cell at</param>
    /// <returns>The cell at the position</returns>
    private Cell GetCell(Vector2Int pos) {

        if (IsInside(pos.x, pos.y)) {
            return grid[pos.x, pos.y];
        }

        return null;
    }

    /// <summary>
    /// Mark all the cells on the grid as visited
    /// </summary>
    public void MarkAllCellsAsVisited() {
        for (int i = 0; i < width; i++) {
            for (int j = 0; j < height; j++) {
                grid[i, j].visited = true;
            }
        }
    }

    /// <summary>
    /// Mark all the cells on the grid as unvisited
    /// </summary>
    public void MarkAllCellsAsUnVisited() {
        for (int i = 0; i < width; i++) {
            for (int j = 0; j < height; j++) {
                grid[i, j].visited = false;
            }
        }
    }

    /// <summary>
    /// Remove the walls between 2 cells (doesn't work if the 2 cells aren't connected / touching)
    /// </summary>
    /// <param name="a">Cell A</param>
    /// <param name="b">Cell B</param>
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

/// <summary>
/// Naming for the neighbors of a cell
/// </summary>
public enum CellNeighbors {
    Top,
    Bottom,
    Right,
    Left
}
