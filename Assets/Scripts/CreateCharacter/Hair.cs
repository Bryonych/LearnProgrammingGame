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
    private Sprite shortBlack;
    private Sprite shortOrange;
    private Sprite dreads;
    private Sprite longGreen; 
    private RuntimeAnimatorController[] controller;
    private Character character;

    /// Constructs a Shoes object
    public Hair(Sprite shortBlack, Sprite shortOrange, Sprite dreads, Sprite longGreen, 
                RuntimeAnimatorController[] controller, Character character, GameObject hair) {
        this.shortBlack = shortBlack;
        this.shortOrange = shortOrange;
        this.dreads = dreads;
        this.longGreen = longGreen;
        this.controller = controller;
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

                addHairToCharacter(character.bodyShape, text);
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

    public void addHairToCharacter(char person, string text) {
        if (person == 's') {
            if (text == "\"long green\"") {
                Attribute att = new Attribute(longGreen, controller[0], character, hair, "Hair");
                att.createAttribute(false);
            }
            else if (text == "\"dreads\"") {
                Attribute att = new Attribute(dreads, controller[1], character, hair, "Hair");
                att.createAttribute(false);
            }
            else if (text == "\"short black\"") {
                Attribute att = new Attribute(shortBlack, controller[6], character, hair, "Hair");
                att.createAttribute(false);
            }
            else if (text == "\"short orange\"") {
                Attribute att = new Attribute(shortOrange, controller[7], character, hair, "Hair");
                att.createAttribute(false);
            }
        }
        else if (person == 'h') {
            if (text == "\"short black\"") {
                Attribute att = new Attribute(shortBlack, controller[2], character, hair, "Hair");
                att.createAttribute(false);
            }
            else if (text == "\"short orange\"") {
                Attribute att = new Attribute(shortOrange, controller[3], character, hair, "Hair");
                att.createAttribute(false);
            }
            else if (character.bodyShape == 'h' && text == "\"dreads\"") {
                Attribute att = new Attribute(dreads, controller[4], character, hair, "Hair");
                att.createAttribute(false);
            }
            else if (character.bodyShape == 'h' && text == "\"long green\"") {
                Attribute att = new Attribute(longGreen, controller[5], character, hair, "Hair");
                att.createAttribute(false);
            }
        }               
    }

}