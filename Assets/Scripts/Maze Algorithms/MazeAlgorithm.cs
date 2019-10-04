/// <summary>
/// Delegate for every maze algorithm
/// </summary>
/// <param name="grid">Grid you want to generate a maze on</param>
/// <returns>Returns the grid with a maze generated on it</returns>
public delegate Grid MazeAlgorithm(Grid grid);

/// <summary>
/// Every type of maze algorithm
/// </summary>
public enum MazeType {
    DepthFirst,
    Prims,
    BinaryTree,
    SideWinder,
    Kruskal
}