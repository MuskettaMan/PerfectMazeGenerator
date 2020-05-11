using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class KeyCollector : MonoBehaviour {

    private int keyAmount = 0;

    public Action<Key> keyPickedUp;
    public Action<int> keyAmountChanged;

    private void Start() {
        GridManager.Instance.gridGenerated += OnGridGenerated;
    }

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
            keyAmountChanged?.Invoke(keyAmount);

            keyPickedUp?.Invoke(key);
        }
    }

    private void OnGridGenerated(Grid grid) {
        keyAmount = 0;
        keyAmountChanged?.Invoke(keyAmount);
    }

}
