using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Class <c>Shoes<c> handles the logic from the input field and adds the sprites and animation
/// controller to the character object for the requested shoes.
/// <summary>
public class Shoes {

    private Sprite sBoots;
    private Sprite hGreen; 
    private Sprite sGreen;
    private Sprite hBoots; 
    private RuntimeAnimatorController[] controller;
    private Character character;
    private GameObject footwear;

    /// Constructs a Shoes object
    public Shoes(Sprite sBoots, Sprite hGreen, Sprite sGreen, Sprite hBoots, 
                RuntimeAnimatorController[] controller, Character character, GameObject footwear) {
        this.sBoots = sBoots;
        this.hGreen = hGreen;
        this.sGreen = sGreen;
        this.hBoots = hBoots;
        this.controller = controller;
        this.character = character;
        this.footwear = footwear;
    }

    /// Checks the input logic and displays an error or adds the relevant objects to the character.
    public bool checkLogicShoes(string text, GameObject errorWindow, TextMeshProUGUI errorText, AudioSource beep, AudioSource bomp) {
        if (text[0] != '\'' || text[text.Length-1] != '\'') {
            ErrorHandler eh = new ErrorHandler(bomp, "Chars are in single quotes: ' '", errorWindow, errorText);
            return false;
        }
        else if (text == "\'s\'" || text == "\'b\'") {
            AddShoesToCharacter(character.bodyShape, text[1]);
            beep.Play();
            return true;
        }
        else {
            ErrorHandler eh = new ErrorHandler(bomp, "Inputs are either \'s\' or \'b\'", errorWindow, errorText);
            return false;
        }
    }

    // Adds the relevant sprites and animator controller based on the body type and the shoes
    // selected.
    public void AddShoesToCharacter(char person, char type) {
            if (person == 's') {
                if (type == 's') {
                    Attribute att = new Attribute(sGreen, controller[0], character, footwear, "Shoes");
                    att.createAttribute(false);
                }
                else if (type == 'b') {
                    Attribute att = new Attribute(sBoots, controller[1], character, footwear, "Shoes");
                    att.createAttribute(false);
                }
            }
            else if (person == 'h') {
                if (type == 's') {
                    Attribute att = new Attribute(hGreen, controller[2], character, footwear, "Shoes");
                    att.createAttribute(false);
                }
                else if (type == 'b') {
                    Attribute att = new Attribute(hBoots, controller[3], character, footwear, "Shoes");
                    att.createAttribute(false);
                }
            }
    }

}