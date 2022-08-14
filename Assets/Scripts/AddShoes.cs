using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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

    public void OnStoppedEditing(string text) {
        errorWindow.SetActive(false);
        // if (!character.hasShoes) {
        //     errorText.text = "Character's hasShoes field was set to false";
        //     errorWindow.SetActive(true);
        // }
        // else if (text.Length > 0 && text[text.Length-1] == ';') {
        //     errorText.text = "\";\" Only required at the end of a statement";
        //     errorWindow.SetActive(true);
        // }
        // if (text[0] != '\"' || text[text.Length-1] != '\"') {
        //     errorText.text = "Requires a string, which needs quotation marks";
        //     errorWindow.SetActive(true);
        // }
        if (text == "s" || text == "b") {
            if (footwear == null) {
                footwear = GameObject.Find("Shoes");
            }
            footwear.SetActive(false);
            character.shoes = footwear;
            SpriteRenderer sr = character.shoes.GetComponent<SpriteRenderer>();
            if (character.bodyShape == 's' && text == "s") {
                sr.sprite = sGreen;
                character.setController("Shoes", controller[0]);
            }
            else if (character.bodyShape == 'h' && text == "s") {
                sr.sprite = hGreen;
                character.setController("Shoes", controller[2]);
            }
            else if (character.bodyShape == 's' && text == "b") {
                sr.sprite = sBoots;
                character.setController("Shoes", controller[1]);
            }
            else if (character.bodyShape == 'h' && text == "b") {
                sr.sprite = hBoots;
                character.setController("Shoes", controller[3]);
            }
            else {
                print("Body shape may not have been set up?");
            }
            character.addPart(character.shoes);
            ChangeWindow();
        }
        else {
            errorText.text = "Inputs are either s or b";
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
