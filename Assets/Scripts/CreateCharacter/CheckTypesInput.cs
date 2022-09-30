using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// Class <c>CheckTypesInput<c> Listens for input in the datatypes challenge
/// and passes to TypesInputChecker for checking.
/// <summary>
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
    
    // Passes input to TypesInputChecker for checking and moves on if successful.
    public void OnStoppedEditing(string text) {
        errorWindow.SetActive(false);
        TypesInputChecker tic = new TypesInputChecker(character, currentField.name, errorWindow, errorText, bomp);
        // If correct, play succes noise, then move to correct next page, based on which input field it is.
        if (tic.CheckInput(text)) {
            if (beep != null) { beep.Play(); }
            if (currentField.name == "BooleanInputField" && text == "true") {
                displayWindow.SetActive(false);
                nextWindow[1].SetActive(true);
            }
            else { Invoke("ChangeWindow", beep.clip.length); }
        }
    }

    // Change screen
    public void ChangeWindow() {
        displayWindow.SetActive(false);
        nextWindow[0].SetActive(true);
    }

    // Start is called before the first frame.
    void Start() {
        // Listen for input
        currentField.onEndEdit.AddListener(delegate {OnStoppedEditing(currentField.text);});
        // Put cursor in input field
        currentField.Select();
        // find audio
        beep = GameObject.Find("Beep").GetComponent<AudioSource>();
        bomp = GameObject.Find("Bomp").GetComponent<AudioSource>();
    }
}
