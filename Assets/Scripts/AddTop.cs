using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AddTop : MonoBehaviour
{
    public TMP_InputField currentField;
    public GameObject errorWindow;
    public GameObject[] otherWindows;
    public Character character;
    public TextMeshProUGUI errorText;
    public GameObject top;
    public Sprite sBusiness;
    public Sprite hBusiness;
    public Sprite sTShirt;
    public Sprite hTShirt;
    public Sprite[] tops;
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
        else if (text == "\"jacket\"" || text == "\"t-shirt\"") {
            if (top == null) {
                top = GameObject.Find("Top");
            }
            top.SetActive(false);
            character.top = top;
            DontDestroyOnLoad(character.top);
            SpriteRenderer sr = character.top.GetComponent<SpriteRenderer>();
            if (character.bodyShape == 's' && text == "\"jacket\"") {
                sr.sprite = sBusiness; 
                character.setController("Top", controller[0]);
                // character.staticTop = tops[..4];
                // character.animTop = topAnimations[..4];
            }
            else if (character.bodyShape == 'h' && text == "\"jacket\"") {
                sr.sprite = hBusiness;
                character.setController("Top", controller[2]);
                // character.staticTop = tops[8..12];
                // character.animTop = topAnimations[8..12];
            }
            else if (character.bodyShape == 's' && text == "\"t-shirt\"") {
                sr.sprite = sTShirt;
                character.setController("Top", controller[1]);
                // character.staticTop = tops[4..8];
                // character.animTop = topAnimations[4..8];
            }
            else if (character.bodyShape == 'h' && text == "\"t-shirt\"") {
                sr.sprite = hTShirt;
                character.setController("Top", controller[3]);
                // character.staticTop = tops[12..];
                // character.animTop = topAnimations[12..];
            }
            else {
                print("Body shape may not have been set up?");
            }
            character.addPart(character.top);
        }
        else {
            errorText.text = "Inputs are either \"jacket\" or \"t-shirt\"";
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
