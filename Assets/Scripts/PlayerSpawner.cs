using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour {

    [SerializeField] private GridManager gridManager;
    [SerializeField] private GridGraphic gridGraphic;

    /// <summary>
    /// Set dependencies
    /// </summary>
    private void Start() {
        gridManager.gridGenerated += OnMazeGenerated;
    }

    /// <summary>
    /// Plot the player when the maze is generated
    /// </summary>
    private void OnMazeGenerated() {
        StartCoroutine(PlotPlayer());
    }

    /// <summary>
    /// Plot the player in the bottom left corner
    /// </summary>
    /// <returns>Wait till end frame</returns>
    private IEnumerator PlotPlayer() {
        if (gridGraphic.GetCells() == null) { // Wait a frame if the gameobjects haven't been created yet
            yield return null;
        }

        transform.position = gridGraphic.GetCells()[0, 0].transform.position;
    }

}
