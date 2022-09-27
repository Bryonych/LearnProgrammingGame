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
        TypesInputChecker tic = new TypesInputChecker(character, currentField.name, errorWindow, errorText, bomp);
        if (tic.CheckInput(text)) {
            if (beep != null) { beep.Play(); }
            if (currentField.name == "BooleanInputField" && text == "true") {
                displayWindow.SetActive(false);
                nextWindow[1].SetActive(true);
            }
            else { Invoke("ChangeWindow", beep.clip.length); }
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
