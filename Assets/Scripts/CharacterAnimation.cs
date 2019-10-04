using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour {

    private Animator animator;
    private PlayerController playerController;

    /// <summary>
    /// Set dependencies
    /// </summary>
    private void Start() {
        animator = GetComponent<Animator>();
        playerController = GetComponent<PlayerController>();
    }

    /// <summary>
    /// Base the animations on the player's direction
    /// </summary>
    private void Update() {
        Vector2 dir = playerController.GetDirection();

        animator.SetInteger("moveX", (int)dir.x);
        animator.SetInteger("moveY", (int)dir.y);


    }

}
