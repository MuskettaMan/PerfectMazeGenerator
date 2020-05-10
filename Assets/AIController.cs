using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class AIController : MonoBehaviour {

    [SerializeField] private float detectRadius = 5;
    [SerializeField] private Transform target;

    private CharacterController characterController;
    private Vector2 dir;
    [SerializeField] private LayerMask layermask;

    private void Awake() {
        characterController = GetComponent<CharacterController>();

    }

    private void Update() {
        CalcDirectionToTarget();
        RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, 1, layermask);

        if(hit.collider != null && Vector2.Distance(transform.position, target.position) < detectRadius) {
            if(hit.transform == target) {
                characterController.Move(dir);
            }
        }
    }

    private void CalcDirectionToTarget() {
        dir = (target.position - transform.position).normalized;
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectRadius);

        CalcDirectionToTarget();

        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, dir * detectRadius);
    }

}
