using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovementController : MonoBehaviour
{

    public float movementSpeed = 1.5f;
    PlayerRenderer isoRenderer;

    Rigidbody2D rbody;

    private void Awake() {
        rbody = transform.parent.GetComponent<Rigidbody2D>();
        isoRenderer = GetComponentInChildren<PlayerRenderer>();
    }

    void FixedUpdate() {
        Vector2 currentPos = rbody.position;
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector2 inputVector = new Vector2(horizontalInput, verticalInput);
        Vector2 direction = GetDirection(inputVector);
        Vector2 movement = inputVector * movementSpeed * direction * Time.fixedDeltaTime;
        Vector2 rotateVector = ConvertToIsometric(movement, direction);
        rotateVector = (direction.y == 1.0 || direction.y == -1.0) ? new Vector2(rotateVector.x, rotateVector.y-0.007f) : rotateVector;
        Vector2 newPos = (direction.y == -1.0 || direction.x == -1.0)? currentPos - rotateVector : currentPos + rotateVector;
        isoRenderer.SetDirection(inputVector * movementSpeed);
        rbody.MovePosition(newPos);
    }

    public Vector2 ConvertToIsometric(Vector2 cartesian, Vector2 direction) {
        Vector2 screenPos = screenPos = new Vector2((float)(cartesian.x - cartesian.y), (float)((cartesian.x + cartesian.y)/2.0));
        if (direction.y == -1.0 || direction.x == -1.0) {
            screenPos = new Vector2((float)(cartesian.x - cartesian.y), (float)((cartesian.x + cartesian.y)/2.0));
        }
        screenPos = new Vector2((float)(cartesian.x + cartesian.y), (float)((-cartesian.x + cartesian.y)/2.0));
        return screenPos;
    }

    public Vector2 GetDirection(Vector2 dir) {
        Vector2 direction = new Vector2(0, 0);
        if (dir.y > 0) {
            direction += new Vector2(0, -1);
        }
        else if (dir.y < 0) {
            direction += new Vector2(0, 1);
        }
        else if (dir.x > 0) { 
            direction += new Vector2(1, 0);
        }
        else if (dir.x < 0) {
            direction += new Vector2(-1, 0);
        }
        direction.Normalize();
        return direction;
    }


}
