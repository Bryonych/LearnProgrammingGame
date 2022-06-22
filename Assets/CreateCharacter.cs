using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCharacter : MonoBehaviour
{

    public Character character;
    GameObject body;
    GameObject bottoms;
    
    
    public void SelectBody(Sprite bd) {
        if (body == null) {
            body = GameObject.Find("Body");
        }
        body.SetActive(true);
        character.body = body;
        SpriteRenderer sr = character.body.GetComponent<SpriteRenderer>();
        sr.sprite = bd; 
    }


    public void SelectHair(Sprite h) {
        character.hair = new GameObject();
        SpriteRenderer sr = character.hair.GetComponent<SpriteRenderer>();
        sr.sprite = h;
    }

    public void SelectHat(Sprite ha) {
        character.hat = new GameObject();
        SpriteRenderer sr = character.hat.GetComponent<SpriteRenderer>();
        sr.sprite = ha;
    }

    public void SelectGlasses(Sprite g) {
        character.glasses = new GameObject();
        SpriteRenderer sr = character.glasses.GetComponent<SpriteRenderer>();
        sr.sprite = g;
    }

    public void SelectMask(Sprite m) {
        character.mask = new GameObject();
        SpriteRenderer sr = character.mask.GetComponent<SpriteRenderer>();
        sr.sprite = m;
    }

    public void SelectTop(Sprite t) {
        character.top = new GameObject();
        SpriteRenderer sr = character.top.GetComponent<SpriteRenderer>();
        sr.sprite = t;
    }

    public void SelectBottoms(Sprite b) {
        if (bottoms == null) {
            bottoms = GameObject.Find("Bottoms");
        }
        bottoms.SetActive(true);
        character.bottoms = bottoms;
        SpriteRenderer sr = character.bottoms.GetComponent<SpriteRenderer>();
        sr.sprite = b;
    }

    public void SelectShoes(Sprite s) {
        character.shoes = new GameObject();
        SpriteRenderer sr = character.shoes.GetComponent<SpriteRenderer>();
        sr.sprite = s;
    }



}
