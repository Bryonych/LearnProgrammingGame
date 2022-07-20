using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Character")]
public class Character : ScriptableObject {

    public new string name;
    public int age;

    public GameObject body;
    public GameObject hair;
    public GameObject hat;
    public GameObject glasses;
    public GameObject mask;
    public GameObject top;
    public GameObject bottoms;
    public GameObject shoes;

    public Sprite[] staticBody;
    public Sprite[] staticHair;
    public Sprite[] staticHat;
    public Sprite[] staticGlasses;
    public Sprite[] staticMask;
    public Sprite[] staticTop;
    public Sprite[] staticBottoms;
    public Sprite[] staticShoes;

    RuntimeAnimatorController bodyController;
    RuntimeAnimatorController hairController;
    RuntimeAnimatorController hatController;
    RuntimeAnimatorController topController;
    RuntimeAnimatorController bottomsController;
    RuntimeAnimatorController shoesController;
    

    List<GameObject> parts = new List<GameObject>();

    public bool hasHair = false;
    public bool hasHat = false;
    public bool hasGlasses = false;
    public bool hasMask = false;
    public bool hasShoes = false;

    public char bodyShape;

    public void addPart(GameObject part) {
        parts.Add(part);
    }

    public void resetParts() {
        parts = new List<GameObject>();
    }

    public void removePart(GameObject part) {
        parts.Remove(part);
    }

    public List<GameObject> getParts() {
        return parts;
    }

    public void setController(string part, RuntimeAnimatorController c) {
        if (part == "Body") { bodyController = c; }
        else if (part == "Hair") { hairController = c; }
        else if (part == "Hat") { hatController = c; }
        else if (part == "Top") { topController = c; }
        else if (part == "Bottoms") { bottomsController = c; }
        else if (part == "Shoes") { shoesController = c; }
        else { }
    }

    public RuntimeAnimatorController GetController(GameObject go) {
        if (go.name == "Body") { return bodyController; }
        else if (go.name == "Hair") { return hairController; }
        else if (go.name == "Hat") { return hatController; }
        else if (go.name == "Top") { return topController; }
        else if (go.name == "Bottoms") { return bottomsController; }
        else if (go.name == "Shoes") { return shoesController; }
        else { return null; }
    }

    // public string[] GetClips(GameObject bodyPart) {
    //     if (bodyPart.name == "Body") {
    //         return animBody;
    //     }
    //     else if (bodyPart.name == "Hair") {
    //         return animHair;
    //     }
    //     else if (bodyPart.name == "Hat") {
    //         return animHat;
    //     }
    //     else if (bodyPart.name == "Glasses") {
    //         return animGlasses;
    //     }
    //     else if (bodyPart.name == "Mask") {
    //         return animMask;
    //     }
    //     else if (bodyPart.name == "Top") {
    //         return animTop;
    //     }
    //     else if (bodyPart.name == "Bottoms") {
    //         return animBottoms;
    //     }
    //     else if (bodyPart.name == "Shoes") {
    //         return animShoes;
    //     }
    //     else {
    //         // console.log("Invalid game object");
    //         return null;
    //     }
    // }

    // public Sprite[] GetSprites(GameObject bodyPart) {
    //     if (bodyPart.name == "Body") {
    //         return staticBody;
    //     }
    //     else if (bodyPart.name == "Hair") {
    //         return staticHair;
    //     }
    //     else if (bodyPart.name == "Hat") {
    //         return staticHat;
    //     }
    //     else if (bodyPart.name == "Glasses") {
    //         return staticGlasses;
    //     }
    //     else if (bodyPart.name == "Mask") {
    //         return staticMask;
    //     }
    //     else if (bodyPart.name == "Top") {
    //         return staticTop;
    //     }
    //     else if (bodyPart.name == "Bottoms") {
    //         return staticBottoms;
    //     }
    //     else if (bodyPart.name == "Shoes") {
    //         return staticShoes;
    //     }
    //     else {
    //         // console.log("Invalid game object");
    //         return null;
    //     }
    // }
  
}
