using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Attribute {
    private Sprite sprite;
    private RuntimeAnimatorController controller;
    private Character character;
    private GameObject go;
    private string name;

    public Attribute(Sprite sprite, RuntimeAnimatorController controller, Character character, GameObject go, string name) {
        this.sprite = sprite;
        this.controller = controller;
        this.character = character;
        this.go = go;
        this.name = name;
    }

    public void createAttribute(bool active) {
        if (go == null) {
            go = GameObject.Find(name);
        }
        go.SetActive(active);
        character.setPart(name, go);
        SpriteRenderer sr = character.getPart(name).GetComponent<SpriteRenderer>();
        sr.sprite = sprite; 
        character.addPart(go);
        character.setController(name, controller);
    }

}