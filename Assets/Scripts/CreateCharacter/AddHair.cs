using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AddHair : MonoBehaviour
{
    public TMP_InputField currentField;
    public GameObject errorWindow;
    public GameObject displayWindow;
    public GameObject nextWindow;
    public Character character;
    public TextMeshProUGUI errorText;
    public GameObject hair;
    public Sprite shortBlack;
    public Sprite shortOrange;
    public Sprite dreads;
    public Sprite longGreen;
    public RuntimeAnimatorController[] controller;
    AudioSource beep;
    AudioSource bomp;

    public void OnStoppedEditing(string text) {
        errorWindow.SetActive(false);
        Hair hr = new Hair(shortBlack, shortOrange, dreads, longGreen, controller, character, hair);
        if(hr.checkLogicHair(text, errorWindow, errorText, beep, bomp)) {
            Invoke("ChangeWindow", beep.clip.length);
        }
    }

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
