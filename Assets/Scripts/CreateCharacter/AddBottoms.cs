using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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

    public void OnStoppedEditing(string text) {
        errorWindow.SetActive(false);
        Bottoms bot = new Bottoms(sTrousers, controller[0], character, bottoms);
        bot.setSprites(sTrousers, hTrousers, sShorts, hShorts, controller);
        if (bot.checkLogicBottoms(text, errorWindow, errorText, beep, bomp)) {
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
