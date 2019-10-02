public delegate Grid MazeAlgorithm(Grid grid);

public enum MazeType {
    DepthFirst,
    Prims,
    BinaryTree,
    SideWinder,
    Kruskal
}