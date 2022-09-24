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
    

    public void OnStoppedEditing(string text) {
        errorWindow.SetActive(false);
        if (text.Length > 0) {
            if (currentField.name == "StringInputField" && text.Length > 1) {
                if (text[0] != '\"' || text[text.Length-1] != '\"') {
                    errorText.text = "Strings must be in quotation marks";
                    errorWindow.SetActive(true);
                }
                else {
                    character.setName(text.Substring(1,text.Length-2));
                    ChangeWindow();
                }
            }
            else if (currentField.name == "IntInputField") {
                int a;
                if (!int.TryParse(text, out a)) {
                    errorText.text = "An integer is a number with no decimal place";
                    errorWindow.SetActive(true);
                }
                else if (text == "007") {
                    errorText.text = "Sorry, we have an agent with that number already";
                    errorWindow.SetActive(true);
                }
                else {
                    character.setAgentNumber(text);
                    ChangeWindow();
                }
            }
            else if (currentField.name == "FloatInputField") {
                float a;
                if (!float.TryParse(text, out a)) {
                    errorText.text = "A float is a number with a decimal place and up to 7 digits.";
                    errorWindow.SetActive(true);
                }
                else if (text.Length > 7) {
                    errorText.text = "A number with more than 7 digits is a double, rather than a float.";
                    errorWindow.SetActive(true);
                }
                else if (!text.Contains('.')) {
                    errorText.text = "A float must have a decimal place." 
                            +" If a float is a whole number, its decimal is zero. eg. 1.0";
                    errorWindow.SetActive(true);
                }
                else {
                    ChangeWindow();
                }
            }

            else if (currentField.name == "BooleanInputField") {
                if (text != "true" && text != "false") {
                    errorText.text = "A boolean can be either true or false";
                    errorWindow.SetActive(true);
                }
                else {
                    if (text == "true") {
                        character.hasHat = true;
                        displayWindow.SetActive(false);
                        nextWindow[1].SetActive(true);
                    }
                    else {
                        ChangeWindow();
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

    }
}
