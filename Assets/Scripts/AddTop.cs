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
        int a;
        float b;
        if (!int.TryParse(text, out a) && !float.TryParse(text, out b)) {
            errorText.text = "An integer is a number with no decimal place and a float is a number with a decimal place";
            errorWindow.SetActive(true);
        }
        else {
            if (top == null) {
                top = GameObject.Find("Top");
            }
            top.SetActive(false);
            character.top = top;
            SpriteRenderer sr = character.top.GetComponent<SpriteRenderer>();
            if (character.bodyShape == 's' && float.TryParse(text, out b)) {
                sr.sprite = sBusiness; 
                character.setController("Top", controller[0]);
            }
            else if (character.bodyShape == 'h' && float.TryParse(text, out b)) {
                sr.sprite = hBusiness;
                character.setController("Top", controller[2]);
            }
            else if (character.bodyShape == 's' && int.TryParse(text, out a)) {
                sr.sprite = sTShirt;
                character.setController("Top", controller[1]);
            }
            else if (character.bodyShape == 'h' && int.TryParse(text, out a)) {
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
    }


    // Start is called before the first frame update
    void Start()
    {
        currentField.onEndEdit.AddListener(delegate {OnStoppedEditing(currentField.text);});
    }

}
