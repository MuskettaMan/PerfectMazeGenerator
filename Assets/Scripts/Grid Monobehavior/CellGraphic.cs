using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellGraphic : MonoBehaviour {

    public Cell cell;

    [SerializeField] private Transform[] walls;
    
    /// <summary>
    /// SpriteRenderer for the walls
    /// </summary>
    [SerializeField] private Transform horiztonalWall;
    [SerializeField] private Transform verticalWall;
    
    [SerializeField] private Color visitedColor;
    [SerializeField] private Color notVisitedColor;

    private SpriteRenderer spriteRenderer;

    private void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update() {
        if (cell.visited) {
            spriteRenderer.color = visitedColor;
        } else {
            spriteRenderer.color = notVisitedColor;
        }

        for (int i = 0; i < cell.walls.Length; i++) {
            walls[i].gameObject.SetActive(cell.walls[i]);
        }
    }
    

}
