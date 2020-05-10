using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour {

    private DoorView doorView;
    private DoorModel doorModel;

    private void Awake() {
        doorView = GetComponent<DoorView>();
        doorModel = GetComponent<DoorModel>();

        doorModel.DoorOpened += OnDoorOpened;
    }

    public void OpenDoor(KeyCollector keyCollector) {
        if (!doorModel.IsOpened) {
            doorModel.TryOpenDoor(keyCollector);
        }
    }

    public void CloseDoor() {
        if(doorModel.IsOpened) {
            doorModel.CloseDoor();
        }
    }

    private IEnumerator WaitForNextLevel() {
        yield return new WaitForSeconds(.25f);
        doorModel.NextLevel();
    }

    private void OnDoorOpened() {
        StartCoroutine(WaitForNextLevel());
    }

}
