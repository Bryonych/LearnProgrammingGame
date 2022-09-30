using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Class <c>Hat<c> handles the logic from the input field and adds the sprites and animation
/// controller to the character object for the requested hat.
/// <summary>
public class Hat {

    private Sprite[] sprites;
    private RuntimeAnimatorController[] controllers;
    private Character character;
    private GameObject hat;

    /// Constructs a Hat object
    public Hat(Sprite[] sprites, RuntimeAnimatorController[] controllers, Character character, GameObject hat) {
        this.sprites = sprites;
        this.controllers = controllers;
        this.character = character;
        this.hat = hat;
    }

    /// Checks the input logic and displays an error or adds the relevant objects to the character.
    public bool checkLogicHat(string text, GameObject errorWindow, TextMeshProUGUI errorText, AudioSource beep, AudioSource bomp) {
        if (text[0] != '\"' || text[text.Length-1] != '\"') {
            ErrorHandler eh = new ErrorHandler(bomp, "A string is in quotation marks", errorWindow, errorText);
            return false;
        }
        else if (text == "\"cap\"" || text == "\"top hat\"") {
            addHatToCharacter(character.bodyShape, text);
            if (beep != null) { beep.Play(); }
            return true;
        }
        else {
            ErrorHandler eh = new ErrorHandler(bomp, "Inputs are either \"cap\" or \"top hat\"", errorWindow, errorText);
            return false;
        }
    }

    // Adds the relevant sprite and controller to the character object. 
    public void addHatToCharacter(char person, string text) {
        Attribute att = null;
        if (person == 'h') {
            if (text == "\"cap\"") {
                att = new Attribute(sprites[0], controllers[1], character, hat, "Hat");
            }
            else if (text == "\"top hat\"") {
                att = new Attribute(sprites[1], controllers[2], character, hat, "Hat");
            }
        }
        else if (person == 's') {
            if (text == "\"top hat\"") {
                att = new Attribute(sprites[1], controllers[0], character, hat, "Hat");
            }
            else if (text == "\"cap\"") {
                att = new Attribute(sprites[0], controllers[3], character, hat, "Hat");
            }
        }
        if (att != null) { att.createAttribute(false); }
    }

}