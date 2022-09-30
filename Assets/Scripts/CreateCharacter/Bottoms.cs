using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// Class <c>Bottoms<c> Extends Attribute for a Bottoms attribute
/// <summary>
public class Bottoms : Attribute {

    private Sprite sTrousers;
    private Sprite hTrousers;
    private Sprite sShorts;
    private Sprite hShorts;
    private RuntimeAnimatorController[] controllers;
    private Character character;
    private GameObject bottoms;
    
    public Bottoms(Sprite sprite, RuntimeAnimatorController controller, Character character, GameObject go) 
            :base(sprite, controller, character, go, "Bottoms") {
                this.character = character;
                this.bottoms = go;
            }

    // Checks the logic of the input and adds attribute if correct, plays error if not. 
    public bool checkLogicBottoms(string text, GameObject errorWindow, TextMeshProUGUI errorText, AudioSource beep, AudioSource bomp) {
        if (text == "true" || text == "false") {
            addBottomsToCharacter(character.bodyShape, text);
            if (beep != null) { beep.Play(); }
            return true;
        }
        else {
            ErrorHandler eh = new ErrorHandler(bomp, "A boolean is either true or false", errorWindow, errorText);
            return false;
        }
    }

    // Sets the sprites for the bottoms (only shorts were passed previously).
    public void setSprites(Sprite sTrousers, Sprite hTrousers, Sprite sShorts, Sprite hShorts, RuntimeAnimatorController[] controllers) {
        this.sTrousers = sTrousers;
        this.hTrousers = hTrousers;
        this.sShorts = sShorts;
        this.hShorts = hShorts;
        this.controllers = controllers;
    }

    // Checks the input and creates the attribute with the relevant sprite and controller. 
    public void addBottomsToCharacter(char person, string text) {
        Attribute att = null;
        if (person == 's') {
            if (text == "false") {
                att = new Attribute(sTrousers, controllers[0], character, bottoms, "Bottoms");
            }
            else if (text == "true") {
                att = new Attribute(sShorts, controllers[1], character, bottoms, "Bottoms");
            }
        }
        else if (person == 'h') {
            if (text == "false") {
                att = new Attribute(hTrousers, controllers[2], character, bottoms, "Bottoms");
            }
            else if (text == "true") {
                att = new Attribute(hShorts, controllers[3], character, bottoms, "Bottoms");
            }
        }
        else {
            // Incorrect input
            return;
        }
        // Create the attribute and don't display it
        if (att != null) { att.createAttribute(false); }
    }

}