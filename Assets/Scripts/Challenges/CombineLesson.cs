using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CombineLesson : MonoBehaviour
{
    public TextMeshProUGUI[] displayBox;
    public GameObject errorWindow;
    public TextMeshProUGUI errorText;
    public GameObject button;
    public GameObject displayWindow;
    public Character character;
    private string[] codeOrder = { " for (Road road : roadList) {", "    if (road.contains(document) {",
                                    "       display(road.getDirection());", "    }", " }"};
    private int order = 0;
    AudioSource beep;
    AudioSource bomp;

    public void CheckSelection(int selected) {
        if (selected == order) {
            displayBox[order].text = codeOrder[order];
            order += 1;
        }
        else {
            string text = "The order should be:\n for(Type _ : _) { if(condition) { //do something } }";
            ErrorHandler eh = new ErrorHandler(bomp, text, errorWindow, errorText);
        }
        if (order == 5) {
            foreach (TextMeshProUGUI t in displayBox) {
                t.text = "";
            }
            beep.Play();
            displayBox[0].text = "West";
            button.SetActive(true);
        }
    }

    public void CloseChallenge() {           
        foreach (GameObject go in character.getParts()) {
            PlayerMovementController pmc = go.GetComponent(typeof(PlayerMovementController)) as PlayerMovementController;
            pmc.movementSpeed = 2.5f;
        }
        character.increaseChallengeNumber();
        displayWindow.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        beep = GameObject.Find("Beep").GetComponent<AudioSource>();
        bomp = GameObject.Find("Bomp").GetComponent<AudioSource>();
    }
}
