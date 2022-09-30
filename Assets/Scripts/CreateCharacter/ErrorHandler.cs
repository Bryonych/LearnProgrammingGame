using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Class <c>ErrorHandler<c> Displays and error on the screen.
/// <summary>
public class ErrorHandler {

    private AudioSource bomp;
    private string text;
    private GameObject errorWindow;
    private TextMeshProUGUI errorText;

    // Constructs an ErrorHandler object
    public ErrorHandler(AudioSource bomp, string text, GameObject errorWindow, TextMeshProUGUI errorText) {
        this.bomp = bomp;
        this.text = text;
        this.errorWindow = errorWindow;
        this.errorText = errorText;
        handleError();
    }

    // Displays the error and plays error noise. 
    public void handleError() {
        if (bomp != null) { bomp.Play(); }
        errorText.text = text;
        errorWindow.SetActive(true);
    }
}