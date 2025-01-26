using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GroundedCheck : MonoBehaviour
{
    public PlayerMovement movement;

    void OnTriggerEnter(Collider ground) {

        if (ground.gameObject.CompareTag("Ground")) {
            movement.isGrounded = true;
            movement.isAirborne = false;
        }
    }

    void OnTriggerExit(Collider ground) {
        if (ground.gameObject.CompareTag("Ground")) {
            movement.isGrounded = false;
            movement.isAirborne = true;
        }
    }

    void Update() {
        //Debug.Log($"Grounded: {movement.isGrounded.ToString()}");
        //Debug.Log($"Airborne: {movement.isAirborne.ToString()}");
    }
}

