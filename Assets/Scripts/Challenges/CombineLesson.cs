using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// Class <c>CombineLesson<c> listens to the drop down box
/// and passes to CheckChallengeLogic for checking.
/// <summary>
public class CombineLesson : MonoBehaviour
{
    public TextMeshProUGUI[] displayBox;
    public GameObject errorWindow;
    public TextMeshProUGUI errorText;
    public GameObject button;
    public GameObject displayWindow;
    public Character character;
    public GameObject compass;
    private int order = 0;
    AudioSource beep;
    AudioSource bomp;

    // Receives the index of the selected item and passes to CheckOrderCombined for checking.
    public void CheckSelection(int selected) {
        errorWindow.SetActive(false);
        CheckChallengeLogic ccl = new CheckChallengeLogic(errorWindow, errorText, bomp);
        // Obtain current count of correctly ordered lines.
        order = ccl.CheckOrderCombined(selected, order, displayBox);
        // All correct - remove text, play success noise, display the clue and the button to move on.
        if (order == 5) {
            foreach (TextMeshProUGUI t in displayBox) {
                t.text = "";
            }
            beep.Play();
            compass.SetActive(true);
            displayBox[0].text = "West";
            button.SetActive(true);
        }
    }

    // Ends the challenge
    public void CloseChallenge() {        
        // Let the character move again   
        foreach (GameObject go in character.getParts()) {
            PlayerMovementController pmc = go.GetComponent(typeof(PlayerMovementController)) as PlayerMovementController;
            pmc.UpdateMovementSpeed(2.5f);
        }
        // Store current challenge number
        character.increaseChallengeNumber();
        // Close window
        displayWindow.SetActive(false);
        compass.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        // Find audio
        beep = GameObject.Find("Beep").GetComponent<AudioSource>();
        bomp = GameObject.Find("Bomp").GetComponent<AudioSource>();
    }
}
