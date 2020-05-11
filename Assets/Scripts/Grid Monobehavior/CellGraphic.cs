using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellGraphic : MonoBehaviour {

    /// <summary>
    /// Reference to its cell
    /// </summary>
    public Cell cell;

    /// <summary>
    /// Reference to transform of the walls
    /// </summary>
    [SerializeField] 
    private Transform[] walls;

    /// <summary>
    /// The different possible background sprites
    /// </summary>
    [SerializeField] 
    private Sprite[] backgroundSprites;

    /// <summary>
    /// The different wall sprites
    /// </summary>
    [SerializeField] 
    private Sprite[] wallSprites;

    /// <summary>
    /// The different mid wall sprites
    /// </summary>
    [SerializeField] 
    private Sprite[] midWallSprites;

    /// <summary>
    /// Reference to the transform of the mid wall
    /// </summary>
    [SerializeField] 
    private Transform midWall;

    /// <summary>
    /// Walls of the mid wall
    /// </summary>
    [SerializeField] 
    private Transform[] midWallWalls;

    /// <summary>
    /// Prefab of the horizontal wall
    /// </summary>
    [SerializeField] 
    private Transform horiztonalWall;

    /// <summary>
    /// Prefab of the vertical wall
    /// </summary>
    [SerializeField] 
    private Transform verticalWall;

    /// <summary>
    /// Reference to the sprite renderer
    /// </summary>
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
