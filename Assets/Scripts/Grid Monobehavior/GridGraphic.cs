using UnityEngine;
using System.Collections;

[SelectionBase]
public class GridGraphic : MonoBehaviour {
    
    /// <summary>
    /// Distance between cells
    /// </summary>
    [SerializeField] private float padding = 0.0f;
    [SerializeField] private CellGraphic cellGraphicPrefab;
    [SerializeField] private GridManager gridManager;

    private Grid grid;
    private CellGraphic[,] objects;
    private Vector2Int gridSize;

    private void Start() {
        grid = gridManager.grid;

        Resize();
    }

    public void Resize() {
        grid = gridManager.grid;
        gridSize = gridManager.GridSize;

        if (objects != null) {
            for (int i = 0; i < objects.GetLength(0); i++) {
                for (int j = 0; j < objects.GetLength(1); j++) {
                    Destroy(objects[i, j].gameObject);
                }
            }
        }

        objects = new CellGraphic[gridSize.x, gridSize.y];

        for (int i = 0; i < grid.width; i++) {
            for (int j = 0; j < grid.height; j++) {
                var pos = new Vector2(grid.grid[i, j].x, grid.grid[i, j].y);

                // Center grid for even and uneven numbers on the x axis
                if (grid.height % 2 == 0) {
                    pos.x += 0.5f;
                }

                // Center grid for even and uneven numbers on the y axis
                if (grid.height % 2 == 0) {
                    pos.y += 0.5f;
                }

                // Center the spawned objects
                pos.x -= grid.width / 2;
                pos.y -= grid.height / 2;

                // Apply scale to object position
                var scale = cellGraphicPrefab.transform.localScale;
                pos.x *= scale.x;
                pos.y *= scale.y;

                // Applies padding between cells
                pos.x *= padding + 1;
                pos.y *= padding + 1;

                CellGraphic clone = Instantiate(cellGraphicPrefab, new Vector2(pos.x, pos.y), Quaternion.identity, transform);
                clone.name = "Cell: " + grid.grid[i, j].x + " - " + grid.grid[i, j].y;
                clone.cell = grid.grid[i, j];
                objects[i, j] = clone;
            }
        }
    }

    public float GetPadding() {
        return padding;
    }

}
