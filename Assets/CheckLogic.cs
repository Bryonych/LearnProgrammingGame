using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CheckLogic : MonoBehaviour {

    public TMP_InputField currentField;
    public GameObject errorWindow;
    public Character character;
    public TextMeshProUGUI errorText;

    public void OnStoppedEditing(string text) {
        errorWindow.SetActive(false);
        string newText = "";
        if (text.Length > 0 && text[text.Length-1] != ';') {
            errorText.text = "Statements must end in a \";\"";
            errorWindow.SetActive(true);
        }
        else {
            newText = text.Remove(text.Length-1);
            if (currentField.name == "NameInputField") {
                if (newText[0] != '\"' || newText[newText.Length-1] != '\"') {
                    errorText.text = "Strings must be in quotation marks";
                    errorWindow.SetActive(true);
                }
                else if (newText == "") {
                    errorText.text = "Field cannot be blank";
                    errorWindow.SetActive(true);
                }
                else {
                    character.name = newText;
                }
            }
            else if (currentField.name == "AgeInputField") {
                if (!int.TryParse(newText, out int age)) {
                    errorText.text = "Must be an integer, which is a number without a decimal place";
                    errorWindow.SetActive(true);
                }
                else {
                    character.age = age;
                }
            }
            else if (currentField.name == "HasHairInputField") {
                print(newText);
                if (newText == "true") {
                    character.hasHair = true;
                }
                else if (newText == "false") {
                    character.hasHair = false;
                }
                else {
                    errorText.text = "Must be true or false";
                    errorWindow.SetActive(true);
                }
            }
            else if (currentField.name == "WearsHatInputField") {
                if (newText != "true" && newText != "false") {
                    errorText.text = "Must be true or false";
                    errorWindow.SetActive(true);
                }
                else if (newText == "true") {
                    character.hasHat = true;
                }
            }
            else if (currentField.name == "WearsGlassesInputField") {
                if (newText != "true" && newText != "false") {
                    errorText.text = "Must be true or false";
                    errorWindow.SetActive(true);
                }
                else if (newText == "true") {
                    character.hasGlasses = true;
                }
            }
            else if (currentField.name == "WearsMaskInputField") {
                if (newText != "true" && newText != "false") {
                    errorText.text = "Must be true or false";
                    errorWindow.SetActive(true);
                }
                else if (newText == "true") {
                    character.hasMask = true;
                }
            }
            else if (currentField.name == "WearsShoesInputField") {
                if (newText != "true" && newText != "false") {
                    errorText.text = "Must be true or false";
                    errorWindow.SetActive(true);
                }
                else if (newText == "true") {
                    character.hasShoes = true;
                }
            }
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        currentField.onEndEdit.AddListener(delegate {OnStoppedEditing(currentField.text);});

    }


}
