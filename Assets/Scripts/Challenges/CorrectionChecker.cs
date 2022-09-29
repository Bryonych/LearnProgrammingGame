using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CorrectionChecker {

    private GameObject errorWindow;
    private TextMeshProUGUI errorText;
    private AudioSource bomp;
    private string correctText;

    public CorrectionChecker(GameObject errorWindow, TextMeshProUGUI errorText, AudioSource bomp) {
        this.errorWindow = errorWindow;
        this.errorText = errorText;
        this.bomp = bomp;
    }

    public bool CheckInput(string text, int lineSelected) {
        switch(lineSelected) {
            case 2:
                return CheckTwo(text.Replace(" ", ""));
            case 3:
                return CheckThree(text.Replace(" ", ""));
            case 5:
                return CheckFive(text.Replace(" ", ""));
            case 6:
                return CheckSix(text.Replace(" ", ""));
            default:
                return false;
        }
    }

    public bool CheckTwo(string text) {
        correctText = "   for (Integer number : numbers) {";
        string eText;
        if (text == "for(Integernumber:numbers){") { return true; }
        if (text == "for(IntegerNumber:numbers){") { return true; }
        if (text == "for(integernumber:numbers){") { eText = "Very close! Integer has a capital \'I\'"; }
        else if (text.Substring(0,3) == "For") { eText = "The \'for\' in a foreach loop has a lowercase \'f\'"; }
        else if (text == "for(Integernumber:Numbers){") { eText = "The list is called '\numbers\' with a little \'n\'"; }
        else if (text.ToLower() == "integer") { eText = "Enter the full line of code with the correction included"; }
        else { eText = "The bug in this code is the type used is String, rather than integer, so it should read:\n"
                        +"for (Integer number : numbers) {";}
        ErrorHandler eh = new ErrorHandler(bomp, eText, errorWindow, errorText);
        return false;
    }

    public bool CheckThree(string text) {
        correctText = "       if (number == 6) {";
        string eText;
        if (text == "if(number==6){") { return true; }
        if (text == "if") { eText = "Enter the full line of code with the correction included"; }
        if (text == "if(number=6){") { eText = "In programming, a single '=' sign is for assignment. Use '==' to check equality.";}
        else { eText = "The bug in this code is that it starts with an \'else\' statement, instead of an \'if\'.\n"
                        +"Re-write the line with an \'if\' in place of the \'else\'"; }
        ErrorHandler eh = new ErrorHandler(bomp, eText, errorWindow, errorText);
        return false;
    }

    public bool CheckFive(string text) {
        correctText = "       }";
        string eText;
        if (text == "}") { return true; }
        if (text == "if{") { eText = "This is code for a different line. You are correcting the fifth line down."; }
        else { eText = "The bug in this line is that the \'if\' block is closed with a normal bracket, but it should be a curly bracket"; }
        ErrorHandler eh = new ErrorHandler(bomp, eText, errorWindow, errorText);
        return false;
    }

    public bool CheckSix(string text) {
        correctText = "       else {";
        string eText;
        if (text == "else{") { return true; }
        if (text == "else") { eText = "The curly brackets need to open after the \'else\'"; }
        else { eText = "The bug in this line is that it is an \'if\' statement, where it should be \'else\'"; }
        ErrorHandler eh = new ErrorHandler(bomp, eText, errorWindow, errorText);
        return false;
    }

    public string GetCorrectText() {
        return correctText;
    }
}    