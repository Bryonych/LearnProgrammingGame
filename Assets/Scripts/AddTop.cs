using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AddTop : MonoBehaviour
{
    public TMP_InputField currentField;
    public GameObject errorWindow;
    public GameObject displayWindow;
    public Character character;
    public TextMeshProUGUI errorText;
    public GameObject top;
    public Sprite sBusiness;
    public Sprite hBusiness;
    public Sprite sTShirt;
    public Sprite hTShirt;
    public RuntimeAnimatorController[] controller;
    public GameObject button;

    public void OnStoppedEditing(string text) {
        errorWindow.SetActive(false);
        if (text == "true" || text == "false") {
            if (top == null) {
                top = GameObject.Find("Top");
            }
            top.SetActive(false);
            character.top = top;
            SpriteRenderer sr = character.top.GetComponent<SpriteRenderer>();
            if (character.bodyShape == 's' && text == "false") {
                sr.sprite = sBusiness; 
                character.setController("Top", controller[0]);
            }
            else if (character.bodyShape == 'h' && text == "false") {
                sr.sprite = hBusiness;
                character.setController("Top", controller[2]);
            }
            else if (character.bodyShape == 's' && text == "true") {
                sr.sprite = sTShirt;
                character.setController("Top", controller[1]);
            }
            else if (character.bodyShape == 'h' && text == "true") {
                sr.sprite = hTShirt;
                character.setController("Top", controller[3]);
            }
            else {
                print("Body shape may not have been set up?");
            }
            character.addPart(character.top);
            displayWindow.SetActive(false);
            errorWindow.SetActive(false);
            button.SetActive(true);
        }
        else {
            errorText.text = "A boolean is either true or false";
            errorWindow.SetActive(true);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        currentField.onEndEdit.AddListener(delegate {OnStoppedEditing(currentField.text);});
    }

}
