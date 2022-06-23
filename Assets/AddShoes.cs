using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AddShoes : MonoBehaviour
{

    public TMP_InputField currentField;
    public GameObject errorWindow;
    public GameObject[] otherWindows;
    public Character character;
    public TextMeshProUGUI errorText;
    public GameObject footwear;
    public Sprite sBoots;
    public Sprite hGreen;
    public Sprite sGreen;
    public Sprite hBoots;


    public void OnStoppedEditing(string text) {
        CloseOthers();
        if (!character.hasShoes) {
            errorText.text = "Character's hasShoes field was set to false";
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
        else if (text == "\"shoes\"" || text == "\"boots\"") {
            if (footwear == null) {
                footwear = GameObject.Find("Shoes");
            }
            footwear.SetActive(true);
            print(footwear);
            character.shoes = footwear;
            SpriteRenderer sr = character.shoes.GetComponent<SpriteRenderer>();
            if (character.bodyShape == 's' && text == "\"shoes\"") {
                sr.sprite = sGreen; 
            }
            else if (character.bodyShape == 'h' && text == "\"shoes\"") {
                sr.sprite = hGreen;
            }
            else if (character.bodyShape == 's' && text == "\"boots\"") {
                sr.sprite = sBoots;
            }
            else if (character.bodyShape == 'h' && text == "\"boots\"") {
                sr.sprite = hBoots;
            }
            else {
                print("Body shape may not have been set up?");
            }
        }
        else {
            errorText.text = "Inputs are either \"shoes\" or \"boots\"";
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
        CloseOthers();
        currentField.onEndEdit.AddListener(delegate {OnStoppedEditing(currentField.text);});
    }

}
