using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// Class <c>TypesInputChecker<c> Checks input for types challenge.
/// <summary>
public class TypesInputChecker
{
   
    private Character character;
    private string fieldName;
    private GameObject errorWindow;
    private TextMeshProUGUI errorText;
    private AudioSource bomp;
    
    // Constructs a TypesInputChecker object
    public TypesInputChecker(Character c, string fieldName, GameObject ew, TextMeshProUGUI errorText, AudioSource bomp) {
        this.character = c;
        this.fieldName = fieldName;
        this.errorWindow = ew;
        this.errorText = errorText;
        this.bomp = bomp;
    }

    // Passes to the relevant method based on input type. 
    public bool CheckInput(string text) {
        if (text.Length > 0) {
            if (fieldName == "StringInputField" && text.Length > 1) {
                return checkString(text);
            }
            else if (fieldName == "IntInputField") {
                return checkInt(text);
            }
            else if (fieldName == "FloatInputField") {
                return checkFloat(text);
            }
            else if (fieldName == "BooleanInputField") {
                return checkBoolean(text);
            }
        }
        return false;
    }

    // Checks if a string is valid, returns true if it is or displays error if not
    public bool checkString(string text) { 
        if (text[0] != '\"' || text[text.Length-1] != '\"') {
            ErrorHandler eh = new ErrorHandler(bomp, "Strings must be in quotation marks", errorWindow, errorText);
            return false;
        }
        else {
            character.setName(text.Substring(1,text.Length-2));
            return true;
        }
    }

    // Checks if an int is valid, returns true if it is or displays error if not
    public bool checkInt(string text) {
        int a;
        if (!int.TryParse(text, out a)) {
            ErrorHandler eh = new ErrorHandler(bomp, "An integer is a number with no decimal place", errorWindow, errorText);
            return false;
        }
        else if (text == "007") {
            ErrorHandler eh = new ErrorHandler(bomp, "Sorry, we have an agent with that number already", errorWindow, errorText);
            return false;
        }
        else {
            character.setAgentNumber(text);
            return true;
        }
    }

    // Checks if a fload input is valid,  returns true if it is or displays error if not
    public bool checkFloat(string text) {
        float a;
        if (!float.TryParse(text, out a)) {
            ErrorHandler eh = new ErrorHandler(bomp, "A float is a number with a decimal place and up to 7 digits.", errorWindow, errorText);
            return false;
        }
        else if (text.Length > 7) {
            ErrorHandler eh = new ErrorHandler(bomp, "A number with more than 7 digits is a double, rather than a float.", 
                                                errorWindow, errorText);
            return false;
        }
        else if (!text.Contains('.')) {
            string eText = "A float must have a decimal place." 
                    +" If a float is a whole number, its decimal is zero. eg. 1.0";
            ErrorHandler eh = new ErrorHandler(bomp, eText, errorWindow, errorText);
            return false;
        }
        else {
            return true;
        }
    }

    // Checks if a boolean input is valid, returns true if it is or displays error if not
    public bool checkBoolean(string text) {
        if (text != "true" && text != "false") {
            ErrorHandler eh = new ErrorHandler(bomp, "A boolean can be either true or false", errorWindow, errorText);
            return false;
        }
        else {
            if (text == "true") {
                character.hasHat = true;
            }
            return true;
        }
    }
}