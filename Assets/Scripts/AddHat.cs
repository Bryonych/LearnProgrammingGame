using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AddHat : MonoBehaviour
{
    public TMP_InputField currentField;
    public GameObject errorWindow;
    public GameObject displayWindow;
    public GameObject nextWindow;
    public Character character;
    public TextMeshProUGUI errorText;
    public GameObject hat;
    public Sprite cap;
    public Sprite topHat;
    public RuntimeAnimatorController[] controller;

    public void OnStoppedEditing(string text) {
        errorWindow.SetActive(false);
        if (text[0] != '\"' || text[text.Length-1] != '\"') {
            errorText.text = "A string is in quotation marks";
            errorWindow.SetActive(true);
        }
        else if (text == "\"cap\"" || text == "\"top hat\"") {
            if (hat == null) {
                hat = GameObject.Find("Hat");
            }
            hat.SetActive(false);
            character.hat = hat;
            SpriteRenderer sr = character.hat.GetComponent<SpriteRenderer>();
            if (character.bodyShape == 'h' && text == "\"cap\"") {
                sr.sprite = cap; 
                character.setController("Hat", controller[1]);
            }
            else if (character.bodyShape == 's' && text == "\"top hat\"") {
                sr.sprite = topHat;
                character.setController("Hat", controller[0]);
            }
            else if (character.bodyShape == 'h' && text == "\"top hat\"") {
                sr.sprite = topHat;
                character.setController("Hat", controller[2]);
            }
            else if (character.bodyShape == 's' && text == "\"cap\"") {
                sr.sprite = cap; 
                character.setController("Hat", controller[3]);
            }
            character.addPart(character.hat);
            ChangeWindow();
        }
        else {
            errorText.text = "Inputs are either \"cap\" or \"top hat\"";
            errorWindow.SetActive(true);
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
    }
}
