using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerRenderer : MonoBehaviour
{

    public static readonly string[] staticDirections = {"Static NW", "Static SW", "Static SE", "Static NE"};
    public static readonly string[]  runDirections = {"Run NW", "Run SW", "Run SE", "Run NE"};

    public Character character;
    Animator animator;
    int lastDirection = 1;

    private void Awake() {
        animator = GetComponent<Animator>();
    }

    public void SetDirection(Vector2 direction) {
        string[] directionArray = null;
        animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
        animator.SetFloat("Vertical", Input.GetAxis("Vertical"));
        // lastDirection = DirectionToIndex(direction, 4);
        // if (direction.magnitude < 0.01f) {
        //     directionArray = staticDirections;
        //     // UpdateImage(directionArray[lastDirection]);
        // } else {
        //     directionArray = runDirections;
        //     // lastDirection = DirectionToIndex(direction, 4);
        //     // UpdateClip(directionArray[lastDirection]);
        // }
        // directionArray = staticDirections;
        

        // int stateHash = Array.IndexOf(directionArray, directionArray[lastDirection]);
        // print("last direction " + directionArray[lastDirection]);
        // UpdateImage(directionArray[lastDirection]);

    }

    // public static int DirectionToIndex(Vector2 dir, int sliceCount) {
    //     Vector2 normDir = dir.normalized;
    //     float step = 360f / sliceCount;
    //     float halfstep = step / 2;
    //     float angle = Vector2.SignedAngle(Vector2.up, normDir);
    //     angle -= 60;
    //     angle += halfstep;

    //     if (angle < 0) {
    //         angle += 360;
    //     }

    //     float stepCount = angle / step;
    //     return Mathf.FloorToInt(stepCount);
    // }

    // public void UpdateImage(string direction) {
    //     foreach (GameObject go in character.getParts()) {
    //         Animator anim = GameObject.Find(go.name).GetComponent<Animator>();
    //         anim.enabled = false;
    //         SpriteRenderer sr = GameObject.Find(go.name).GetComponent<SpriteRenderer>();
    //         Sprite[] images = character.GetSprites(go);
    //         if (direction == "Static NW") {
    //             sr.sprite = images[1];
    //         }
    //         else if (direction == "Static SW") {
    //             sr.sprite = images[0];
    //             print("SW Static");
    //         }
    //         else if (direction == "Static SE") {
    //             sr.sprite = images[3];
    //         }
    //         else if (direction == "Static NE") {
    //             sr.sprite = images[2];
    //         }
    //         else {
    //             print("Invalid Direction");
    //         }
    //     }
    // }

    // public void UpdateClip(string direction) {
    //     foreach(GameObject go in character.getParts()) {
    //         Animator anim = GameObject.Find(go.name).GetComponent<Animator>();
    //         anim.enabled = true;
    //         string[] clips = character.GetClips(go);
    //         if (direction == "Run NW") {
    //             anim.Play(clips[1]);
    //         }
    //         else if (direction == "Run SW") {
    //             print("clip" + clips[0]);
    //             anim.Play(clips[0], 0, 0);
    //             print("SW moving");
    //         }
    //         else if (direction == "Run SE") {
    //              anim.Play(clips[3]);
    //         }
    //         else if (direction == "Run NE") {
    //             anim.Play(clips[2]);
    //         }
    //         else {
    //             print("Invalid run direction");
    //         }
    //     }
    // }

 }
