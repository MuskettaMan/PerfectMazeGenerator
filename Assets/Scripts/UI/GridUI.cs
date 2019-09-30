using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridUI : MonoBehaviour {

    [SerializeField] private GridManager gridManager;

    public void RegenerateMaze() {
        var grid = gridManager.grid;

        grid.Reset();
        grid.algorithms[(int)grid.currentAlgorithm].Invoke(grid);
    }

}
