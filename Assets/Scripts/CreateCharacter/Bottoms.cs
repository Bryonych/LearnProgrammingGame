using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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

    public bool checkLogicBottoms(string text, GameObject errorWindow, TextMeshProUGUI errorText, AudioSource beep, AudioSource bomp) {
        if (text == "true" || text == "false") {
            addBottomsToCharacter(character.bodyShape, text);
            beep.Play();
            return true;
        }
        else {
            ErrorHandler eh = new ErrorHandler(bomp, "A boolean is either true or false", errorWindow, errorText);
            return false;
        }
    }

    public void setSprites(Sprite sTrousers, Sprite hTrousers, Sprite sShorts, Sprite hShorts, RuntimeAnimatorController[] controllers) {
        this.sTrousers = sTrousers;
        this.hTrousers = hTrousers;
        this.sShorts = sShorts;
        this.hShorts = hShorts;
        this.controllers = controllers;
    }

    public void addBottomsToCharacter(char person, string text) {
        if (person == 's') {
            if (text == "false") {
                Attribute att = new Attribute(sTrousers, controllers[0], character, bottoms, "Bottoms");
                att.createAttribute(false);
            }
            else if (text == "true") {
                Attribute att = new Attribute(sShorts, controllers[1], character, bottoms, "Bottoms");
                att.createAttribute(false);
            }
        }
        else if (person == 'h') {
            if (text == "false") {
                Attribute att = new Attribute(hTrousers, controllers[2], character, bottoms, "Bottoms");
                att.createAttribute(false);
            }
            else if (text == "true") {
                Attribute att = new Attribute(hShorts, controllers[3], character, bottoms, "Bottoms");
                att.createAttribute(false);
            }
        }
        else {
            return;
        }
    }

}