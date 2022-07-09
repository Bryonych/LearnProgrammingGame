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
    int lastDirection;

    private void Awake() {
        animator = GetComponent<Animator>();
    }

    public void SetDirection(Vector2 direction) {
        string[] directionArray = null;

        lastDirection = DirectionToIndex(direction, 4);
        // if (direction.magnitude < 0.01f) {
        //     directionArray = staticDirections;
        //     UpdateImage(directionArray[lastDirection]);
        // } else {
        //     directionArray = runDirections;
        //     lastDirection = DirectionToIndex(direction, 4);
        //     UpdateClip(directionArray[lastDirection]);
        // }
        directionArray = staticDirections;
        

        // int stateHash = Array.IndexOf(directionArray, directionArray[lastDirection]);

        UpdateImage(directionArray[lastDirection]);

    }

    public static int DirectionToIndex(Vector2 dir, int sliceCount) {
        Vector2 normDir = dir.normalized;
        float step = 360f / sliceCount;
        float halfstep = step / 2;
        float angle = Vector2.SignedAngle(Vector2.up, normDir);
        angle -= 60;
        angle += halfstep;

        if (angle < 0) {
            angle += 360;
        }

        float stepCount = angle / step;
        return Mathf.FloorToInt(stepCount);
    }

    public void UpdateImage(string direction) {
        GameObject bd = GameObject.Find("Body");
        SpriteRenderer srb = bd.GetComponent<SpriteRenderer>();
        SpriteRenderer srbot = GameObject.Find("Bottoms").GetComponent<SpriteRenderer>();
        // SpriteRenderer srg = GameObject.Find("Glasses").GetComponent<SpriteRenderer>();
        SpriteRenderer srh = GameObject.Find("Hair").GetComponent<SpriteRenderer>();
        SpriteRenderer srha = GameObject.Find("Hat").GetComponent<SpriteRenderer>();
        SpriteRenderer srs = GameObject.Find("Shoes").GetComponent<SpriteRenderer>();
        SpriteRenderer srt = GameObject.Find("Top").GetComponent<SpriteRenderer>();
        // SpriteRenderer srm = GameObject.Find("Mask").GetComponent<SpriteRenderer>();
        if (direction == "Static NW") {
            srb.sprite = character.staticBody[1];
            srbot.sprite = character.staticBottoms[1];
            // srg.sprite = character.staticGlasses[1];
            srh.sprite = character.staticHair[1];
            srha.sprite = character.staticHat[1];
            srs.sprite = character.staticShoes[1];
            srt.sprite = character.staticTop[1];
            // srm.sprite = character.staticMask[1];
        }
        else if (direction == "Static SW") {
            srb.sprite = character.staticBody[0];
            srbot.sprite = character.staticBottoms[0];
            // srg.sprite = character.staticGlasses[0];
            srh.sprite = character.staticHair[0];
            srha.sprite = character.staticHat[0];
            srs.sprite = character.staticShoes[0];
            srt.sprite = character.staticTop[0];
            // srm.sprite = character.staticMask[0];
        }
        else if (direction == "Static SE") {
            srb.sprite = character.staticBody[3];
            srbot.sprite = character.staticBottoms[3];
            // srg.sprite = character.staticGlasses[3];
            srh.sprite = character.staticHair[3];
            srha.sprite = character.staticHat[3];
            srs.sprite = character.staticShoes[3];
            srt.sprite = character.staticTop[3];
            // srm.sprite = character.staticMask[3];
        }
        else if (direction == "Static NE") {
            srb.sprite = character.staticBody[2];
            srbot.sprite = character.staticBottoms[2];
            // srg.sprite = character.staticGlasses[2];
            srh.sprite = character.staticHair[2];
            srha.sprite = character.staticHat[2];
            srs.sprite = character.staticShoes[2];
            srt.sprite = character.staticTop[2];
            // srm.sprite = character.staticMask[2];
        }
    }

}
