using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

/// <summary>
/// Controls how the camera moves and zooms
/// </summary>
public class CameraController : MonoBehaviour {

    /// <summary>
    /// Reference to the gridmanager
    /// </summary>
    [SerializeField] 
    private GridManager gridManager;

    /// <summary>
    /// Reference to the grid graphic
    /// </summary>
    [SerializeField] 
    private GridGraphic gridGraphic;

    /// <summary>
    /// Reference to the player
    /// </summary>
    [SerializeField] 
    private Transform player;

    /// <summary>
    /// Reference to the camera
    /// </summary>
    private new Camera camera;

    /// <summary>
    /// The target size you want the camera to go to
    /// </summary>
    private float targetSize;

    /// <summary>
    /// Speed you want the camera to move
    /// </summary>
    [SerializeField] private float speed = 0.5f;

    /// <summary>
    /// Padding from the edge of the screen
    /// </summary>
    [SerializeField] private float padding = 1f;

    private void Start() {
        camera = GetComponent<Camera>();
        gridManager.resizedGrid += OnGridResized;

        UpdateCamera();
    }

    /// <summary>
    /// Updates the camera to fit grid size
    /// And animates it to the new size
    /// </summary>
    private void UpdateCamera() {
        targetSize = (float)gridManager.GridSize.y / 2 + 1f;
        targetSize += gridGraphic.GetPadding() * gridManager.GridSize.y / 2;
        targetSize += padding;

        LeanTween.value(camera.gameObject, (float val) => {
            camera.orthographicSize = val;
        }, camera.orthographicSize, targetSize, speed).setEase(LeanTweenType.easeInOutSine);
    }

    /// <summary>
    /// Gets called when the grid resizes
    /// </summary>
    /// <param name="amount">By how much the grid is resized</param>
    private void OnGridResized(int amount) {
        UpdateCamera();
    }

}
