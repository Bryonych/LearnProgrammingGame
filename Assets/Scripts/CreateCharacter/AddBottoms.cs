using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// Class <c>AddBottoms<c> Listens for input in the datatypes challenge
/// and passes to Bottoms classes to create attribute. 
/// <summary>
public class AddBottoms : MonoBehaviour
{
    public TMP_InputField currentField;
    public GameObject errorWindow;
    public GameObject displayWindow;
    public GameObject nextWindow;
    public Character character;
    public TextMeshProUGUI errorText;
    public GameObject bottoms;
    public Sprite sTrousers;
    public Sprite hTrousers;
    public Sprite sShorts;
    public Sprite hShorts;
    public RuntimeAnimatorController[] controller;
    AudioSource beep;
    AudioSource bomp;

    // Listens for input and passes to Bottoms class for chekcing
    public void OnStoppedEditing(string text) {
        errorWindow.SetActive(false);
        Bottoms bot = new Bottoms(sTrousers, controller[0], character, bottoms);
        bot.setSprites(sTrousers, hTrousers, sShorts, hShorts, controller);
        // If correct, move to the next one
        if (bot.checkLogicBottoms(text, errorWindow, errorText, beep, bomp)) {
            Invoke("ChangeWindow", beep.clip.length);
        }
    }

    // Change the screen
    public void ChangeWindow() {
        displayWindow.SetActive(false);
        nextWindow.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {   
        // Listen to input field
        currentField.onEndEdit.AddListener(delegate {OnStoppedEditing(currentField.text);});
        // Put cursor in field
        currentField.Select();
        // Get audio
        beep = GameObject.Find("Beep").GetComponent<AudioSource>();
        bomp = GameObject.Find("Bomp").GetComponent<AudioSource>();
    }
}
