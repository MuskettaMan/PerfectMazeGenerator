using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public enum CameraFollowType { Grid, Player }

    [SerializeField] private GridManager gridManager;
    [SerializeField] private GridGraphic gridGraphic;
    [SerializeField] private Transform player;
    [SerializeField] private float playerFollowCameraSize;
    [SerializeField] private CameraFollowType cameraFollowType;

    private new Camera camera;
    private Vector3 targetPosition;
    private Vector3 startPos;

    private bool switchType = true;

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

    private delegate void CameraFunction();
    private Dictionary<CameraFollowType, CameraFunction> CameraFollowPairs = new Dictionary<CameraFollowType, CameraFunction>();

    private void Start() {
        camera = GetComponent<Camera>();
        gridManager.resizedGrid += OnGridResized;

        startPos = transform.position;

        CameraFollowPairs.Add(CameraFollowType.Grid, SetCameraGrid);
        CameraFollowPairs.Add(CameraFollowType.Player, SetCameraPlayer);
    }

    /// <summary>
    /// Ease the camera into the target size
    /// </summary>
    private void Update() {
        if (Input.GetKeyDown(KeyCode.F)) {
            switchType = !switchType;
        }
        cameraFollowType = switchType ? CameraFollowType.Grid : CameraFollowType.Player;
        
        CameraFollowPairs[cameraFollowType].Invoke();

        var newSize = Mathf.Lerp(camera.orthographicSize, targetSize, Time.deltaTime * speed);
        var newPosition = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * speed);

        UpdateCamera(newSize, newPosition);
    }

    /// <summary>
    /// Update camera settings
    /// </summary>
    /// <param name="cameraSize">The new orthographic size of the camera</param>
    /// <param name="position">The new position of the camera</param>
    private void UpdateCamera(float cameraSize, Vector3 position) {
        transform.position = position;
        camera.orthographicSize = cameraSize;
    }
    
    /// <summary>
    /// Update parameters for grid view
    /// </summary>
    private void SetCameraGrid() {
        targetPosition = startPos;

        targetSize = (float)gridManager.GridSize.y / 2 + 1f;
        targetSize += gridGraphic.GetPadding() * gridManager.GridSize.y / 2;
        targetSize += padding;
        LeanTween.cancel(camera.gameObject);
        LeanTween.value(camera.gameObject, (float val) => camera.orthographicSize = val, camera.orthographicSize, targetSize, 0.4f).setEase(LeanTweenType.easeInOutSine);
    }

    /// <summary>
    /// Update parameters for player view
    /// </summary>
    private void SetCameraPlayer() {
        targetPosition = player.position;
        targetPosition.z = startPos.z;
        targetSize = playerFollowCameraSize;
    }

    private void OnGridResized(int amount) {
        
    }

}
