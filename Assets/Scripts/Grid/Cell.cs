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

    public bool[] walls;

    /// <summary>
    /// Constructor for the cell, sets the positions and marks it unvisited
    /// </summary>
    /// <param name="x">The x position of the cell</param>
    /// <param name="y">The y position of the cell</param>
    public Cell(int x, int y) {
        this.x = x;
        this.y = y;

        visited = false;
        walls = new bool[] { true, true, true, true };

    }

    public void Reset() {
        visited = false;
        walls = new bool[] { true, true, true, true };
    }

}

public enum Wall {
    Top,
    Bottom,
    Right,
    Left
}
