using System;
using UnityEngine;

public class GridManager : MonoBehaviour {

    /// <summary>
    /// Size of the grid
    /// </summary>
    [SerializeField] private Vector2Int gridSize;
    public Vector2Int GridSize { // Propery is linked to field so it's editable in the editor
        get {
            return gridSize;
        }
        private set {
            gridSize = value;
        }
    }

    /// <summary>
    /// Static instance for it self
    /// </summary>
    public static GridManager Instance {
        get; set; 
    }

    /// <summary>
    /// Is called when the grid is resized and the amount is passed with it
    /// </summary>
    public Action<int> resizedGrid;

    /// <summary>
    /// Whenever the grid gets generated
    /// </summary>
    public Action<Grid> gridGenerated;

    [SerializeField] private GridGraphic gridGraphic;
    [SerializeField] private int maxGridSize = 40;

    public Grid grid {
        get; private set;
    }

    private void Start() {
        grid = new Grid(gridSize.x, gridSize.y, MazeType.DepthFirst);
        gridGraphic.Display();
        gridGenerated?.Invoke(grid);
    }

    private void OnEnable() {
        if(Instance == null) {
            Instance = this;
        }
    }

    /// <summary>
    /// Set a new algorithm for the maze
    /// </summary>
    /// <param name="type"></param>
    public void SetMazeType(MazeType type) {
        grid.currentAlgorithm = type;
        Reset();
    }

    /// <summary>
    /// Reset the grid
    /// </summary>
    public void Reset() {
        grid.Reset();
        gridGraphic.Display();
        grid.algorithms[(int)grid.currentAlgorithm].Invoke(grid);
        gridGenerated?.Invoke(grid);
    }

    /// <summary>
    /// Resize the grid by an amount
    /// </summary>
    /// <param name="amount">With how much you want to resize</param>
    public void ResizeGrid(int amount) {
        if (gridSize.x + amount < 5 || gridSize.y + amount < 5 || gridSize.x + amount > maxGridSize || gridSize.y + amount > maxGridSize) {
            return;
        }

        grid.ResizeGrid(gridSize.x += amount, gridSize.y += amount);
        gridGraphic.Display();
        gridGenerated?.Invoke(grid);
        resizedGrid?.Invoke(amount);
    }

    /// <summary>
    /// Returns the class responsible for the gameobjects that are displaying the grid
    /// </summary>
    /// <returns></returns>
    public GridGraphic GetGridGraphic() {
        return gridGraphic;
    }

}
