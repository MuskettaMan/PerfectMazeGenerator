using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellGraphic : MonoBehaviour {

    public Cell cell;

    [SerializeField] private Transform[] walls;
    [SerializeField] private Sprite[] backgroundSprites;
    [SerializeField] private Sprite[] wallSprites;

    /// <summary>
    /// SpriteRenderer for the walls
    /// </summary>
    [SerializeField] private Transform horiztonalWall;
    [SerializeField] private Transform verticalWall;

    private SpriteRenderer spriteRenderer;

    private void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();

        foreach (Transform wall in walls) {
            wall.GetComponent<SpriteRenderer>().sprite = wallSprites[Random.Range(0, wallSprites.Length)];
        }

        spriteRenderer.sprite = backgroundSprites[Random.Range(0, backgroundSprites.Length)];
    }

    private void Update() {

        for (int i = 0; i < cell.walls.Length; i++) {
            walls[i].gameObject.SetActive(cell.walls[i].enabled);
        }
    }
    

}
