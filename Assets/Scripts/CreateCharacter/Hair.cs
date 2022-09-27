using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Class <c>Hair<c> handles the logic from the input field and adds the sprites and animation
/// controller to the character object for the requested ahir.
/// <summary>
public class Hair {

    private GameObject hair;
    private Sprite sprite;
    private RuntimeAnimatorController controller;
    private Sprite[] sprites;
    private RuntimeAnimatorController[] controllers;
    private Character character;

    /// Constructs a Shoes object
    public Hair(Sprite[] sprites, RuntimeAnimatorController[] controllers, Character character, GameObject hair) {
        this.sprites = sprites;
        this.controllers = controllers;
        this.character = character;
        this.hair = hair;
    }

    public bool checkLogicHair(string text, GameObject errorWindow, TextMeshProUGUI errorText, AudioSource beep, AudioSource bomp) {
        if (text.Length > 0) {
            if (text[0] != '\"' || text[text.Length-1] != '\"') {
                ErrorHandler eh = new ErrorHandler(bomp, "A string needs to be in quotation marks", errorWindow, errorText);
                return false;
            }
            else if (text == "\"long green\"" || text == "\"short black\"" || text == "\"dreads\"" 
                    || text == "\"short orange\"") {

                addHairToCharacter(character.bodyShape, text, sprites, controllers);
                beep.Play();
                return true;
            }
            else {
                ErrorHandler eh = new ErrorHandler(bomp, "Inputs are either \"long green\" or \"short black\" or \"dreads\" or \"short orange\"", errorWindow, errorText);
                return false;
            }
        }
        return false;
    }

    public void addHairToCharacter(char person, string text, Sprite[] sprites, RuntimeAnimatorController[] controllers) {
        Attribute att = null;
        if (person == 's') {
            if (text == "\"long green\"") {
                att = new Attribute(sprites[3], controllers[0], character, hair, "Hair");
            }
            else if (text == "\"dreads\"") {
                att = new Attribute(sprites[2], controllers[1], character, hair, "Hair");
            }
            else if (text == "\"short black\"") {
                att = new Attribute(sprites[0], controllers[6], character, hair, "Hair");
            }
            else if (text == "\"short orange\"") {
                att = new Attribute(sprites[1], controllers[7], character, hair, "Hair");
            }
        }
        else if (person == 'h') {
            if (text == "\"short black\"") {
                att = new Attribute(sprites[0], controllers[2], character, hair, "Hair");
            }
            else if (text == "\"short orange\"") {
                att = new Attribute(sprites[1], controllers[3], character, hair, "Hair");
            }
            else if (text == "\"dreads\"") {
                att = new Attribute(sprites[2], controllers[4], character, hair, "Hair");
            }
            else if (text == "\"long green\"") {
                att = new Attribute(sprites[3], controllers[5], character, hair, "Hair");
            }
        }
        if (att != null) { att.createAttribute(false); }               
    }

}