using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    [SerializeField] private Key keyPrefab;
    [SerializeField] private int amountOfKeysToSpawn;
    [SerializeField] private KeyCollector keyCollector;

    private GridManager gridManager;

    private List<Key> activeKeys = new List<Key>();

    private void Start() {
        gridManager = GridManager.Instance;

        gridManager.gridGenerated += OnGridGenerated;
        keyCollector.keyPickedUp += OnKeyPickedUp;
    }

    private void OnGridGenerated(Grid grid) {
        for(int i = activeKeys.Count - 1; i >= 0; i--) {
            var key = activeKeys[i];
            activeKeys.Remove(key);
            Destroy(key.gameObject);
        }

        for (int i = 0; i < amountOfKeysToSpawn; i++) {
            Vector2 randomPos = new Vector2(Random.Range(0, grid.width), Random.Range(0, grid.height));

            var newPos = gridManager.GetGridGraphic().GetCells()[(int)randomPos.x, (int)randomPos.y].transform.position;

            var keyClone = Instantiate(keyPrefab, transform);
            keyClone.gridPosition = randomPos;
            keyClone.transform.position = newPos;

            activeKeys.Add(keyClone);
        }
    }

    private void OnKeyPickedUp(Key key) {
        activeKeys.Remove(key);
        Destroy(key.gameObject);
    }

}
