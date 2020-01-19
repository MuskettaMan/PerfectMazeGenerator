using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour {

    [SerializeField] private GameObject doorPrefab;
    private GridManager gridManager;

    private GameObject doorInstance;
    [SerializeField] private Vector2 offset;

    private void Start() {
        gridManager = GridManager.Instance;

        gridManager.gridGenerated += OnGridGenerated;
    }

    private void OnGridGenerated(Grid grid) {
        GridGraphic gridGraphic = gridManager.GetGridGraphic();

        int randomColumn = Random.Range(2, gridManager.GridSize.x - 2);

        Vector3 pos = gridGraphic.GetCells()[randomColumn, gridManager.GridSize.y - 1].transform.position;

        if(!doorInstance) {
            doorInstance = Instantiate(doorPrefab, transform);
            doorInstance.SetActive(false);
        }

        doorInstance.transform.position = pos + (Vector3)offset;
        doorInstance.SetActive(true);
    }

}
