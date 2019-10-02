public class Cell {

    /// <summary>
    /// The x position of the cell
    /// </summary>
    public int x { get; private set; }
    /// <summary>
    /// The y position of the cell
    /// </summary>
    public int y { get; private set; }

    /// <summary>
    /// Has te cell been visited
    /// </summary>
    public bool visited;

    public Wall[] walls;

    /// <summary>
    /// Constructor for the cell, sets the positions and marks it unvisited
    /// </summary>
    /// <param name="x">The x position of the cell</param>
    /// <param name="y">The y position of the cell</param>
    public Cell(int x, int y, Wall top, Wall bottom, Wall right, Wall left) {
        this.x = x;
        this.y = y;

        visited = false;
        walls = new Wall[] { top, bottom, right, left };

    }

    /// <summary>
    /// Reset the cell. Marks unvisited and sets the walls to true
    /// </summary>
    public void Reset() {
        visited = false;
        for (int i = 0; i < walls.Length; i++) {
            walls[i].enabled = true;
        }
    }

}

/// <summary>
/// Naming for the different sides of walls
/// </summary>
public enum Walls {
    Top,
    Bottom,
    Right,
    Left
}
