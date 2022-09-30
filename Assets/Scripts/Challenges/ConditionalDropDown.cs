using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// Class <c>ConditionalDropDown<c> Listens for selection from the dropdown list
/// and passes to CheckChallengeLogic for checking.
/// <summary>
public class ConditionalDropDown : MonoBehaviour
{
    public Character character;
    public GameObject displayWindow;
    public TextMeshProUGUI errorText;
    public GameObject errorPanel;
    public TextMeshProUGUI displaySelected;
    public TMP_Dropdown selected;
    public GameObject button;
    private int codeLineCount = 0;
    List<TMP_Dropdown.OptionData> menuOptions;
    AudioSource beep;
    AudioSource bomp;

    // Start is called before the first frame update
    public void Start() {
        // Get the menu items and audio
        menuOptions = selected.GetComponent<TMP_Dropdown>().options;
        beep = GameObject.Find("Beep").GetComponent<AudioSource>();
        bomp = GameObject.Find("Bomp").GetComponent<AudioSource>();
    }
    
    // Gets selection from the dropdown and passes to CheckChallengeLogic for checking. 
    public void OnSelect() {
        CheckChallengeLogic ccl = new CheckChallengeLogic(errorPanel, errorText, bomp);
        errorPanel.SetActive(false);
        int index = selected.value;
        // Get the number of correct selections.
        codeLineCount = ccl.CheckConditionalsOrder(index, codeLineCount, menuOptions, displaySelected);
        // If all correct, play success noise, display clue and button to move on and store next challenge number.
        if (codeLineCount == 6) {
            beep.Play();
            displaySelected.text = "The attacker went North!";
            button.SetActive(true);
            character.increaseChallengeNumber();
        }
    }

    // Closes the challenge
    public void Close() {
        // Reinstates player movement. 
        foreach (GameObject go in character.getParts()) {
            PlayerMovementController pmc = go.GetComponent(typeof(PlayerMovementController)) as PlayerMovementController;
            pmc.movementSpeed = 2.5f;
        }
        // Closes the screen.
        displayWindow.SetActive(false);
    }
    
}
