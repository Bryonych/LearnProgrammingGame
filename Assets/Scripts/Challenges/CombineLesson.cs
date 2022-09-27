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
    private int order = 0;
    AudioSource beep;
    AudioSource bomp;

    public void CheckSelection(int selected) {
        errorWindow.SetActive(false);
        CheckChallengeLogic ccl = new CheckChallengeLogic(errorWindow, errorText, bomp);
        order = ccl.CheckOrderCombined(selected, order, displayBox);
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
