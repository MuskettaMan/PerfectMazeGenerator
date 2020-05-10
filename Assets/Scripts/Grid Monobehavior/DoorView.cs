using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorView : MonoBehaviour {

    private DoorModel doorModel;
    private DoorController doorController;

    [SerializeField] private SpriteRenderer spriteRendererFrame;

    [SerializeField] private Sprite OpenedSprite;
    [SerializeField] private Sprite ClosedSprite;

    private void Start() { 
        doorModel = GetComponent<DoorModel>();
        doorController = GetComponent<DoorController>();

        doorModel.DoorOpened += OnDoorOpened;
        doorModel.DoorClosed += OnDoorClosed;
    }

    private void OnDoorOpened() {
        spriteRendererFrame.sprite = OpenedSprite;
    }

    private void OnDoorClosed() {
        spriteRendererFrame.sprite = ClosedSprite;
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        KeyCollector collector;

        if(collider.TryGetComponent(out collector)) {
            doorController.OpenDoor(collector);
        }
    }

}
