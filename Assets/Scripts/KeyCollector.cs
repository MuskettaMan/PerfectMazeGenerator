using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class KeyCollector : MonoBehaviour {

    private int keyAmount = 0; // Implement finding keys and adding them to your total

    public Action<Key> keyPickedUp;

    public int KeyAmount {
        get {
            return keyAmount;
        }

        set {
            keyAmount = value;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        Key key;
        
        if(collision.gameObject.TryGetComponent(out key)) {
            keyAmount += (int)key.type;

            keyPickedUp?.Invoke(key);
        }
    }

}
