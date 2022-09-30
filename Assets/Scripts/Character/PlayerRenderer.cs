using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// Class <c>PlayerRenderer<c> Passes direction to the animators, so 
/// they can play the correct animation based on movement and direction. 
/// <summary>
public class PlayerRenderer : MonoBehaviour
{


    public Character character;
    Animator animator;

    private void Awake() {
        animator = GetComponent<Animator>();
    }

    public void SetDirection(Vector2 direction) {

        animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
        animator.SetFloat("Vertical", Input.GetAxis("Vertical"));

    }


 }
