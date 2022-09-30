using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Class <c>Attribute<c> Creates attribute and adds details to
/// character object. 
/// <summary>
public class Attribute {
    private Sprite sprite;
    private RuntimeAnimatorController controller;
    private Character character;
    private GameObject go;
    private string name;

    // Constructs and attribute object
    public Attribute(Sprite sprite, RuntimeAnimatorController controller, Character character, GameObject go, string name) {
        this.sprite = sprite;
        this.controller = controller;
        this.character = character;
        this.go = go;
        this.name = name;
    }

    // Creates teh attribute
    public void createAttribute(bool active) {
        if (go == null) {
            go = GameObject.Find(name);
        }
        go.SetActive(active);
        character.setPart(name, go);
        // Add front on sprite to the character
        SpriteRenderer sr = character.getPart(name).GetComponent<SpriteRenderer>();
        sr.sprite = sprite; 
        character.addPart(go);
        // Adds relevant animation controller to character object
        character.setController(name, controller);
    }

}