using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour {

    private Animator animator;
    private CharacterController playerController;

    /// <summary>
    /// Set dependencies
    /// </summary>
    private void Start() {
        animator = GetComponent<Animator>();
        playerController = GetComponent<CharacterController>();
    }

    /// <summary>
    /// Base the animations on the player's direction
    /// </summary>
    private void Update() {
        Vector2Int dir = playerController.GetDirection();

        animator.SetInteger("moveX", dir.x);
        animator.SetInteger("moveY", dir.y);

        if(dir.x != 0 || dir.y != 0) {
            animator.SetFloat("SpeedMultiplier", 1);
            animator.SetFloat("NormalizedTime", Time.time);
        } else {
            animator.SetFloat("SpeedMultiplier", 0);
            animator.SetFloat("NormalizedTime", 0);
        }
    }

}
