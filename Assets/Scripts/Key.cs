using UnityEngine;

public class Key : MonoBehaviour {
    public enum KeyType { Gold = 2, Silver = 1 }

    public KeyType type;
    [SerializeField] private Sprite goldSprite;
    [SerializeField] private Sprite silverSprite;

    public Vector2 gridPosition;

    private SpriteRenderer spriteRenderer;

    private void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnValidate() {
        if(spriteRenderer == null) {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        if (type == KeyType.Gold) {
            spriteRenderer.sprite = goldSprite;
        } else if (type == KeyType.Silver) {
            spriteRenderer.sprite = silverSprite;
        }
    }

}
