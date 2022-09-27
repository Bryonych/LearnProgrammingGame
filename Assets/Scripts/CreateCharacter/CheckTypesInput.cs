using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheckTypesInput : MonoBehaviour
{
   
    public Character character;
    public TMP_InputField currentField;
    public GameObject errorWindow;
    public GameObject displayWindow;
    public GameObject[] nextWindow;
    public TextMeshProUGUI errorText;
    AudioSource beep;
    AudioSource bomp;
    

    public void OnStoppedEditing(string text) {
        errorWindow.SetActive(false);
        if (text.Length > 0) {
            if (currentField.name == "StringInputField" && text.Length > 1) {
                if (text[0] != '\"' || text[text.Length-1] != '\"') {
                    ErrorHandler eh = new ErrorHandler(bomp, "Strings must be in quotation marks", errorWindow, errorText);
                }
                else {
                    character.setName(text.Substring(1,text.Length-2));
                    beep.Play();
                    Invoke("ChangeWindow", beep.clip.length);
                }
            }
            else if (currentField.name == "IntInputField") {
                int a;
                if (!int.TryParse(text, out a)) {
                    ErrorHandler eh = new ErrorHandler(bomp, "An integer is a number with no decimal place", errorWindow, errorText);
                }
                else if (text == "007") {
                    ErrorHandler eh = new ErrorHandler(bomp, "Sorry, we have an agent with that number already", errorWindow, errorText);
                }
                else {
                    character.setAgentNumber(text);
                    beep.Play();
                    Invoke("ChangeWindow", beep.clip.length);
                }
            }
            else if (currentField.name == "FloatInputField") {
                float a;
                if (!float.TryParse(text, out a)) {
                    ErrorHandler eh = new ErrorHandler(bomp, "A float is a number with a decimal place and up to 7 digits.", errorWindow, errorText);
                }
                else if (text.Length > 7) {
                    ErrorHandler eh = new ErrorHandler(bomp, "A number with more than 7 digits is a double, rather than a float.", errorWindow, errorText);
                }
                else if (!text.Contains('.')) {
                    string eText = "A float must have a decimal place." 
                            +" If a float is a whole number, its decimal is zero. eg. 1.0";
                    ErrorHandler eh = new ErrorHandler(bomp, eText, errorWindow, errorText);
                }
                else {
                    beep.Play();
                    Invoke("ChangeWindow", beep.clip.length);
                }
            }

            else if (currentField.name == "BooleanInputField") {
                if (text != "true" && text != "false") {
                    ErrorHandler eh = new ErrorHandler(bomp, "A boolean can be either true or false", errorWindow, errorText);
                }
                else {
                    if (text == "true") {
                        character.hasHat = true;
                        displayWindow.SetActive(false);
                        nextWindow[1].SetActive(true);
                    }
                    else {
                        beep.Play();
                        Invoke("ChangeWindow", beep.clip.length);
                    }
                }
            }
    
        }
    }

    public void ChangeWindow() {
        displayWindow.SetActive(false);
        nextWindow[0].SetActive(true);
    }

    void Start() {
        currentField.onEndEdit.AddListener(delegate {OnStoppedEditing(currentField.text);});
        beep = GameObject.Find("Beep").GetComponent<AudioSource>();
        bomp = GameObject.Find("Bomp").GetComponent<AudioSource>();
    }
}
