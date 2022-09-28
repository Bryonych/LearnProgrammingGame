using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AddAttribute : MonoBehaviour
{
    public TMP_InputField currentField;
    public GameObject errorWindow;
    public GameObject displayWindow;
    public GameObject nextWindow;
    public Character character;
    public TextMeshProUGUI errorText;
    public GameObject go;
    public Sprite[] sprites;
    public RuntimeAnimatorController[] controllers;
    public GameObject button;
    AudioSource beep;
    AudioSource bomp;

    public void OnStoppedEditing(string text) {
        errorWindow.SetActive(false);     
        bool check = false;
        switch(go.name) {
            case "Hair":
                Hair hr = new Hair(sprites, controllers, character, go);
                check = hr.checkLogicHair(text, errorWindow, errorText, beep, bomp);
                break;
            case "Top":
                Top t = new Top(sprites, controllers, character, go);
                check = t.checkLogicTop(text, errorWindow, errorText, beep, bomp);
                break;
            case "Hat":
                Hat h = new Hat(sprites, controllers, character, go);
                check = h.checkLogicHat(text, errorWindow, errorText, beep, bomp);
                break;
            case "Shoes":
                Shoes s = new Shoes(sprites, controllers, character, go);
                check = s.checkLogicShoes(text, errorWindow, errorText, beep, bomp);
                break; 
        }
        if(check) {
            if (go.name == "Top") {
                Invoke("EndLesson", beep.clip.length);
                return;
            }
            Invoke("ChangeWindow", beep.clip.length);
        }
    }

    public void ChangeWindow() {
        displayWindow.SetActive(false);
        nextWindow.SetActive(true);
    }

    public void EndLesson() {
        displayWindow.SetActive(false);
        errorWindow.SetActive(false);
        button.SetActive(true);
    }


    // Start is called before the first frame update
    void Start()
    {
        currentField.onEndEdit.AddListener(delegate {OnStoppedEditing(currentField.text);});
        currentField.Select();
        beep = GameObject.Find("Beep").GetComponent<AudioSource>();
        bomp = GameObject.Find("Bomp").GetComponent<AudioSource>();
    }
}