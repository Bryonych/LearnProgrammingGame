using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AddHat : MonoBehaviour
{
    public TMP_InputField currentField;
    public GameObject errorWindow;
    public GameObject[] otherWindows;
    public Character character;
    public TextMeshProUGUI errorText;
    public GameObject hat;
    public Sprite cap;
    public Sprite topHat;
    public Sprite[] hats;


    public void OnStoppedEditing(string text) {
        CloseOthers();
        if (!character.hasHat) {
            errorText.text = "Character's hasHat field was set to false";
            errorWindow.SetActive(true);
        }
        else if (text.Length > 0 && text[text.Length-1] == ';') {
            errorText.text = "\";\" Only required at the end of a statement";
            errorWindow.SetActive(true);
        }
        else if (text[0] != '\"' || text[text.Length-1] != '\"') {
            errorText.text = "Requires a string, which needs quotation marks";
            errorWindow.SetActive(true);
        }
        else if (text == "\"cap\"" || text == "\"top hat\"") {
            if (hat == null) {
                hat = GameObject.Find("Hat");
            }
            hat.SetActive(false);
            character.hat = hat;
            SpriteRenderer sr = character.hat.GetComponent<SpriteRenderer>();
            if (text == "\"cap\"") {
                sr.sprite = cap; 
                character.staticHat = hats[4..];
            }
            else if (text == "\"top hat\"") {
                sr.sprite = topHat;
                character.staticHat = hats[..4];
            }
            character.addPart(character.hat);
        }
        else {
            errorText.text = "Inputs are either \"cap\" or \"top hat\"";
            errorWindow.SetActive(true);
        }
    }

    public void CloseOthers() {
        foreach (GameObject window in otherWindows) {
            window.SetActive(false);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        currentField.onEndEdit.AddListener(delegate {OnStoppedEditing(currentField.text);});
    }
}
