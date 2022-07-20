using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCharacter : MonoBehaviour
{

    public Character character;
    GameObject body;
    GameObject bottoms;
    GameObject hair;
    GameObject hat;
    GameObject glasses;
    GameObject mask;
    GameObject top;
    GameObject shoes;
    public Sprite[] bodies;
    public string[] bodyAnimations;
    public RuntimeAnimatorController controller;
    
    public void SelectBody(Sprite bd) {
        character.resetParts();
        if (body == null) {
            body = GameObject.Find("Body");
        }
        body.SetActive(true);
        character.body = body;
        DontDestroyOnLoad(character.body);
        SpriteRenderer sr = character.body.GetComponent<SpriteRenderer>();
        sr.sprite = bd; 
        character.addPart(body);
        // character.staticBody = bodies;
        // character.animBody = bodyAnimations;
        character.setController("Body", controller);
        if (bd.name.StartsWith("SH")) {
            character.bodyShape = 's';
        }
        else {
            character.bodyShape = 'h';
        }

    }


    public void SelectBottoms(Sprite b) {
        if (bottoms == null) {
            bottoms = GameObject.Find("Bottoms");
        }
        bottoms.SetActive(true);
        character.bottoms = bottoms;
        DontDestroyOnLoad(character.bottoms);
        SpriteRenderer sr = character.bottoms.GetComponent<SpriteRenderer>();
        sr.sprite = b;
        character.addPart(character.bottoms);
    }

    public Character getCharacter() {
        return character;
    }

}
