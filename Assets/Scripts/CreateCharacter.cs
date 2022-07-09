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
    
    public void SelectBody(Sprite bd) {
        if (body == null) {
            body = GameObject.Find("Body");
        }
        body.SetActive(true);
        character.body = body;
        SpriteRenderer sr = character.body.GetComponent<SpriteRenderer>();
        sr.sprite = bd; 
        character.addPart(body);
        character.staticBody = bodies;
        if (bd.name.StartsWith('S')) {
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
        SpriteRenderer sr = character.bottoms.GetComponent<SpriteRenderer>();
        sr.sprite = b;
        character.addPart(character.bottoms);
    }

    public Character getCharacter() {
        return character;
    }

}
