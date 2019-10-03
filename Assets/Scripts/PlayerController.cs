using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour {

    private new Rigidbody2D rigidbody2D;

    [SerializeField] private string horizontalAxisName;
    [SerializeField] private string verticalAxisName;
    [SerializeField] private float movementSpeed = 1;

    private void Start() {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        Vector2 move = new Vector2();
        move.x = Input.GetAxis(horizontalAxisName);
        move.y = Input.GetAxis(verticalAxisName);

        move.x = Mathf.Ceil(move.x);
        move.y = Mathf.Ceil(move.y);

        move.Normalize();   

        rigidbody2D.position += move * Time.deltaTime * movementSpeed;
    }

}
