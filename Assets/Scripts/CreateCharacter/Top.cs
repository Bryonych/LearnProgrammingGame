using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Class <c>Top<c> handles the logic from the input field and adds the sprites and animation
/// controller to the character object for the requested top.
/// <summary>
public class Top {

    private Sprite[] sprites;
    private RuntimeAnimatorController[] controllers;
    private Character character;
    private GameObject top;

    /// Constructs a Shoes object
    public Top(Sprite[] sprites, RuntimeAnimatorController[] controllers, Character character, GameObject top) {
        this.sprites = sprites;
        this.controllers = controllers;
        this.character = character;
        this.top = top;
    }

    /// Checks the input logic and displays an error or adds the relevant objects to the character.
    public bool checkLogicTop(string text, GameObject errorWindow, TextMeshProUGUI errorText, AudioSource beep, AudioSource bomp) {
        if (text == "true" || text == "false") {
            addTopToCharacter(character.bodyShape, text);
            beep.Play();
            return true;
        }
        else {
            ErrorHandler eh = new ErrorHandler(bomp, "A boolean is either true or false", errorWindow, errorText);
            return false;
        }
    }

    public void addTopToCharacter(char person, string text) {
        Attribute att = null;
        if (person == 's') {
            if (text == "false") {
                att = new Attribute(sprites[0], controllers[0], character, top, "Top");
            }
            else if (text == "true") {
                att = new Attribute(sprites[1], controllers[1], character, top, "Top");
            }
        }
        else if (person == 'h') {
            if (text == "false") {
                att = new Attribute(sprites[2], controllers[2], character, top, "Top");
            }
            else if (text == "true") {
                att = new Attribute(sprites[3], controllers[3], character, top, "Top");
            }
        }
        if (att != null) { att.createAttribute(false); }
    }

}