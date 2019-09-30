using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    [SerializeField] private GridManager gridManager;
    [SerializeField] private GridGraphic gridGraphic;

    private Camera camera;

    private void Start() {
        camera = GetComponent<Camera>();

        float size = gridManager.GridSize.y / 2;
        size += gridGraphic.GetPadding() * gridManager.GridSize.y / 2;

        camera.orthographicSize = size;
    }

}
