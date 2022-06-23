using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AddHair : MonoBehaviour
{
    public TMP_InputField currentField;
    public GameObject errorWindow;
    public GameObject[] otherWindows;
    public Character character;
    public TextMeshProUGUI errorText;
    public GameObject hair;
    public Sprite shortBlack;
    public Sprite shortOrange;
    public Sprite dreads;
    public Sprite longGreen;


    public void OnStoppedEditing(string text) {
        CloseOthers();
        if (!character.hasHair) {
            errorText.text = "Character's hasHair field was set to false";
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
        else if (text == "\"long green\"" || text == "\"short black\"" || text == "\"dreads\"" || text == "\"short orange\"") {
            if (hair == null) {
                hair = GameObject.Find("Hair");
            }
            hair.SetActive(true);
            character.hair = hair;
            SpriteRenderer sr = character.hair.GetComponent<SpriteRenderer>();
            if (text == "\"long green\"") {
                sr.sprite = longGreen; 
            }
            else if (text == "\"short black\"") {
                sr.sprite = shortBlack;
            }
            else if (text == "\"dreads\"") {
                sr.sprite = dreads;
            }
            else if (text == "\"short orange\"") {
                sr.sprite = shortOrange;
            }
        }
        else {
            errorText.text = "Inputs are either \"long green\" or \"short black\" or \"dreads\" or \"short orange\"";
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
