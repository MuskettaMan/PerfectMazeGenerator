using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    [SerializeField] private GridManager gridManager;
    [SerializeField] private GridGraphic gridGraphic;

    private Camera camera;

    private float targetSize;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float padding = 1f;

    private void Start() {
        camera = GetComponent<Camera>();
        gridManager.resizedGrid += OnGridResized;

        SetCameraSize();
    }

    private void Update() {
        camera.orthographicSize = Mathf.Lerp(camera.orthographicSize, targetSize, Time.deltaTime * speed);
    }

    private void SetCameraSize() {
        targetSize = (float)gridManager.GridSize.y / 2;
        targetSize += gridGraphic.GetPadding() * gridManager.GridSize.y / 2;
        targetSize += padding;
    }

    private void OnGridResized(int amount) {
        SetCameraSize();
    }

}
