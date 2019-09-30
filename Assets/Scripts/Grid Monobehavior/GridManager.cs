using System.Collections;
using System.Collections.Generic;
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

    public Grid grid {
        get; private set;
    }

    public DepthFirst depthFirst {
        get; private set;
    }

    private void Start() {
        grid = new Grid(gridSize.x, gridSize.y, MazeType.DepthFirst);
        depthFirst = grid.depthFirst;
    }

}
