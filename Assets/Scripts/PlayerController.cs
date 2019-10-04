using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour {

    private new Rigidbody2D rigidbody2D;

    [SerializeField] private string horizontalAxisName;
    [SerializeField] private string verticalAxisName;
    [SerializeField] private float movementSpeed = 1;

    /// <summary>
    /// The direction the player is going
    /// </summary>
    private Vector2 dir;

    /// <summary>
    /// Set dependencies
    /// </summary>
    private void Start() {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Get the inputs and make direction out of it, normalize it and apply it to the position;
    /// </summary>
    private void Update() {
        dir = new Vector2();
        dir.x = Input.GetAxisRaw(horizontalAxisName);
        dir.y = Input.GetAxisRaw(verticalAxisName);

        dir.Normalize();   

        rigidbody2D.position += dir * Time.deltaTime * movementSpeed;
    }

    /// <summary>
    /// Get the player's current direction
    /// </summary>
    /// <returns>The player's current direction</returns>
    public Vector2 GetDirection() {
        dir.x = Mathf.Round(dir.x);
        dir.y = Mathf.Round(dir.y);

        return dir;
    }

}
