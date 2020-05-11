using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour {

    /// <summary>
    /// Reference to the door view
    /// </summary>
    private DoorView doorView;

    /// <summary>
    /// Reference to the door model
    /// </summary>
    private DoorModel doorModel;

    /// <summary>
    /// Get references
    /// </summary>
    private void Awake() {
        doorView = GetComponent<DoorView>();
        doorModel = GetComponent<DoorModel>();
    }

    /// <summary>
    /// Tries to open the door if enough keys have been collected
    /// </summary>
    /// <param name="keyCollector"></param>
    public bool TryOpenDoor(KeyCollector keyCollector) {
        if (!doorModel.IsOpened) {
            doorModel.TryOpenDoor(keyCollector);
            return true;
        }

        return false;
    }

    /// <summary>
    /// Closes the door
    /// </summary>
    public void CloseDoor() {
        if(doorModel.IsOpened) {
            doorModel.CloseDoor();
        }
    }

}
