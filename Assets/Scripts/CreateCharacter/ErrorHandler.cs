using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ErrorHandler {

    private AudioSource bomp;
    private string text;
    private GameObject errorWindow;
    private TextMeshProUGUI errorText;

    public ErrorHandler(AudioSource bomp, string text, GameObject errorWindow, TextMeshProUGUI errorText) {
        this.bomp = bomp;
        this.text = text;
        this.errorWindow = errorWindow;
        this.errorText = errorText;
        handleError();
    }

    public void handleError() {
        bomp.Play();
        errorText.text = text;
        errorWindow.SetActive(true);
    }
}