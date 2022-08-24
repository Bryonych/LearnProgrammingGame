using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerRenderer : MonoBehaviour
{

    // public static readonly string[] staticDirections = {"Static NW", "Static SW", "Static SE", "Static NE"};
    // public static readonly string[]  runDirections = {"Run NW", "Run SW", "Run SE", "Run NE"};

    public Character character;
    Animator animator;
    // int lastDirection = 1;

    private void Awake() {
        animator = GetComponent<Animator>();
    }

    public void SetDirection(Vector2 direction) {
        // string[] directionArray = null;
        animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
        animator.SetFloat("Vertical", Input.GetAxis("Vertical"));

    }


 }
