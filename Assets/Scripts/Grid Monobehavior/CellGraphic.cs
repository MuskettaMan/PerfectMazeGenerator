using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellGraphic : MonoBehaviour {

    public Cell cell;

    [SerializeField] private Transform[] walls;
    [SerializeField] private Sprite[] backgroundSprites;
    [SerializeField] private Sprite[] wallSprites;
    [SerializeField] private Sprite[] midWallSprites;
    [SerializeField] private Transform midWall;
    [SerializeField] private Transform[] midWallWalls;
    [SerializeField] private Transform horiztonalWall;
    [SerializeField] private Transform verticalWall;

    private SpriteRenderer spriteRenderer;

    /// <summary>
    /// Set dependencies, get random walls and random floor sprite
    /// </summary>
    private void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();

        foreach (Transform wall in walls) {
            wall.GetComponent<SpriteRenderer>().sprite = wallSprites[Random.Range(0, wallSprites.Length)];
        }

        if(cell.y == GridManager.Instance.GridSize.y - 1) {
            midWall.GetComponent<SpriteRenderer>().sprite = midWallSprites[Random.Range(0, midWallSprites.Length)];
            midWall.gameObject.SetActive(true);
            walls[(int)Walls.Top].position += new Vector3(0, 1, 0);

            if (cell.x == 0) {
                midWallWalls[1].gameObject.SetActive(true);
            } else if (cell.x == GridManager.Instance.GridSize.x - 1) {
                midWallWalls[0].gameObject.SetActive(true);
            }

            
        }

        spriteRenderer.sprite = backgroundSprites[Random.Range(0, backgroundSprites.Length)];

        
    }

    /// <summary>
    /// Keep the walls updated with their enabled state
    /// </summary>
    private void Update() {

        for (int i = 0; i < cell.walls.Length; i++) {
            walls[i].gameObject.SetActive(cell.walls[i].enabled);
        }
    }
    

}
