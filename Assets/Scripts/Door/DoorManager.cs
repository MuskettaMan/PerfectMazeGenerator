using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour {

    /// <summary>
    /// Gameobject prefab of the door
    /// </summary>
    [SerializeField] 
    private DoorModel doorPrefab;

    /// <summary>
    /// Reference to the game manager
    /// </summary>
    private GameManager gameManager;

    /// <summary>
    /// Reference to the grid manager
    /// </summary>
    private GridManager gridManager;

    /// <summary>
    /// The instance of the current door
    /// </summary>
    private DoorModel doorInstance;

    /// <summary>
    /// Reference to the controller of the instiated door
    /// </summary>
    private DoorController doorController;

    /// <summary>
    /// Offset of the door
    /// </summary>
    private readonly Vector2 offset = new Vector2(0, 1.5f);

    /// <summary>
    /// Public accessor for the door
    /// </summary>
    public DoorModel Door => doorInstance;

    private void Start() {
        // Setup door instance
        doorInstance = Instantiate(doorPrefab, transform);
        doorController = doorInstance.GetComponent<DoorController>();
        doorInstance.gameObject.SetActive(false);

        // Get managers
        gridManager = GridManager.Instance;
        gameManager = FindObjectOfType<GameManager>();

        gridManager.gridGenerated += OnGridGenerated;
    }

    /// <summary>
    /// When a grid gets generated sets a door on top
    /// </summary>
    /// <param name="grid"></param>
    private void OnGridGenerated(Grid grid) {
        GridGraphic gridGraphic = gridManager.GetGridGraphic();

        int randomColumn = Random.Range(2, gridManager.GridSize.x - 2);

        Vector3 pos = gridGraphic.GetCells()[randomColumn, gridManager.GridSize.y - 1].transform.position;

        doorInstance.transform.position = pos + (Vector3)offset;
        doorInstance.KeyAmountNeeded = gameManager.GetTotalKeys();
        doorController.CloseDoor();
        doorInstance.gameObject.SetActive(true);
    }

}
