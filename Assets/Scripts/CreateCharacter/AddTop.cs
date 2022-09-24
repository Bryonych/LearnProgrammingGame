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
    AudioSource beep;
    AudioSource bomp;

    public void OnStoppedEditing(string text) {
        errorWindow.SetActive(false);
        Top t = new Top(sBusiness, hBusiness, sTShirt, hTShirt, controller, character, top);
        if (t.checkLogicTop(text, errorWindow, errorText, beep, bomp)) {
            Invoke("EndLesson", beep.clip.length);
        }
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
        beep = GameObject.Find("Beep").GetComponent<AudioSource>();
        bomp = GameObject.Find("Bomp").GetComponent<AudioSource>();
    }

}
