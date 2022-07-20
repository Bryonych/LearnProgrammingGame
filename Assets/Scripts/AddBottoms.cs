using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AddBottoms : MonoBehaviour
{
    public TMP_InputField currentField;
    public GameObject errorWindow;
    public GameObject[] otherWindows;
    public Character character;
    public TextMeshProUGUI errorText;
    public GameObject bottoms;
    public Sprite sTrousers;
    public Sprite hTrousers;
    public Sprite sShorts;
    public Sprite hShorts;
    public Sprite[] troudies;
    public RuntimeAnimatorController[] controller;

    public void OnStoppedEditing(string text) {
        CloseOthers();
        if (text.Length > 0 && text[text.Length-1] == ';') {
            errorText.text = "\";\" Only required at the end of a statement";
            errorWindow.SetActive(true);
        }
        else if (text[0] != '\"' || text[text.Length-1] != '\"') {
            errorText.text = "Requires a string, which needs quotation marks";
            errorWindow.SetActive(true);
        }
        else if (text == "\"shorts\"" || text == "\"trousers\"") {
            if (bottoms == null) {
                bottoms = GameObject.Find("Bottoms");
            }
            bottoms.SetActive(false);
            character.bottoms = bottoms;
            DontDestroyOnLoad(character.bottoms);
            SpriteRenderer sr = character.bottoms.GetComponent<SpriteRenderer>();
            if (character.bodyShape == 's' && text == "\"trousers\"") {
                sr.sprite = sTrousers; 
                character.setController("Bottoms", controller[0]);
                // character.staticBottoms = troudies[..4];
                // character.animBottoms = pantsAnimations[..4];
            }
            else if (character.bodyShape == 'h' && text == "\"trousers\"") {
                sr.sprite = hTrousers;
                character.setController("Bottoms", controller[2]);
                // character.staticBottoms = troudies[8..12];
                // character.animBottoms = pantsAnimations[8..12];
            }
            else if (character.bodyShape == 's' && text == "\"shorts\"") {
                sr.sprite = sShorts;
                character.setController("Bottoms", controller[1]);
                // character.staticBottoms = troudies[4..8];
                // character.animBottoms = pantsAnimations[4..8];
            }
            else if (character.bodyShape == 'h' && text == "\"shorts\"") {
                sr.sprite = hShorts;
                character.setController("Bottoms", controller[3]);
                // character.staticBottoms = troudies[12..];
                // character.animBottoms = pantsAnimations[12..];
            }
            else {
                print("Body shape may not have been set up?");
            }
            character.addPart(character.bottoms);
        }
        else {
            errorText.text = "Inputs are either \"trousers\" or \"shorts\"";
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
