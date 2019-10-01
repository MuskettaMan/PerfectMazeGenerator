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

    public Action<int> resizedGrid;

    [SerializeField] private GridGraphic gridGraphic;
    [SerializeField] private int maxGridSize = 40;

    public Grid grid {
        get; private set;
    }

    public MazeUtil depthFirst {
        get; private set;
    }

    private void Start() {
        grid = new Grid(gridSize.x, gridSize.y, MazeType.DepthFirst);
        depthFirst = grid.mazeUtil;
    }

    public void SetMazeType(MazeType type) {
        grid.currentAlgorithm = type;
        Reset();
    }

    public void Reset() {
        grid.Reset();
        grid.algorithms[(int)grid.currentAlgorithm].Invoke(grid);
    }

    public void ResizeGrid(int amount) {
        if (gridSize.x + amount < 2 || gridSize.y + amount < 2 || gridSize.x + amount > maxGridSize || gridSize.y + amount > maxGridSize) {
            return;
        }

        grid.ResizeGrid(gridSize.x += amount, gridSize.y += amount);
        gridGraphic.Resize();
        resizedGrid?.Invoke(amount);
    }

}
