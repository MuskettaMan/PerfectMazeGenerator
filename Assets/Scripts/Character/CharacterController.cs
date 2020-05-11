using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {

    [SerializeField] private float movementSpeed = 1;

    /// <summary>
    /// The direction the player is going
    /// </summary>
    private Vector2 dir;

    /// <summary>
    /// Reference to the rigidbody
    /// </summary>
    private Rigidbody2D rb2d;

    /// <summary>
    /// Set dependencies
    /// </summary>
    private void Start() {
        rb2d = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Move in the direction given
    /// </summary>
    /// <param name="dir">Direction you want to move in</param>
    public void Move(Vector2 dir) {

        dir.Normalize();

        rb2d.position += dir * Time.deltaTime * movementSpeed;

        this.dir = dir;

    }

    /// <summary>
    /// Get the player's current direction
    /// </summary>
    /// <returns>The player's current direction</returns>
    public Vector2Int GetDirection() {
        dir.x = Mathf.Round(dir.x);
        dir.y = Mathf.Round(dir.y);

        return new Vector2Int().FromVector2(dir);
    }

}
