using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorView : MonoBehaviour {

    /// <summary>
    /// Reference to the model
    /// </summary>
    private DoorModel doorModel;

    /// <summary>
    /// Reference to the controller
    /// </summary>
    private DoorController doorController;

    /// <summary>
    /// Reference to the sprite renderer
    /// </summary>
    [SerializeField] 
    private SpriteRenderer spriteRendererFrame;

    /// <summary>
    /// The sprite of the open door
    /// </summary>
    [SerializeField] 
    private Sprite OpenedSprite;

    /// <summary>
    /// The sprite of the closed door
    /// </summary>
    [SerializeField] 
    private Sprite ClosedSprite;

    /// <summary>
    /// Gets references
    /// </summary>
    private void Start() { 
        doorModel = GetComponent<DoorModel>();
        doorController = GetComponent<DoorController>();

        doorModel.Opened += OnDoorOpened;
        doorModel.Closed += OnDoorClosed;
    }

    /// <summary>
    /// When the door opens the sprite gets updated
    /// </summary>
    private void OnDoorOpened() {
        spriteRendererFrame.sprite = OpenedSprite;
    }

    /// <summary>
    /// When the door gets closed the sprite gets updated
    /// </summary>
    private void OnDoorClosed() {
        spriteRendererFrame.sprite = ClosedSprite;
    }

    /// <summary>
    /// On collision the door tries to get opened
    /// </summary>
    /// <param name="collider"></param>
    private void OnTriggerEnter2D(Collider2D collider) {
        KeyCollector collector;

        if(collider.TryGetComponent(out collector)) {
            doorController.TryOpenDoor(collector);
        }
    }

}
