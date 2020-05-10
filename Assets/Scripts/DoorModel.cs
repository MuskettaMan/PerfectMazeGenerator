using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DoorModel : MonoBehaviour {

    /// <summary>
    /// Whether the door is open or not
    /// </summary>
    public bool IsOpened { get; set; }

    [SerializeField, Tooltip("The amount of keys needed to open the door")] 
    private int keyAmountNeeded;

    /// <summary>
    /// The amount of keys needed to open the door
    /// </summary>
    public int KeyAmountNeeded => keyAmountNeeded;

    /// <summary>
    /// Gets called when the door gets opened
    /// </summary>
    public event Action Opened;

    /// <summary>
    /// Gets called when the door gets closed
    /// </summary>
    public event Action Closed;

    /// <summary>
    /// Checks the if the current key collector has enough keys. If yes, then it opens the door
    /// </summary>
    /// <param name="collecter"></param>
    public void TryOpenDoor(KeyCollector collecter) 
    {
        if (collecter.KeyAmount >= keyAmountNeeded) 
        {
            Opened?.Invoke();
            IsOpened = true;
        }
    }

    /// <summary>
    /// Closes the door
    /// </summary>
    public void CloseDoor() 
    {
        Closed?.Invoke();
        IsOpened = false;
    }

}
