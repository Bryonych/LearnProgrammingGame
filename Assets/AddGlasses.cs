using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AddGlasses : MonoBehaviour
{
    public TMP_InputField currentField;
    public GameObject errorWindow;
    public GameObject[] otherWindows;
    public Character character;
    public TextMeshProUGUI errorText;
    public GameObject glasses;
    public Sprite spectacles;
    public Sprite sunglasses;


    public void OnStoppedEditing(string text) {
        CloseOthers();
        if (!character.hasGlasses) {
            errorText.text = "Character's hasGlasses field was set to false";
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
        else if (text == "\"glasses\"" || text == "\"sun glasses\"") {
            if (glasses == null) {
                glasses = GameObject.Find("Glasses");
            }
            glasses.SetActive(true);
            character.glasses = glasses;
            SpriteRenderer sr = character.glasses.GetComponent<SpriteRenderer>();
            if (text == "\"glasses\"") {
                sr.sprite = spectacles; 
            }
            else if (text == "\"sun glasses\"") {
                sr.sprite = sunglasses;
            }
        }
        else {
            errorText.text = "Inputs are either \"glasses\" or \"sun glasses\"";
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
