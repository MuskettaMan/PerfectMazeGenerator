using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GridUI : MonoBehaviour {

    [SerializeField] private GridManager gridManager;

    /// <summary>
    /// Regenerate the maze
    /// </summary>
    public void RegenerateMaze() {
        gridManager.Reset();
    }

    /// <summary>
    /// Increase grid size
    /// </summary>
    public void IncreaseGrid() {
        gridManager.ResizeGrid(1);
    }
    
    /// <summary>
    /// Decrease grid size
    /// </summary>
    public void DecreaseGrid() {
        gridManager.ResizeGrid(-1);
    }

    /// <summary>
    /// Change maze algorithm
    /// </summary>
    /// <param name="change">Drop down menu</param>
    public void ChangeMazeType(TMP_Dropdown change) {
        gridManager.SetMazeType((MazeType)change.value);
    }

}
