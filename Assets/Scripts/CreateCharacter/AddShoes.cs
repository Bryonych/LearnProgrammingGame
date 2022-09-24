using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Class <c>AddShoes<c> listens for input to the addshoes input field,
/// creates a shoe object to handle the logic and moves to the next screen when 
/// true is returned.
/// <summary>
public class AddShoes : MonoBehaviour
{

    public TMP_InputField currentField;
    public GameObject errorWindow;
    public GameObject displayWindow;
    public GameObject nextWindow;
    public Character character;
    public TextMeshProUGUI errorText;
    public GameObject footwear;
    public Sprite sBoots;
    public Sprite hGreen;
    public Sprite sGreen;
    public Sprite hBoots;
    public RuntimeAnimatorController[] controller;
    AudioSource beep;
    AudioSource bomp;

    // Takes the input from the text input field and creates a shoe object. If the logic 
    // checker in the shoe object returns true, it moves to the next window.
    public void OnStoppedEditing(string text) {
        errorWindow.SetActive(false);
        Shoes shoes = new Shoes(sBoots, hGreen, sGreen, hBoots, controller, character, footwear);
        if (shoes.checkLogicShoes(text, errorWindow, errorText, beep, bomp)) {
            Invoke("ChangeWindow", beep.clip.length);
        }
    }

    // Changes to the next window on success.
    public void ChangeWindow() {
        displayWindow.SetActive(false);
        nextWindow.SetActive(true);
    }


    // Start is called before the first frame update
    void Start()
    {
        currentField.onEndEdit.AddListener(delegate {OnStoppedEditing(currentField.text);});
        beep = GameObject.Find("Beep").GetComponent<AudioSource>();
        bomp = GameObject.Find("Bomp").GetComponent<AudioSource>();
    }



}
