using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleGameObjects : MonoBehaviour {

    [SerializeField] private GameObject objectA;
    [SerializeField] private GameObject objectB;

    private Toggle toggle;

    private void Start() {
        toggle = GetComponent<Toggle>();

        // Set both objects to definitive state in the start
        objectB.SetActive(false);
        objectA.SetActive(true);

    }

    private void Update() {

        bool value = toggle.isOn;

        // Turn both off so they won't be on at the same time for even a frame
        objectA.SetActive(false);
        objectB.SetActive(false);

        // Set objects to their new state
        objectA.SetActive(value);
        objectB.SetActive(!value);

    }

}
