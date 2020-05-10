using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DoorModel : MonoBehaviour {

    private bool isOpened = false;

    public bool IsOpened {
        get {
            return isOpened;
        }

        private set {
            isOpened = value;
        }
    }

    [HideInInspector] public int keyAmountNeeded;

    public Action DoorOpened;
    public Action DoorClosed;

    public void OpenDoor(KeyCollector collecter) {
        if (collecter.KeyAmount >= keyAmountNeeded) {
            DoorOpened?.Invoke();
            IsOpened = true;
        }
        
    }

    public void CloseDoor() {
        DoorClosed?.Invoke();
        IsOpened = false;
    }

    public int GetKeyAmountNeeded() {
        return keyAmountNeeded;
    }

    public void NextLevel() {
        GridManager.Instance.ResizeGrid(1);
    }

}
