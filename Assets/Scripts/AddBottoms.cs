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

    public void OnStoppedEditing(string text) {
        errorWindow.SetActive(false);
        // if (text.Length > 0 && text[text.Length-1] == ';') {
        //     errorText.text = "\";\" Only required at the end of a statement";
        //     errorWindow.SetActive(true);
        // }
        // else if (text[0] != '\"' || text[text.Length-1] != '\"') {
        //     errorText.text = "Requires a string, which needs quotation marks";
        //     errorWindow.SetActive(true);
        // }
        if (text == "true" || text == "false") {
            if (bottoms == null) {
                bottoms = GameObject.Find("Bottoms");
            }
            bottoms.SetActive(false);
            character.bottoms = bottoms;
            DontDestroyOnLoad(character.bottoms.transform.parent);
            SpriteRenderer sr = character.bottoms.GetComponent<SpriteRenderer>();
            if (character.bodyShape == 's' && text == "false") {
                sr.sprite = sTrousers; 
                character.setController("Bottoms", controller[0]);

            }
            else if (character.bodyShape == 'h' && text == "false") {
                sr.sprite = hTrousers;
                character.setController("Bottoms", controller[2]);
            }
            else if (character.bodyShape == 's' && text == "true") {
                sr.sprite = sShorts;
                character.setController("Bottoms", controller[1]);
            }
            else if (character.bodyShape == 'h' && text == "true") {
                sr.sprite = hShorts;
                character.setController("Bottoms", controller[3]);
            }
            else {
                print("Body shape may not have been set up?");
            }
            character.addPart(character.bottoms);
            ChangeWindow();
        }
        else {
            errorText.text = "A boolean is either true or false";
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
