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

    public Sprite cap;
    public Sprite topHat; 
    private RuntimeAnimatorController[] controller;
    private Character character;
    private GameObject hat;

    /// Constructs a Hat object
    public Hat(Sprite cap, Sprite topHat, RuntimeAnimatorController[] controller, Character character, GameObject hat) {
        this.cap = cap;
        this.topHat = topHat;
        this.controller = controller;
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
            beep.Play();
            return true;
        }
        else {
            ErrorHandler eh = new ErrorHandler(bomp, "Inputs are either \"cap\" or \"top hat\"", errorWindow, errorText);
            return false;
        }

    }
    public void addHatToCharacter(char person, string text) {
        if (person == 'h') {}
            if (text == "\"cap\"") {
                Attribute att = new Attribute(cap, controller[1], character, hat, "Hat");
                att.createAttribute(false);
            }
            else if (text == "\"top hat\"") {
                Attribute att = new Attribute(topHat, controller[2], character, hat, "Hat");
                att.createAttribute(false);
            }
        else if (person == 's') {
            if (text == "\"top hat\"") {
                Attribute att = new Attribute(topHat, controller[0], character, hat, "Hat");
                att.createAttribute(false);
            }
            else if (text == "\"cap\"") {
                Attribute att = new Attribute(cap, controller[3], character, hat, "Hat");
                att.createAttribute(false);
            }
        }
    }

}