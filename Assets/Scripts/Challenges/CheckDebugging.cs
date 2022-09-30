using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CheckDebugging : MonoBehaviour
{
    public TMP_InputField currentField;
    public GameObject errorWindow;
    public TextMeshProUGUI errorText;
    public TextMeshProUGUI instructionText;
    public Character character;
    public GameObject displayWindow;
    public GameObject[] buttons;
    public GameObject gameOver;
    public GameObject attacker;
    public GameObject cryingAttacker;
    AudioSource beep;
    AudioSource bomp;
    AudioSource win;
    private int selected = 0;
    private int countFixed = 0;
    private string inputFirst = "Enter the correction in the input field before selecting the next bug.";

    public void OnStoppedEditing(string text) {
        errorWindow.SetActive(false);
        CorrectionChecker cc = new CorrectionChecker(errorWindow, errorText, bomp);
        if (cc.CheckInput(text, selected)) {
            if (beep != null) { beep.Play(); }
            instructionText.text = "Well done, now select the next bug";
            currentField.enabled = false;
            buttons[selected-1].GetComponentInChildren<TMP_Text>().text = cc.GetCorrectText();
            buttons[selected-1].GetComponentInChildren<TMP_Text>().color = new Color(1f,1f,1f);
            buttons[selected-1].GetComponent<Button>().interactable = false;
            countFixed +=1;
            if (countFixed == 4) { EndGame(); }
        }
    }

    public void EndGame() {
        Destroy(displayWindow, beep.clip.length);
        attacker.SetActive(false);
        cryingAttacker.SetActive(true);
        gameOver.SetActive(true);
        
    }

    public void SelectedFirst() {
        if (currentField.enabled == true) { DisplayError(inputFirst); }
        string eText = "The first line has no bugs. This line creates a list integers called 'numbers' that contains "
                        + "7, 6, 3 and 5.";
        DisplayError(eText);
    }

    public void SelectedForth() {
        if (currentField.enabled == true) { DisplayError(inputFirst); }
        string eText = "This line has no bugs. This line displays the string \"Six is present in the list\" "
                        + "if it has been found while iterating through the list.";
        DisplayError(eText);
    }

    public void SelectedSeven() {
        if (currentField.enabled == true) { DisplayError(inputFirst); }
        string eText = "This line has no bugs. This line displays the string \"Six is not present\" "
                        + "if six is not in the list. It will not be called for this list, because there is a 6.";
        DisplayError(eText);
    }

    public void SelectedEight() {
        if (currentField.enabled == true) { DisplayError(inputFirst); }
        string eText = "This line has no bugs. This is closing the curly brackets for the \'else\' block";
        DisplayError(eText);
    }

    public void SelectedNine() {
        if (currentField.enabled == true) { DisplayError(inputFirst); }
        string eText = "This line has no bugs. This is closing the curly brackets for the foreach loop.";
        DisplayError(eText);
    }

    public void Selected(int n) {
        if (currentField.enabled == true) { DisplayError(inputFirst); }
        else {
            instructionText.text = "";
            selected = n;
            if (beep != null) { beep.Play(); }
            buttons[n-1].GetComponentInChildren<TMP_Text>().color = new Color(146f/255f, 175f/255f, 233f/255f);
            currentField.enabled = true;
            currentField.Select();
            currentField.text = "";
        }
    }

    public void DisplayError(string eText) {
        ErrorHandler eh = new ErrorHandler(bomp, eText, errorWindow, errorText);
    }


    // Start is called before the first frame update
    void Start()
    {
        currentField.onEndEdit.AddListener(delegate {OnStoppedEditing(currentField.text);});
        currentField.enabled = false;
        beep = GameObject.Find("Beep").GetComponent<AudioSource>();
        bomp = GameObject.Find("Bomp").GetComponent<AudioSource>();
    }

}
