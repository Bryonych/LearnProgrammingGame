using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// Class <c>PlayerMovementController<c> Controls the movement of the character.
/// <summary>
public class PlayerMovementController : MonoBehaviour
{

    public float movementSpeed = 2.5f;
    PlayerRenderer isoRenderer;
    AudioSource left;
    AudioSource right;
    Movement movement;

    Rigidbody2D rbody;

    // Gets the relevant components. 
    private void Awake() {
        rbody = transform.parent.GetComponent<Rigidbody2D>();
        isoRenderer = GetComponentInChildren<PlayerRenderer>();
        left = GameObject.Find("LeftStep").GetComponent<AudioSource>();
        right = GameObject.Find("RightStep").GetComponent<AudioSource>();
        movement = new Movement(movementSpeed);
    }

    // Calculates position, movement and direction and moves the character. 
    void FixedUpdate() {
        Vector2 currentPos = rbody.position;
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector2 inputVector = new Vector2(horizontalInput, verticalInput);
        isoRenderer.SetDirection(inputVector * movementSpeed);
        rbody.MovePosition(movement.calculate(currentPos, inputVector));
    }


    // Play the step audiio
    public void PlayLeftStep() {
        left.Play();
    }
    public void PlayRightStep() {
        right.Play();
    }


}
