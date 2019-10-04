using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    [SerializeField] private GridManager gridManager;
    [SerializeField] private GridGraphic gridGraphic;

    private new Camera camera;

    /// <summary>
    /// The target size you want the camera to go to
    /// </summary>
    private float targetSize;

    /// <summary>
    /// Speed you want the camera to move
    /// </summary>
    [SerializeField] private float speed = 5f;

    /// <summary>
    /// Padding from the edge of the screen
    /// </summary>
    [SerializeField] private float padding = 1f;

    private void Start() {
        camera = GetComponent<Camera>();
        gridManager.resizedGrid += OnGridResized;

        SetCameraSize();
    }

    /// <summary>
    /// Ease the camera into the target size
    /// </summary>
    private void Update() {
        camera.orthographicSize = Mathf.Lerp(camera.orthographicSize, targetSize, Time.deltaTime * speed);
    }

    /// <summary>
    /// Calculate the target size
    /// </summary>
    private void SetCameraSize() {
        targetSize = (float)gridManager.GridSize.y / 2;
        targetSize += gridGraphic.GetPadding() * gridManager.GridSize.y / 2;
        targetSize += padding;
    }

    private void OnGridResized(int amount) {
        SetCameraSize();
    }

}
