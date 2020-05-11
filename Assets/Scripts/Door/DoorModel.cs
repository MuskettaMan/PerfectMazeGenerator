using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DoorModel : MonoBehaviour {

    private bool isOpened = false;

    /// <summary>
    /// Whether the door is open or not
    /// </summary>
    public bool IsOpened {
        get {
            return isOpened;
        }

        private set {
            isOpened = value;
        }
    }

    /// <summary>
    /// The amount of keys that are needed to open the door
    /// </summary>
    public int KeyAmountNeeded { get; set; }

    /// <summary>
    /// Gets called when the door opens
    /// </summary>
    public event Action Opened;

    /// <summary>
    /// Gets called when the door closes
    /// </summary>
    public event Action Closed;

    /// <summary>
    /// If enough keys have been collected the door opens
    /// </summary>
    /// <param name="collecter"></param>
    public bool TryOpenDoor(KeyCollector collecter) {
        if (collecter.KeyAmount >= KeyAmountNeeded) {
            Opened?.Invoke();
            IsOpened = true;
            return true;
        }

        return false;
    }

    /// <summary>
    /// Closes the door
    /// </summary>
    public void CloseDoor() {
        Closed?.Invoke();
        IsOpened = false;
    }
}
