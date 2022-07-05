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
    
    
    public void SelectBody(Sprite bd) {
        if (body == null) {
            body = GameObject.Find("Body");
        }
        body.SetActive(true);
        character.body = body;
        SpriteRenderer sr = character.body.GetComponent<SpriteRenderer>();
        sr.sprite = bd; 
        // character.addPart(body);
        if (bd.name.StartsWith('S')) {
            character.bodyShape = 's';
        }
        else {
            character.bodyShape = 'h';
        }
    }


    // public void SelectHair(Sprite h) {
    //     if (hair == null) {
    //         hair = GameObject.Find("Hair");
    //     }
    //     character.hair = hair;
    //     SpriteRenderer sr = character.hair.GetComponent<SpriteRenderer>();
    //     sr.sprite = h;
    //     // character.addPart(character.hair);
    //     // character.hair.SetActive(false);
    // }

    // public void SelectHat(Sprite ha) {
    //     if (hat == null) {
    //         hat = GameObject.Find("Hat");
    //     }
    //     character.hat = hat;
    //     SpriteRenderer sr = character.hat.GetComponent<SpriteRenderer>();
    //     sr.sprite = ha;
    //     // character.addPart(character.hat);
    //     // character.hat.SetActive(false);
    // }

    // public void SelectGlasses(Sprite g) {
    //     if (glasses == null) {
    //         glasses = GameObject.Find("Glasses");
    //     }
    //     character.glasses = glasses;
    //     SpriteRenderer sr = character.glasses.GetComponent<SpriteRenderer>();
    //     sr.sprite = g;
    //     // character.addPart(character.glasses);
    //     // character.glasses.SetActive(false);
    // }

    // public void SelectMask(Sprite m) {
    //     if (mask == null) {
    //         mask = GameObject.Find("Mask");
    //     }
    //     character.mask = mask;
    //     SpriteRenderer sr = character.mask.GetComponent<SpriteRenderer>();
    //     sr.sprite = m;
    //     // character.addPart(character.mask);
    //     // character.mask.SetActive(false);
    // }

    // public void SelectTop(Sprite t) {
    //     if (top == null) {
    //         top = GameObject.Find("Top");
    //     }
    //     character.top = top;
    //     SpriteRenderer sr = character.top.GetComponent<SpriteRenderer>();
    //     sr.sprite = t;
    //     // character.addPart(character.top);
    //     // character.top.SetActive(false);
    // }

    public void SelectBottoms(Sprite b) {
        if (bottoms == null) {
            bottoms = GameObject.Find("Bottoms");
        }
        bottoms.SetActive(true);
        character.bottoms = bottoms;
        SpriteRenderer sr = character.bottoms.GetComponent<SpriteRenderer>();
        sr.sprite = b;
        // character.addPart(character.bottoms);
    }

    // public void SelectShoes(Sprite s) {
    //     if (shoes == null) {
    //         shoes = GameObject.Find("Shoes");
    //     }
    //     character.shoes = shoes;
    //     SpriteRenderer sr = character.shoes.GetComponent<SpriteRenderer>();
    //     sr.sprite = s;
    //     // character.addPart(character.shoes);
    //     // character.shoes.SetActive(false);
    // }

}
