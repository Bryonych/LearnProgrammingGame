using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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
