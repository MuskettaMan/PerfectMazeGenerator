using UnityEngine;
using System.Collections.Generic;

public class Key : MonoBehaviour {
    public enum KeyType { Gold = 2, Silver = 1 }

    public KeyType type;
    [SerializeField] private Sprite goldSprite;
    [SerializeField] private Sprite silverSprite;

    public Vector2 gridPosition;

    private SpriteRenderer spriteRenderer;

    private delegate void KeyTypeFunction();
    private Dictionary<KeyType, KeyTypeFunction> keyFunctionPairs = new Dictionary<KeyType, KeyTypeFunction>();

    private void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();

        keyFunctionPairs.Add(KeyType.Gold, GoldKey);
        keyFunctionPairs.Add(KeyType.Silver, SilverKey);

        keyFunctionPairs[type].Invoke();
    }

    private void GoldKey() {
        spriteRenderer.sprite = goldSprite;
    }

    private void SilverKey() {
        spriteRenderer.sprite = silverSprite;
    }

}
