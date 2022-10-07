using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// Class <c>Movement<c> Calculates the movement vectors for the character based on user input.
/// <summary>
public class Movement {

    private float movementSpeed;

    public Movement(float movementSpeed) {
        this.movementSpeed = movementSpeed;
    }

    public Vector2 calculate(Vector2 currentPos, Vector2 inputVector) {
        Vector2 direction = GetDirection(inputVector);
        Vector2 movement = inputVector * movementSpeed * direction * Time.fixedDeltaTime;
        Vector2 rotateVector = ConvertToIsometric(movement, direction);
        rotateVector = (direction.y == 1.0 || direction.y == -1.0) ? new Vector2(rotateVector.x, rotateVector.y-0.02f) : rotateVector;
        Vector2 newPos = (direction.y == -1.0 || direction.x == -1.0)? currentPos - rotateVector : currentPos + rotateVector;
        return newPos;
    }

    // Returns the direction the character is moving. 
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

    // Converts directsions to isometric
    public Vector2 ConvertToIsometric(Vector2 cartesian, Vector2 direction) {
        Vector2 screenPos = screenPos = new Vector2((float)(cartesian.x - cartesian.y), (float)((cartesian.x + cartesian.y)/2.0));
        if (direction.y == -1.0 || direction.x == -1.0) {
            screenPos = new Vector2((float)(cartesian.x - cartesian.y), (float)((cartesian.x + cartesian.y)/2.0));
        }
        screenPos = new Vector2((float)(cartesian.x + cartesian.y), (float)((-cartesian.x + cartesian.y)/2.0));
        return screenPos;
    }

}