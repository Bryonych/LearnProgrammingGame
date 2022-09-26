using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ConditionalDropDown : MonoBehaviour
{
    public Character character;
    public GameObject displayWindow;
    public TextMeshProUGUI errorText;
    public GameObject errorPanel;
    public TextMeshProUGUI displaySelected;
    public TMP_Dropdown selected;
    public GameObject button;
    private int[] correctOrder = {2, 0, 3, 1, 5, 4};
    private int codeLineCount = 0;
    List<TMP_Dropdown.OptionData> menuOptions;
    AudioSource beep;
    AudioSource bomp;

    public void Start() {
        menuOptions = selected.GetComponent<TMP_Dropdown>().options;
        beep = GameObject.Find("Beep").GetComponent<AudioSource>();
        bomp = GameObject.Find("Bomp").GetComponent<AudioSource>();
    }
    
    public void OnSelect() {
        errorPanel.SetActive(false);
        int index = selected.value;
        print(index);
        if (index == correctOrder[codeLineCount]) {
            displaySelected.text += menuOptions[index].text + "\n";
            codeLineCount += 1;
        }
        else {
            string eText = "The order should be: if(statement){ instruction } else { instruction }";
            ErrorHandler eh = new ErrorHandler(bomp, eText, errorPanel, errorText);
        }
        if (codeLineCount == 6) {
            beep.Play();
            displaySelected.text = "The attacker went North!";
            button.SetActive(true);
            character.increaseChallengeNumber();
        }
    }

    public void Close() {
        foreach (GameObject go in character.getParts()) {
            PlayerMovementController pmc = go.GetComponent(typeof(PlayerMovementController)) as PlayerMovementController;
            pmc.movementSpeed = 2.5f;
        }
        displayWindow.SetActive(false);
    }
    
}
