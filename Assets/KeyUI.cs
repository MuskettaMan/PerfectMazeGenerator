using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KeyUI : MonoBehaviour {
    
    [SerializeField] private KeyCollector keyCollector;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private TextMeshProUGUI numeratorText;
    [SerializeField] private TextMeshProUGUI denominatorText;
    [SerializeField] private Image circleBackdropImage;
    [SerializeField] private Image keyImage;
    [SerializeField] private float transistionSpeed = 2;

    [SerializeField] private float targetFillAmount;
    [SerializeField] private float currentFillAmount;

    private void Start() {
        keyCollector.keyAmountChanged += OnKeyAmountChanged;
    }

    private void Update() {
        CalculateFillAmount();

        circleBackdropImage.fillAmount = currentFillAmount;
        keyImage.fillAmount = currentFillAmount;
    }

    private void CalculateFillAmount() {
        currentFillAmount = Mathf.Lerp(currentFillAmount, targetFillAmount, Time.deltaTime * transistionSpeed);
    }

    private void OnKeyAmountChanged(int amount) {
        denominatorText.text = gameManager.GetTotalKeys().ToString();
        numeratorText.text = keyCollector.KeyAmount.ToString();

        targetFillAmount = (float)keyCollector.KeyAmount / (float)gameManager.GetTotalKeys();
    }

}
