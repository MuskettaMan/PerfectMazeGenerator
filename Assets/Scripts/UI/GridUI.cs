using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GridUI : MonoBehaviour {

    [SerializeField] private GridManager gridManager;

    public void RegenerateMaze() {
        gridManager.Reset();
    }

    public void IncreaseGrid() {
        gridManager.ResizeGrid(1);
    }

    public void DecreaseGrid() {
        gridManager.ResizeGrid(-1);
    }

    public void ChangeMazeType(TMP_Dropdown change) {
        gridManager.SetMazeType((MazeType)change.value);
    }

}
