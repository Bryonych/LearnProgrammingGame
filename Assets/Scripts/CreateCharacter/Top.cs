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

    private Sprite sBusiness;
    private Sprite hBusiness;
    private Sprite sTShirt;
    private Sprite hTShirt;
    private RuntimeAnimatorController[] controller;
    private Character character;
    private GameObject top;

    /// Constructs a Shoes object
    public Top(Sprite sBusiness, Sprite hBusiness, Sprite sTShirt, Sprite hTShirt, 
                RuntimeAnimatorController[] controller, Character character, GameObject top) {
        this.sBusiness = sBusiness;
        this.hBusiness = hBusiness;
        this.sTShirt = sTShirt;
        this.hTShirt = hTShirt;
        this.controller = controller;
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
        if (person == 's') {
            if (text == "false") {
                Attribute att = new Attribute(sBusiness, controller[0], character, top, "Top");
                att.createAttribute(false);
            }
            else if (character.bodyShape == 's' && text == "true") {
                Attribute att = new Attribute(sTShirt, controller[1], character, top, "Top");
                att.createAttribute(false);
            }
        }
        else if (person == 'h') {
            if (character.bodyShape == 'h' && text == "false") {
                Attribute att = new Attribute(hBusiness, controller[2], character, top, "Top");
                att.createAttribute(false);
            }
            else if (character.bodyShape == 'h' && text == "true") {
                Attribute att = new Attribute(hTShirt, controller[3], character, top, "Top");
                att.createAttribute(false);
            }
        }
    }

}