using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// Class <c>RevealClue<c> handles changing the pages for all challenges.
/// Listtens to input for list access challenge and passes to CheckChallengeLogic for checking
/// <summary> 
public class RevealClue : MonoBehaviour
{   
    public Character character;
    public TMP_InputField currentField;
    public GameObject errorWindow;
    public GameObject displayWindow;
    public GameObject nextWindow;
    public GameObject[] clues;
    public TextMeshProUGUI errorText;
    public GameObject[] screens;
    public GameObject button;
    public GameObject backButton;
    private int current = 0;
    AudioSource beep;
    AudioSource bomp;
    
    // Handles input to text field. 
    public void OnStoppedEditing(string text) {
        CheckChallengeLogic ccl = new CheckChallengeLogic(errorWindow, errorText, bomp);
        errorWindow.SetActive(false);
        // Ignores no input
        if (text.Length > 0) {
            if (currentField.name == "ListAccessInputField") {
                // If passed checks, play success noise, change windows. 
                if (ccl.HandleListAccessEntry(text)) {
                    if (beep != null) { beep.Play(); }
                    Destroy(displayWindow, beep.clip.length);
                    nextWindow.SetActive(true);
                }
            }
        }
    }

    // Displays an error on incorrect input.
    public void DisplayError() {
        string eText = "The list name is 'barrels', so our for each loop needs to start with:\n for(Barrel barrel : barrels) {";
        ErrorHandler eh = new ErrorHandler(bomp, eText, errorWindow, errorText);
    }

    // Changes to the next screen.
    public void ChangeScreen() {
        if (current == 1) { button.SetActive(false); }
        screens[current].SetActive(false);
        screens[current+1].SetActive(true);
        current += 1;
    }

    // Moves back to last screen
    public void LastScreen() {
        if (current == 0) { return; } // Shouldn't happen
        screens[current].SetActive(false);
        screens[current-1].SetActive(true);
        current -= 1;
        button.SetActive(true);
    }

    // Plays the church animation for list access challenge. 
    public void ShowClue() {
        if (beep != null) { beep.Play(); }
        button.SetActive(false);
        backButton.SetActive(false);
        errorWindow.SetActive(false);
        character.increaseChallengeNumber();
        Destroy(displayWindow, beep.clip.length);
        Vector3 pos = character.body.transform.position;
        if (pos.x < -20 && pos.x > -26 && pos.y < -9 && pos.y > -15) {
            clues[0].SetActive(true);
            clues[0].GetComponent<Animator>().Play("ChurchAnimation");
        }
        else if (pos.x < -0.7 && pos.x > -2.6 && pos.y < -5.5 && pos.y > -7.6) {
            clues[1].SetActive(true);
            clues[1].GetComponent<Animator>().Play("ChurchAnimation2");
        }
        else if (pos.x < -19.5 && pos.x > -22.4 && pos.y < 4.5 && pos.y > 2.0) {
            clues[2].SetActive(true);
            clues[2].GetComponent<Animator>().Play("ChurchAnimation3");
        }
        else if (pos.x < 7.5 && pos.x > 3.0 && pos.y < 13.0 && pos.y > 9.0) {
            clues[3].SetActive(true);
            clues[3].GetComponent<Animator>().Play("ChurchAnimation4");
        }
        
        foreach (GameObject go in character.getParts()) {
            PlayerMovementController pmc = go.GetComponent(typeof(PlayerMovementController)) as PlayerMovementController;
            pmc.UpdateMovementSpeed(2.5f);
        }
    }

    // Start is called before the first frame update.
    void Start() {
        // Listen to the input field
        currentField.onEndEdit.AddListener(delegate {OnStoppedEditing(currentField.text);});
        // Put the cursor in the input field
        if (currentField != null) { currentField.Select(); }
        // Get the audio
        beep = GameObject.Find("Beep").GetComponent<AudioSource>();
        bomp = GameObject.Find("Bomp").GetComponent<AudioSource>();
    }
}
