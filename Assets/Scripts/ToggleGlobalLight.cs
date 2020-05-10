using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Experimental.Rendering.LWRP;

public class ToggleGlobalLight : MonoBehaviour {

    private UnityEngine.Experimental.Rendering.Universal.Light2D light;

    [SerializeField] private float softIntensity = 0.03f;
    [SerializeField] private float hardIntensity = 0.5f;

    private void Start() {
        light = GetComponent<UnityEngine.Experimental.Rendering.Universal.Light2D>();
    }

    public void OnToggleChanged(bool value) {
        light.intensity = value ? hardIntensity : softIntensity;

    }

}
