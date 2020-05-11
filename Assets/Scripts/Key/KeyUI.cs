using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KeyUI : MonoBehaviour {
    
    [SerializeField] 
    private KeyCollector keyCollector;

    [SerializeField] 
    private GameManager gameManager;

    [SerializeField] 
    private TextMeshProUGUI numeratorText;

    [SerializeField] 
    private TextMeshProUGUI denominatorText;

    [SerializeField] 
    private Image circleBackdropImage;

    [SerializeField] 
    private Image keyImage;

    [SerializeField] 
    private float animationSpeed = 0.5f;

    [SerializeField]
    private LeanTweenType tweenType;

    private float targetFillAmount;
    private float currentFillAmount;

    private void Start() {
        keyCollector.keyAmountChanged += OnKeyAmountChanged;
    }

    private void AnimateFillAmount() {
        LeanTween.cancel(keyImage.gameObject);
        LeanTween.value(keyImage.gameObject, (float val) => keyImage.fillAmount = val, keyImage.fillAmount, targetFillAmount, animationSpeed).setEase(tweenType);

        LeanTween.cancel(circleBackdropImage.gameObject);
        LeanTween.value(circleBackdropImage.gameObject, (float val) => circleBackdropImage.fillAmount = val, circleBackdropImage.fillAmount, targetFillAmount, animationSpeed).setEase(tweenType);
    }

    private void OnKeyAmountChanged(int amount) {
        denominatorText.text = gameManager.GetTotalKeys().ToString();
        numeratorText.text = keyCollector.KeyAmount.ToString();

        targetFillAmount = (float)keyCollector.KeyAmount / (float)gameManager.GetTotalKeys();

        AnimateFillAmount();
    }

}
