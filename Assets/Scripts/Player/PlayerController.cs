using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour {

    [SerializeField] private string horizontalAxisName;
    [SerializeField] private string verticalAxisName;
    [SerializeField] private CharacterController character;

    /// <summary>
    /// Get the inputs and make direction out of it, normalize it and apply it to the position;
    /// </summary>
    private void Update() {
        var dir = new Vector2();
        dir.x = Input.GetAxisRaw(horizontalAxisName);
        dir.y = Input.GetAxisRaw(verticalAxisName);

        character.Move(dir);
    }

}
