using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellGraphic : MonoBehaviour {

    public Cell cell;

    [SerializeField] private Transform[] walls;
    [SerializeField] private Sprite[] sprites;

    /// <summary>
    /// SpriteRenderer for the walls
    /// </summary>
    [SerializeField] private Transform horiztonalWall;
    [SerializeField] private Transform verticalWall;

    private SpriteRenderer spriteRenderer;

    private void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();

        spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];
    }

    private void Update() {

        for (int i = 0; i < cell.walls.Length; i++) {
            walls[i].gameObject.SetActive(cell.walls[i]);
        }
    }
    

}
