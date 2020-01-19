using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour {

    private DoorView doorView;
    private DoorModel doorModel;

    private void Start() {
        doorView = GetComponent<DoorView>();
        doorModel = GetComponent<DoorModel>();
    }

    public void OpenDoor(KeyCollector keyCollector) {
        if (!doorModel.IsOpened) {
            doorModel.OpenDoor(keyCollector);
        }
    }

    public void CloseDoor() {
        if(doorModel.IsOpened) {
            doorModel.CloseDoor();
        }
    }

}
