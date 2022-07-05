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
            else {
                if (newText != "true" && newText != "false") {
                    errorText.text = "Must be true or false";
                    errorWindow.SetActive(true);
                }
                else if (currentField.name == "HasHairInputField") {
                   character.hasHair = newText == "true" ?  true :  false;
                }
                else if (currentField.name == "WearsHatInputField") {
                   character.hasHat = newText == "true" ?  true :  false;
                }
                else if (currentField.name == "WearsGlassesInputField") {
                    character.hasGlasses = newText == "true" ?  true :  false;
                }
                else if (currentField.name == "WearsMaskInputField") {
                    character.hasMask = newText == "true" ?  true :  false;
                }
                else if (currentField.name == "WearsShoesInputField") {
                    character.hasShoes = newText == "true" ? true : false;
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
